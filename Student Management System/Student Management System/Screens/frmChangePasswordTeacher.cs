using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Student_Management_System.Screens
{
    public partial class frmChangePasswordTeacher : Form
    {
        public frmChangePasswordTeacher()
        {
            InitializeComponent();
        }

        //Create Instant Variable
        SqlConnection sqlconn;
        SqlCommand sqlcomm;
        SqlDataReader sqlread;

        //Create the memory variable
        string sql;
        string password;

        private void frmChangePasswordTeacher_Load(object sender, EventArgs e)
        {
            //Select old password text field
            txtOld.Select();
            //Set the connection statement
            sql = "Data Source=Ashan\\SQLEXPRESS;Initial Catalog=Login;Integrated Security=True";
            //Assigning the connection
            sqlconn = new SqlConnection(sql);
        }

        private void btnChangePw_Click(object sender, EventArgs e)
        {
            //set the SQL statement
            sql = "select * from TableTeacherLogin where Teacherid='" + frmLogin.useridpassing + "'";

            //open the connection
            sqlconn.Open();
            //set the statement in command control
            sqlcomm = new SqlCommand(sql, sqlconn);
            //read the command
            sqlread = sqlcomm.ExecuteReader();
            {
                //Load the records
                sqlread.Read();
                {
                    //Assigning the Values
                    password = sqlread[1].ToString();
                }
            }
            //close the connection
            sqlconn.Close();

            if ((txtOld.Text == "") || (txtNew.Text == "") || (txtNewagain.Text == ""))
            {
                MessageBox.Show("All text fields required!", "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (txtOld.Text == "")
                {
                    txtOld.Focus();
                }
                else
                {
                    if (txtNew.Text == "")
                    {
                        txtNew.Focus();
                    }
                    else
                        if (txtNewagain.Text == "")
                    {
                        txtNewagain.Focus();
                    }
                }
            }
            else
            {
                if (password != txtOld.Text)
                {
                    MessageBox.Show("Password is wrong!", "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtOld.Clear();
                    txtNew.Clear();
                    txtNewagain.Clear();
                    txtOld.Focus();
                }
                else
                {
                    if (txtNew.Text.Length < 5)
                    {
                        MessageBox.Show("Your password must be at least 5 characters long. Please try another", "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtNew.Focus();
                        txtNew.SelectAll();
                    }
                    else
                    {
                        //Check new passwords match
                        if (txtNew.Text != txtNewagain.Text)
                        {
                            //Display message
                            MessageBox.Show("New passwords don't match", "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtOld.Clear();
                            txtNew.Clear();
                            txtNewagain.Clear();
                            txtOld.Focus();
                        }
                        else
                        {
                            //Check old & New passwords match
                            if (txtNew.Text == txtOld.Text)
                            {
                                MessageBox.Show("Please enter a new password", "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtOld.Clear();
                                txtNew.Clear();
                                txtNewagain.Clear();
                                txtOld.Focus();
                            }
                            else
                            {
                                DialogResult diRes;
                                diRes = MessageBox.Show("Do you want to change your password?", "Change Password", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (diRes == DialogResult.Yes)
                                {
                                    //Using error handler tool
                                    try
                                    {
                                        //set the update statement
                                        sql = "update TableTeacherLogin set Password='" + txtNew.Text + "' where Teacherid='" + frmLogin.useridpassing + "'";


                                        //open the connection
                                        sqlconn.Open();
                                        //Assigning the statement in command control
                                        sqlcomm = new SqlCommand(sql, sqlconn);
                                        //Write the record
                                        sqlcomm.ExecuteNonQuery();

                                        //Display message
                                        MessageBox.Show("Password updated successfully!", "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }

                                    catch (Exception ex)
                                    {
                                        //Disply error
                                        MessageBox.Show("Error! " + ex.Message, "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    finally
                                    {

                                        //Close the connection
                                        sqlconn.Close();
                                    }

                                    txtOld.Clear();
                                    txtNew.Clear();
                                    txtNewagain.Clear();
                                }
                                else
                                {
                                    MessageBox.Show("Update Canceled!", "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                    txtOld.Clear();
                                    txtNew.Clear();
                                    txtNewagain.Clear();
                                }
                            }
                        }
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
