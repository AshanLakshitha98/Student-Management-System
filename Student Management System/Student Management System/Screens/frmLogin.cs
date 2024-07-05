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
    public partial class frmLogin : Form
    {
        //Create a public static memory variable
        public static string useridpassing;
        public static string usernamepassing;

        public frmLogin()
        {
            InitializeComponent();

        }
        //Create Instant Variable
        SqlConnection sqlconn;
        SqlCommand sqlcomm;
        SqlDataReader sqlread;

        //Create the memory variable
        string sql;

        private void frmLogin_Load(object sender, EventArgs e)
        {
            //Focus student id text field
            txtUsername.Select();
            //Display announcement
            lblAnnounce.Text = frmAddAnnouncement.Announcement;
            //Set the connection statement
            sql = "Data Source=Ashan\\SQLEXPRESS;Initial Catalog=Login;Integrated Security=True";
            //Assigning the connection
            sqlconn = new SqlConnection(sql);
        }

        private void bttnCancel_Click(object sender, EventArgs e)
        {
            //Display message with yes no buttons
            DialogResult dirRes;
            dirRes = MessageBox.Show("Do you want to exit?", "Login Form", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dirRes == DialogResult.Yes)
            {
                //Exit the program
                Application.Exit();
            }
        }

        private void bttnLogin_Click(object sender, EventArgs e)
        {
            //Set the static variable
            useridpassing = txtUsername.Text;
            //Check Student id text field
            if (txtUsername.Text == string.Empty)
            {
                MessageBox.Show("Student ID is required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Focus();
            }
            else
            {
                //Check Password text field
                if (txtPassword.Text == string.Empty)
                {
                    MessageBox.Show("Password is required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Focus();
                }
                else
                {
                    if (txtUsername.TextLength<6)
                    {
                        MessageBox.Show("Enter valid Student ID!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtUsername.Select();
                        txtUsername.SelectAll();
                    }
                    else
                    { 
                    //Using error handler tool
                    try
                    {
                        //set the SQL statement
                        sql = "select * from TableLogin where Studentid='" + txtUsername.Text + "'";

                        //open the connection
                        sqlconn.Open();
                        //set the statement in command control
                        sqlcomm = new SqlCommand(sql, sqlconn);
                        //read the command
                        sqlread = sqlcomm.ExecuteReader();
                        //Using error handler tool
                        try
                        {
                            //Load the records
                            sqlread.Read();
                            {
                                //Creating memory variable
                                string login = sqlread[1].ToString();
                                usernamepassing = sqlread[2].ToString();


                                //Checking password
                                if (login == txtPassword.Text)

                                {
                                    //Student login
                                    MessageBox.Show("Welcome " + sqlread[2] + "!!", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Hide();
                                    frmStudent df = new frmStudent();
                                    df.Show();
                                }


                                else
                                {
                                    //Clearing password text field if password is wrong
                                    txtPassword.Clear();
                                    MessageBox.Show("Student ID or Password is wrong!", "login Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                            }
                        }
                        catch (Exception ex)
                        {
                            //Disply error
                            txtPassword.Clear();
                            MessageBox.Show("Error!" + ex.Message, "Student Details", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        //display error
                        txtPassword.Clear();
                        MessageBox.Show("Error!" + ex.Message, "Student Details", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        //close the connection
                        sqlconn.Close();
                    }
                }
            }
        }
    }

        private void btnTeachercancel_Click(object sender, EventArgs e)
        {
            //Display message with yes no buttons
            DialogResult dirRes;
            dirRes = MessageBox.Show("Do you want to exit?", "Login Form", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dirRes == DialogResult.Yes)
            {
                //Exit the program
                Application.Exit();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblAnnounce.Left -= 5;
            if (lblAnnounce.Left <= -Width)
            {
                lblAnnounce.Left = Width;
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            //Validate Username
            if (txtUsername.Text.Length > 0)
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(txtUsername.Text, "^[0-9]+$"))
                {
                    MessageBox.Show("Please enter a valid User Id", "Add Marks", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtUsername.Text = txtUsername.Text.Substring(0, txtUsername.Text.Length - 1);
                    txtUsername.Select(5, 0);
                }
            }
        }

        private void btnTeacherlogin_Click(object sender, EventArgs e)
        {
            //Set the static variable
            useridpassing = txtTeacherid.Text;
            //Check Teacher ID text field
            if (txtTeacherid.Text == string.Empty)
            {
                MessageBox.Show("Username is required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTeacherid.Clear();
                txtTeacherid.Focus();
            }
            else
            {

                //Check Password text field
                if (txtTeacherpw.Text == string.Empty)
                {
                    MessageBox.Show("Password is required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTeacherpw.Clear();
                    txtTeacherpw.Focus();
                }
                else

                {
                    if (txtTeacherid.TextLength < 4)
                    {
                        MessageBox.Show("Please enter valid Teacher ID", "Teacher Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtTeacherid.Select();
                        txtTeacherid.SelectAll();
                    }
                    else
                    {
                        //Using error handler tool
                        try
                        {
                            //set the SQL statement
                            sql = "select * from TableTeacherLogin where Teacherid='" + txtTeacherid.Text + "'";

                            //open the connection
                            sqlconn.Open();
                            //set the statement in command control
                            sqlcomm = new SqlCommand(sql, sqlconn);
                            //read the command
                            sqlread = sqlcomm.ExecuteReader();
                            //Using error handler tool
                            try
                            {
                                //Load the records
                                sqlread.Read();
                                {
                                    //Creating memory variable
                                    string login = sqlread[1].ToString();
                                    usernamepassing = sqlread[2].ToString();


                                    //Checking password
                                    if (login == txtTeacherpw.Text)

                                    {
                                        //Student login
                                        MessageBox.Show("Welcome " + sqlread[2] + "!!", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        this.Hide();
                                        frmDashboard df = new frmDashboard();
                                        df.Show();
                                    }

                                    else
                                    {
                                        //Clearing password text field if password is wrong
                                        txtTeacherpw.Clear();
                                        MessageBox.Show("Teacher ID or Password is wrong!", "login Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }

                                }
                            }
                            catch (Exception ex)
                            {
                                //Disply error
                                txtTeacherpw.Clear();
                                MessageBox.Show("Error! " + ex.Message, "Teacher Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            //display error
                            txtTeacherpw.Clear();
                            MessageBox.Show("Error! " + ex.Message, "Teacher Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            //close the connection
                            sqlconn.Close();
                        }
                    }
                }
            }
        }

        private void txtTeacherid_TextChanged(object sender, EventArgs e)
        {
            //Validate Teacher ID
            if (txtTeacherid.Text.Length > 0)
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(txtTeacherid.Text, "^[0-9]+$"))
                {
                    MessageBox.Show("Please enter a valid User Id", "Add Marks", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTeacherid.Text = txtTeacherid.Text.Substring(0, txtTeacherid.Text.Length - 1);
                    txtTeacherid.Select(4, 0);
                }
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtpw.Text == string.Empty)
            {
                MessageBox.Show("Password is required!!", "Admin Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtpw.Select();
            }
            else
            {
                //Using error handler tool
                try
                {
                    //set the SQL statement
                    sql = "select * from TableTeacherLogin where Teacherid='1'";

                    //open the connection
                    sqlconn.Open();
                    //set the statement in command control
                    sqlcomm = new SqlCommand(sql, sqlconn);
                    //read the command
                    sqlread = sqlcomm.ExecuteReader();
                    //Using error handler tool
                    try
                    {
                        //Load the records
                        sqlread.Read();
                        {
                            //Creating memory variable
                            string login = sqlread[1].ToString();
                            useridpassing = sqlread[0].ToString();

                            //Checking password
                            if (login == txtpw.Text)

                            {
                                //Admin login
                                MessageBox.Show("Welcome Admin!!", "Admin Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Hide();
                                frmDashboard dashboard = new frmDashboard();
                                dashboard.Show();
                            }

                            else
                            {
                                //Clearing password text field if password is wrong
                                txtpw.Clear();
                                MessageBox.Show("Password is wrong!", "login Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtpw.Select();
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        //Disply error
                        txtpw.Clear();
                        MessageBox.Show("Error! " + ex.Message, "Admin Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    //display error
                    txtpw.Clear();
                    MessageBox.Show("Error! " + ex.Message, "Admin Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    //close the connection
                    sqlconn.Close();
                }
        }
    }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //Display message with yes no buttons
            DialogResult dirRes;
            dirRes = MessageBox.Show("Do you want to exit?", "Login Form", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dirRes == DialogResult.Yes)
            {
                //Exit the program
                Application.Exit();
            }
        }

        private void txtpw_TextChanged(object sender, EventArgs e)
        {
            txtpw.UseSystemPasswordChar = true;
        }

        private void txtpw_Click(object sender, EventArgs e)
        {
            txtpw.Text = string.Empty;
        }
    }
}
