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
    public partial class frmStudentDetails : Form
    {
        public frmStudentDetails()
        {
            InitializeComponent();
        }
        //Create Instant Variable
        SqlConnection sqlconn;
        SqlCommand sqlcomm;
        SqlDataReader sqlread;

        //Create the memory variable
        string sql;

        private void frmStudentDetails_Load(object sender, EventArgs e)
        {
            txtStudentid.Text = frmLogin.useridpassing;
            //Set the connection statement
            sql = "Data Source=Ashan\\SQLEXPRESS;Initial Catalog=Login;Integrated Security=True";
            //Assigning the connection
            sqlconn = new SqlConnection(sql);

            //set the SQL statement
            sql = "select * from TableLogin where Studentid='" + txtStudentid.Text + "'";

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
                    txtSdudentname.Text = sqlread[2].ToString();
                    txtAddress.Text = sqlread[4].ToString();
                    dtpDOB.Text = sqlread[7].ToString();
                    cmbGender.Text = sqlread[6].ToString();
                    txtTelno.Text = sqlread[5].ToString();
                    txtParentsname.Text = sqlread[8].ToString();
                }
            }
            //close the connection
            sqlconn.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Enable the text fiels
            txtSdudentname.Enabled = true;
            txtAddress.Enabled = true;
            dtpDOB.Enabled = true;
            cmbGender.Enabled = true;
            txtTelno.Enabled = true;
            txtParentsname.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if ((txtSdudentname.Text == "") || (txtAddress.Text == "") || (cmbGender.Text == "") || (txtTelno.Text == "") || (txtParentsname.Text == ""))
            {
                MessageBox.Show("Please fill all details", "Edit Student Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(txtSdudentname.Text, "^[a-zA-Z ]+$"))
                {
                    MessageBox.Show("Please enter a valid Student Name", "Edit Student Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSdudentname.Focus();
                    txtSdudentname.SelectAll();
                }
                else
                {

                    if ((!System.Text.RegularExpressions.Regex.IsMatch(txtTelno.Text, "^[0-9]+$")) || (txtTelno.Text.Length <= 9))
                    {
                        MessageBox.Show("Please enter a valid Telephone Number", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtTelno.Focus();
                        txtTelno.SelectAll();
                    }
                    else
                    {
                        if (!System.Text.RegularExpressions.Regex.IsMatch(txtParentsname.Text, "^[a-zA-Z ]+$"))
                        {
                            MessageBox.Show("Please enter a valid Parents' Name", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtParentsname.Focus();
                            txtParentsname.SelectAll();
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
                                    sql = "update TableLogin set Name='" + txtSdudentname.Text + "',Address='" + txtAddress.Text + "',TelNo='" + txtTelno.Text + "',Gender='" + cmbGender.Text + "',DOB='" + dtpDOB.Text + "',Parentsname='" + txtParentsname.Text + "' where Studentid='" + txtStudentid.Text + "'";

                                    //open the connection
                                    sqlconn.Open();
                                    //Assigning the statement in command control
                                    sqlcomm = new SqlCommand(sql, sqlconn);
                                    //Write the record
                                    sqlcomm.ExecuteNonQuery();

                                    //Display message
                                    MessageBox.Show("Details updated successfully!", "Student details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }

                                catch (Exception ex)
                                {
                                    //Disply error
                                    MessageBox.Show("Error! " + ex.Message, "Student Details", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                finally
                                {

                                    //Close the connection
                                    sqlconn.Close();
                                }

                                //Disable the text fiels
                                txtSdudentname.Enabled = false;
                                txtAddress.Enabled = false;
                                dtpDOB.Enabled = false;
                                cmbGender.Enabled = false;
                                txtTelno.Enabled = false;
                                txtParentsname.Enabled = false;
                            }

                            else
                            {
                                //Display message
                                MessageBox.Show("Update Canceled!", "Student details", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                                //set the SQL statement
                                sql = "select * from TableLogin where Studentid='" + txtStudentid.Text + "'";

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
                                        txtSdudentname.Text = sqlread[2].ToString();
                                        txtAddress.Text = sqlread[4].ToString();
                                        dtpDOB.Text = sqlread[7].ToString();
                                        cmbGender.Text = sqlread[6].ToString();
                                        txtTelno.Text = sqlread[5].ToString();
                                        txtParentsname.Text = sqlread[8].ToString();
                                    }
                                }
                                //close the connection
                                sqlconn.Close();


                                //Disable the text fiels
                                txtSdudentname.Enabled = false;
                                txtAddress.Enabled = false;
                                dtpDOB.Enabled = false;
                                cmbGender.Enabled = false;
                                txtTelno.Enabled = false;
                                txtParentsname.Enabled = false;
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

        private void txtSdudentname_TextChanged(object sender, EventArgs e)
        {
            if (txtSdudentname.Enabled)
            {
                btnSave.Enabled = true;
            }
        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
            if (txtSdudentname.Enabled)
            {
                btnSave.Enabled = true;
            }
        }

        private void dtpDOB_ValueChanged(object sender, EventArgs e)
        {
            if (txtSdudentname.Enabled)
            {
                btnSave.Enabled = true;
            }
        }

        private void cmbGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtSdudentname.Enabled)
            {
                btnSave.Enabled = true;
            }
        }

        private void txtTelno_TextChanged(object sender, EventArgs e)
        {
            if (txtSdudentname.Enabled)
            {
                btnSave.Enabled = true;
            }
        }

        private void txtParentsname_TextChanged(object sender, EventArgs e)
        {
            if (txtSdudentname.Enabled)
            {
                btnSave.Enabled = true;
            }
        }
    }
}
