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
    public partial class frmAddNewStudent : Form
    {
        public frmAddNewStudent()
        {
            InitializeComponent();
        }
        //Create Instant Variable
        SqlConnection sqlconn;
        SqlCommand sqlcomm;
        SqlDataReader sqlread;

        //Create the memory variable
        string maxstudentid;
        string sql;

        private void frmAddNewStudent_Load(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
            txtSdudentname.Select();
            //Set the connection statement
            sql = "Data Source=Ashan\\SQLEXPRESS;Initial Catalog=Login;Integrated Security=True";
            //Assigning the connection
            sqlconn = new SqlConnection(sql);

            //Set the SQL statement
            sql = "select MAX(Studentid) from TableLogin";

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
                    maxstudentid = sqlread[0].ToString();
                }
            }
            //close the connection
            sqlconn.Close();

            txtStudentid.Text = (Convert.ToInt32(maxstudentid) + Convert.ToInt32(1)).ToString();

        }

        //Create the clear procedure
        private void clear()
        {
            //Reset all controls
            txtSdudentname.ResetText();
            txtAddress.ResetText();
            dtpDOB.ResetText();
            cmbGender.ResetText();
            txtTelno.ResetText();
            txtParentsname.ResetText();
            txtPassword.ResetText();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if ((txtSdudentname.Text==string.Empty) || (txtPassword.Text== string.Empty) || (txtAddress.Text== string.Empty) || (cmbGender.Text== string.Empty) || (txtTelno.Text== string.Empty) || (txtParentsname.Text== string.Empty))
            {
                MessageBox.Show("Please fill all details", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(txtSdudentname.Text, "^[a-zA-Z ]+$"))
                {
                    MessageBox.Show("Please enter a valid Student Name", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSdudentname.Focus();
                    txtSdudentname.SelectAll();
                }
                else
                {
                    if (txtPassword.Text.Length<5)
                    {
                        MessageBox.Show("Your password must be at least 5 characters long. Please try another","Add Student",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        txtPassword.Focus();
                        txtPassword.SelectAll();
                    }
                    else
                    {
                        if ((!System.Text.RegularExpressions.Regex.IsMatch(txtTelno.Text, "^[0-9]+$")) || (txtTelno.Text.Length<=9))
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
                                //Using error handler tool
                                try
                                {
                                    //set the update statement
                                    sql = "insert into TableLogin (Studentid,Password,Name,Address,TelNo,Gender,DOB,Parentsname) values ('" + txtStudentid.Text + "','" + txtPassword.Text + "','" + txtSdudentname.Text + "','" + txtAddress.Text + "','" + txtTelno.Text + "','" + cmbGender.Text + "','" + dtpDOB.Text + "','" + txtParentsname.Text + "')";

                                    //open the connection
                                    sqlconn.Open();
                                    //Assigning the statement in command control
                                    sqlcomm = new SqlCommand(sql, sqlconn);
                                    //Write the record
                                    sqlcomm.ExecuteNonQuery();

                                    //Display message
                                    MessageBox.Show("Details added successfully!", "Student details", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                                //Call the clear procedure
                                clear();

                                //Set the SQL statement
                                sql = "select MAX(Studentid) from TableLogin";
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
                                        maxstudentid = sqlread[0].ToString();
                                    }
                                }
                                //close the connection
                                sqlconn.Close();

                                txtStudentid.Text = (Convert.ToInt32(maxstudentid) + Convert.ToInt32(1)).ToString();
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
