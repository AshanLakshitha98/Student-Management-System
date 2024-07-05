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
    public partial class frmAddExamMarks : Form
    {
        public frmAddExamMarks()
        {
            InitializeComponent();
        }
        //Create Instant Variable
        SqlConnection sqlconn;
        SqlCommand sqlcomm;
        SqlDataReader sqlread;

        //Create the memory variable
        string sql;

        private void frmAddExamMarks_Load(object sender, EventArgs e)
        {
            //Select old password text field
            txtUserid.Select();
            //Set the connection statement
            sql = "Data Source=Ashan\\SQLEXPRESS;Initial Catalog=Login;Integrated Security=True";
            //Assigning the connection
            sqlconn = new SqlConnection(sql);
        }
        private void clear()
        {
            txt1Marks.ResetText();
            txt1Note.ResetText();
            txt2Marks.ResetText();
            txt2Note.ResetText();
            txt3Marks.ResetText();
            txt3Note.ResetText();
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            if ((txtUserid.Text == "") || (txtUserid.Text.Length < 6))
            {
                MessageBox.Show("Please enter correct Student ID", "Add Exam Marks", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUserid.Select();
            }
            else
            {
                //Using the error handler tool
                try
                {
                    //set the SQL statement
                    sql = "select * from TableMarks where Studentid='" + txtUserid.Text + "'";

                    //open the connection
                    sqlconn.Open();
                    //set the statement in command control
                    sqlcomm = new SqlCommand(sql, sqlconn);
                    //read the command
                    sqlread = sqlcomm.ExecuteReader();

                    //Using the error handler tool
                    try
                    {

                        //Load the records
                        sqlread.Read();
                        {
                            //Assigning the Values
                            txt1Marks.Text = sqlread[1].ToString();
                            txt2Marks.Text = sqlread[2].ToString();
                            txt3Marks.Text = sqlread[3].ToString();
                            txt1Note.Text = sqlread[4].ToString();
                            txt2Note.Text = sqlread[5].ToString();
                            txt3Note.Text = sqlread[6].ToString();

                        }
                    }
                    catch (Exception ex)
                    {
                        //Disply error
                        MessageBox.Show("Error! " + ex.Message, "Exam Marks", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtUserid.Select();
                        clear();
                    }
                }
                catch (Exception ex)
                {
                    //Disply error
                    MessageBox.Show("Error! " + ex.Message, "Exam Marks", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUserid.Select();
                    clear();
                }
                finally
                {
                    //close the connection
                    sqlconn.Close();
                }
            }
            if ((txt1Marks.Text != "") || (txt1Note.Text != "") || (txt2Marks.Text != "") || (txt3Marks.Text != "") || (txt2Note.Text != "") || (txt3Note.Text != ""))
            {
                btnUpdate.Enabled = true;

                if ((txt1Marks.Text!="0") || (txt2Marks.Text!="0") || (txt3Marks.Text!="0"))
                {
                    btnDelete.Enabled = true;
                }
            }
            else
            {
                btnAdd.Enabled = true;
            }
        }

        private void txt1Marks_TextChanged(object sender, EventArgs e)
        {
            //Validate marks
            if (txt1Marks.Text.Length > 0)
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(txt1Marks.Text, "^[0-9]+$"))
                {
                    MessageBox.Show("Please enter a valid Marks", "Add Marks", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt1Marks.Text = txt1Marks.Text.Substring(0, txt1Marks.Text.Length - 1);
                    txt1Marks.Select(2, 0);
                }
                else
                {
                    int txt1Marks_int = 0;
                    Int32.TryParse(txt1Marks.Text, out txt1Marks_int);
                    if (txt1Marks_int > 100)
                    {
                        MessageBox.Show("Enter valid marks", "Add Marks", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt1Marks.Text = txt1Marks.Text.Substring(0, txt1Marks.Text.Length - 1);
                        txt1Marks.Select(2, 0);
                    }
                }
            }
        }

        private void txt2Marks_TextChanged(object sender, EventArgs e)
        {
            //Validate marks
            if (txt2Marks.Text.Length > 0)
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(txt2Marks.Text, "^[0-9]+$"))
                {
                    MessageBox.Show("Please enter a valid Marks", "Add Marks", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt2Marks.Text = txt2Marks.Text.Substring(0, txt2Marks.Text.Length - 1);
                    txt2Marks.Select(2, 0);
                }
                else
                {
                    int txt1Marks_int = 0;
                    Int32.TryParse(txt2Marks.Text, out txt1Marks_int);
                    if (txt1Marks_int > 100)
                    {
                        MessageBox.Show("Enter valid marks", "Add Marks", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt2Marks.Text = txt2Marks.Text.Substring(0, txt2Marks.Text.Length - 1);
                        txt2Marks.Select(2, 0);
                    }
                }
            }
        }

        private void txt3Marks_TextChanged(object sender, EventArgs e)
        {
            //Validate marks
            if (txt3Marks.Text.Length > 0)
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(txt3Marks.Text, "^[0-9]+$"))
                {
                    MessageBox.Show("Please enter a valid Marks", "Add Marks", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt3Marks.Text = txt3Marks.Text.Substring(0, txt3Marks.Text.Length - 1);
                    txt3Marks.Select(2, 0);
                }
                else
                {
                    int txt1Marks_int = 0;
                    Int32.TryParse(txt3Marks.Text, out txt1Marks_int);
                    if (txt1Marks_int > 100)
                    {
                        MessageBox.Show("Enter valid marks", "Add Marks", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt3Marks.Text = txt3Marks.Text.Substring(0, txt3Marks.Text.Length - 1);
                        txt3Marks.Select(2, 0);
                    }
                }
            }
        }

        private void txtUserid_TextChanged(object sender, EventArgs e)
        {
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            btnAdd.Enabled = false;

            //Validate marks
            if (txtUserid.Text.Length > 0)
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(txtUserid.Text, "^[0-9]+$"))
                {
                    MessageBox.Show("Please enter a valid User ID", "Exam Marks", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtUserid.Text = txtUserid.Text.Substring(0, txtUserid.Text.Length - 1);
                    txtUserid.Select(5, 0);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if ((txtUserid.Text == "") || (txtUserid.Text.Length < 6))
            {
                MessageBox.Show("Please enter correct Student ID", "Add Exam Marks", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUserid.Select();
            }
            else
            if ((txt1Marks.Text == string.Empty) && (txt1Note.Text == string.Empty) && (txt2Marks.Text == string.Empty) && (txt2Note.Text == string.Empty) && (txt3Marks.Text == string.Empty) && (txt3Note.Text == string.Empty))
            {
                MessageBox.Show("Please Add marks first", "Add Marks", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                //Using error handler tool
                try
                {
                    //set the update statement
                    sql = "update TableMarks set [1stTermMarks]='" + txt1Marks.Text + "',[2ndTermMarks]='" + txt2Marks.Text + "',[3rdTermMarks]='" + txt3Marks.Text + "',[1stNote]='" + txt1Note.Text + "',[2ndNote]='" + txt2Note.Text + "',[3rdNote]='" + txt3Note.Text + "' where Studentid='" + txtUserid.Text + "'";
                    //open the connection
                    sqlconn.Open();
                    //Assigning the statement in command control
                    sqlcomm = new SqlCommand(sql, sqlconn);
                    //Write the record
                    sqlcomm.ExecuteNonQuery();

                    //Display message
                    MessageBox.Show("Marks updated successfully!", "Exam Marks", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear();
                    btnUpdate.Enabled = false;
                    txtUserid.Select();
                }

                catch (Exception ex)
                {
                    //Disply error
                    MessageBox.Show("Error! Student ID isn't valid " + ex.Message, "Exam Marks", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    clear();
                }
                finally
                {

                    //Close the connection
                    sqlconn.Close();
                }
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult diRes;
            diRes = MessageBox.Show("Do you want to delete records?", "Exam Marks", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (diRes == DialogResult.Yes)
            {
                //Using error handler tool
                try
                {
                    //set the update statement
                    sql = "update TableMarks set [1stTermMarks]='' ,[2ndTermMarks]='' ,[3rdTermMarks]='',[1stNote]='',[2ndNote]='',[3rdNote]='' where Studentid='" + txtUserid.Text + "'";
                    //open the connection
                    sqlconn.Open();
                    //Assigning the statement in command control
                    sqlcomm = new SqlCommand(sql, sqlconn);
                    //Write the record
                    sqlcomm.ExecuteNonQuery();

                    //Display message
                    MessageBox.Show("Marks deleted successfully!", "Exam Marks", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnDelete.Enabled = false;
                }

                catch (Exception ex)
                {
                    //Disply error
                    MessageBox.Show("Error! Student ID isn't valid " + ex.Message, "Exam Marks", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    clear();
                }
                finally
                {

                    //Close the connection
                    sqlconn.Close();
                }
                clear();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if ((txt1Marks.Text == string.Empty) && (txt1Note.Text == string.Empty) && (txt2Marks.Text == string.Empty) && (txt2Note.Text == string.Empty) && (txt3Marks.Text == string.Empty) && (txt3Note.Text == string.Empty))
            {
                MessageBox.Show("Please Add marks first", "Add Marks", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                //Using error handler tool
                try
                {
                    //set the update statement
                    sql = "insert into TableMarks values ('" + txtUserid.Text + "','" + txt1Marks.Text + "','" + txt2Marks.Text + "','" + txt3Marks.Text + "','" + txt1Note.Text + "','" + txt2Note.Text + "','" + txt3Note.Text + "')";

                    //open the connection
                    sqlconn.Open();
                    //Assigning the statement in command control
                    sqlcomm = new SqlCommand(sql, sqlconn);
                    //Write the record
                    sqlcomm.ExecuteNonQuery();

                    //Display message
                    MessageBox.Show("Marks added successfully!", "Student Marks", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnAdd.Enabled = false;
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


            }
        }

        private void txt1Marks_Click(object sender, EventArgs e)
        {
            if (txt1Marks.Text == "0")
            {
                txt1Marks.Text = "";
            }
        }

        private void txt2Marks_Click(object sender, EventArgs e)
        {
            if (txt2Marks.Text == "0")
            {
                txt2Marks.Text = "";
            }
        }

        private void txt3Marks_Click(object sender, EventArgs e)
        {
            if (txt3Marks.Text == "0")
            {
                txt3Marks.Text = "";
            }
        }
    }
}
            
        
    

