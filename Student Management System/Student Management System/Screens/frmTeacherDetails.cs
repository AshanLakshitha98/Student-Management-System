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
    public partial class frmTeacherDetails : Form
    {
        public frmTeacherDetails()
        {
            InitializeComponent();
        }
        //Create Instant Variable
        SqlConnection sqlconn;
        SqlCommand sqlcomm;
        SqlDataReader sqlread;

        //Create the memory variable
        string sql;

        private void frmTeacherDetails_Load(object sender, EventArgs e)
        {
            txtTeacherid.Text = frmLogin.useridpassing;
            //Set the connection statement
            sql = "Data Source=Ashan\\SQLEXPRESS;Initial Catalog=Login;Integrated Security=True";
            //Assigning the connection
            sqlconn = new SqlConnection(sql);

            //set the SQL statement
            sql = "select * from TableTeacherLogin where Teacherid='" + txtTeacherid.Text + "'";

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
                    txtTeachername.Text = sqlread[2].ToString();
                    cmbGender.Text = sqlread[4].ToString();
                    txtTelno.Text = sqlread[3].ToString();
                    txtEmailAddress.Text = sqlread[5].ToString();
                }
            }
            //close the connection
            sqlconn.Close(); 
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Enable the text fiels
            txtTeachername.Enabled = true;
            cmbGender.Enabled = true;
            txtTelno.Enabled = true;
            txtEmailAddress.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if ((txtTeachername.Text == "") || (cmbGender.Text == "") || (txtTelno.Text == "") || (txtEmailAddress.Text == ""))
            {
                MessageBox.Show("Please fill all details", "Edit Teacher Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(txtTeachername.Text, "^[a-zA-Z ]+$"))
                {
                    MessageBox.Show("Please enter a valid Name", "Edit Teacher Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTeachername.Focus();
                    txtTeachername.SelectAll();
                }
                else
                {

                    if ((!System.Text.RegularExpressions.Regex.IsMatch(txtTelno.Text, "^[0-9]+$")) || (txtTelno.Text.Length <= 9))
                    {
                        MessageBox.Show("Please enter a valid Telephone Number", "Edit Teacher Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtTelno.Focus();
                        txtTelno.SelectAll();
                    }
                    else
                    {
                        if (!System.Text.RegularExpressions.Regex.IsMatch(txtEmailAddress.Text, "^[a-z0-9.@]+$"))
                        {
                            MessageBox.Show("Please enter a valid Email Address", "Edit Teacher Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtEmailAddress.Focus();
                            txtEmailAddress.SelectAll();
                        }
                        else
                        {
                            //Display message
                            DialogResult diRes;
                            diRes = MessageBox.Show("Do you want to save your new records?", "Update details", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (diRes == DialogResult.Yes)
                            {
                                //Using error handler tool
                                try
                                {
                                    //set the update statement
                                    sql = "update TableTeacherLogin set Name='" + txtTeachername.Text + "',TelNo='" + txtTelno.Text + "',Gender='" + cmbGender.Text + "',EmailAddress='" + txtEmailAddress.Text + "' where Teacherid='" + txtTeacherid.Text + "'";

                                    //open the connection
                                    sqlconn.Open();
                                    //Assigning the statement in command control
                                    sqlcomm = new SqlCommand(sql, sqlconn);
                                    //Write the record
                                    sqlcomm.ExecuteNonQuery();

                                    //Display message
                                    MessageBox.Show("Details updated successfully!", "Edit Teacher Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }

                                catch (Exception ex)
                                {
                                    //Disply error
                                    MessageBox.Show("Error! " + ex.Message, "Edit Teacher Details", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                finally
                                {

                                    //Close the connection
                                    sqlconn.Close();
                                }

                                //Disable the text fiels
                                txtTeachername.Enabled = false;
                                cmbGender.Enabled = false;
                                txtTelno.Enabled = false;
                                txtEmailAddress.Enabled = false;
                            }

                            else
                            {
                                //Display message
                                MessageBox.Show("Update Canceled!", "Edit Teacher Details", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                                //set the SQL statement
                                sql = "select * from TableTeacherLogin where Teacherid='" + txtTeacherid.Text + "'";

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
                                        txtTeachername.Text = sqlread[2].ToString();
                                        cmbGender.Text = sqlread[4].ToString();
                                        txtTelno.Text = sqlread[3].ToString();
                                        txtEmailAddress.Text = sqlread[5].ToString();
                                    }
                                }
                                //close the connection
                                sqlconn.Close();


                                //Disable the text fiels
                                txtTeachername.Enabled = false;
                                cmbGender.Enabled = false;
                                txtTelno.Enabled = false;
                                txtEmailAddress.Enabled = false;
                            }

                            btnSave.Enabled = false;
                        }
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void txtTeachername_TextChanged(object sender, EventArgs e)
        {
            if (txtTeachername.Enabled)
            {
                btnSave.Enabled = true;
            }
        }

        private void cmbGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtTeachername.Enabled)
            {
                btnSave.Enabled = true;
            }
        }

        private void txtTelno_TextChanged(object sender, EventArgs e)
        {
            if (txtTeachername.Enabled)
            {
                btnSave.Enabled = true;
            }
        }

        private void txtEmailAddress_TextChanged(object sender, EventArgs e)
        {
            if (txtTeachername.Enabled)
            {
                btnSave.Enabled = true;
            }
        }
    }
}
