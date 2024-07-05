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
    public partial class frmAddTeacher : Form
    {
        public frmAddTeacher()
        {
            InitializeComponent();
        }
        //Create Instant Variable
        SqlConnection sqlconn;
        SqlCommand sqlcomm;
        SqlDataReader sqlread;

        //Create the memory variable
        string maxteacherid;
        string sql;

        private void frmAddTeacher_Load(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
            txtTeachername.Select();
            //Set the connection statement
            sql = "Data Source=Ashan\\SQLEXPRESS;Initial Catalog=Login;Integrated Security=True";
            //Assigning the connection
            sqlconn = new SqlConnection(sql);

            //Set the SQL statement
            sql = "select MAX(Teacherid) from TableTeacherLogin";

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
                    maxteacherid = sqlread[0].ToString();
                }
            }
            //close the connection
            sqlconn.Close();

            txtTeacherid.Text = (Convert.ToInt32(maxteacherid) + Convert.ToInt32(1)).ToString();
        }

        //Create the clear procedure
        private void clear()
        {
            //Reset all controls
            txtTeachername.ResetText();
            cmbGender.ResetText();
            txtTelno.ResetText();
            txtEmailaddress.ResetText();
            txtPassword.ResetText();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if ((txtTeachername.Text == "") || (txtPassword.Text == "") || (cmbGender.Text == "") || (txtTelno.Text == "") || (txtEmailaddress.Text == ""))
            {
                MessageBox.Show("Please fill all details", "Add Teacher", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(txtTeachername.Text, "^[a-zA-Z ]+$"))
                {
                    MessageBox.Show("Please enter a valid Teacher Name", "Add Teacher", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTeachername.Focus();
                    txtTeachername.SelectAll();
                }
                else
                {
                    if (txtPassword.Text.Length < 5)
                    {
                        MessageBox.Show("Your password must be at least 5 characters long. Please try another", "Add Teacher", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtPassword.Focus();
                        txtPassword.SelectAll();
                    }
                    else
                    {
                        if ((!System.Text.RegularExpressions.Regex.IsMatch(txtTelno.Text, "^[0-9]+$")) || (txtTelno.Text.Length <= 9))
                        {
                            MessageBox.Show("Please enter a valid Telephone Number", "Add Teacher", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtTelno.Focus();
                            txtTelno.SelectAll();
                        }
                        else
                        {
                            if (!System.Text.RegularExpressions.Regex.IsMatch(txtEmailaddress.Text, "^[a-z0-9.@]+$"))
                            {
                                MessageBox.Show("Please enter a valid Email Address", "Add Teacher", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtEmailaddress.Focus();
                                txtEmailaddress.SelectAll();
                            }
                            else
                            {
                                //Using error handler tool
                                try
                                {
                                    //set the update statement
                                    sql = "insert into TableTeacherLogin (Teacherid,Password,Name,TelNo,Gender,EmailAddress) values ('" + txtTeacherid.Text + "','" + txtPassword.Text + "','" + txtTeachername.Text + "','" + txtTelno.Text + "','" + cmbGender.Text + "','" + txtEmailaddress.Text + "')";

                                    //open the connection
                                    sqlconn.Open();
                                    //Assigning the statement in command control
                                    sqlcomm = new SqlCommand(sql, sqlconn);
                                    //Write the record
                                    sqlcomm.ExecuteNonQuery();

                                    //Display message
                                    MessageBox.Show("Details added successfully!", "Teacher details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }

                                catch (Exception ex)
                                {
                                    //Disply error
                                    MessageBox.Show("Error! " + ex.Message, "Teacher Details", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                finally
                                {

                                    //Close the connection
                                    sqlconn.Close();
                                }

                                //Call the clear procedure
                                clear();

                                //Set the SQL statement
                                sql = "select MAX(Teacherid) from TableTeacherLogin";
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
                                        maxteacherid = sqlread[0].ToString();
                                    }
                                }
                                //close the connection
                                sqlconn.Close();

                                txtTeacherid.Text = (Convert.ToInt32(maxteacherid) + Convert.ToInt32(1)).ToString();
                            }
                        }
                    }
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void chkbxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbxShowPassword.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }
    }
}
