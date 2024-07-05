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
    public partial class frmExamMarks : Form
    {
        public frmExamMarks()
        {
            InitializeComponent();
        }
        //Create Instant Variable
        SqlConnection sqlconn;
        SqlCommand sqlcomm;
        SqlDataReader sqlread;

        //Create the memory variable
        string sql;

        private void frmExamMarks_Load(object sender, EventArgs e)
        {
            //Set the connection statement
            sql = "Data Source=Ashan\\SQLEXPRESS;Initial Catalog=Login;Integrated Security=True";
            //Assigning the connection
            sqlconn = new SqlConnection(sql);

            //set the SQL statement
            sql = "select * from TableMarks where Studentid='" + frmLogin.useridpassing + "'";

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
                    txt1Marks.Text = sqlread[1].ToString();
                    txt2Marks.Text = sqlread[2].ToString();
                    txt3Marks.Text = sqlread[3].ToString();
                    txt1Note.Text = sqlread[4].ToString();
                    txt2Note.Text = sqlread[5].ToString();
                    txt3Note.Text = sqlread[6].ToString();
                }
            }
            //close the connection
            sqlconn.Close();

            //Assigning grades
            int txt1Marks_int = 0;
            Int32.TryParse(txt1Marks.Text, out txt1Marks_int);
            if (txt1Marks_int>=75)
            {
                txt1Grade.Text = "A";
            }
            else
            {
                if (txt1Marks_int>=65)
                {
                    txt1Grade.Text = "B";
                }
                else
                {
                    if (txt1Marks_int>=55)
                    {
                        txt1Grade.Text = "C";
                    }
                    else
                    {
                        if (txt1Marks_int>=35)
                        {
                            txt1Grade.Text = "S";
                        }
                        else
                        {
                            txt1Grade.Text = "F";
                        }
                    }
                }
            }

            //Assigning grades
            int txt2Marks_int = 0;
            Int32.TryParse(txt2Marks.Text, out txt2Marks_int);
            if (txt2Marks_int >= 75)
            {
                txt2Grade.Text = "A";
            }
            else
            {
                if (txt2Marks_int >= 65)
                {
                    txt2Grade.Text = "B";
                }
                else
                {
                    if (txt2Marks_int >= 55)
                    {
                        txt2Grade.Text = "C";
                    }
                    else
                    {
                        if (txt2Marks_int >= 35)
                        {
                            txt2Grade.Text = "S";
                        }
                        else
                        {
                            txt2Grade.Text = "F";
                        }
                    }
                }
            }

            //Assigning grades
            int txt3Marks_int = 0;
            Int32.TryParse(txt3Marks.Text, out txt3Marks_int);
            if (txt3Marks_int >= 75)
            {
                txt3Grade.Text = "A";
            }
            else
            {
                if (txt3Marks_int >= 65)
                {
                    txt3Grade.Text = "B";
                }
                else
                {
                    if (txt3Marks_int >= 55)
                    {
                        txt3Grade.Text = "C";
                    }
                    else
                    {
                        if (txt3Marks_int >= 35)
                        {
                            txt3Grade.Text = "S";
                        }
                        else
                        {
                            txt3Grade.Text = "F";
                        }
                    }
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
