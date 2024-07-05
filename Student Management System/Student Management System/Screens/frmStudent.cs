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
    public partial class frmStudent : Form
    {
        public frmStudent()
        {
            InitializeComponent();
        }

        //Create Instant Variable
        SqlConnection sqlconn;
        SqlCommand sqlcomm;
        SqlDataReader sqlread;

        //Create the memory variable
        string sql;

        private void frmStudent_Load(object sender, EventArgs e)
        {
            //Auto fill Student ID
            lblStudentid.Text = "Student ID: " + frmLogin.useridpassing;
            //Autofill Name
            lblName.Text = "Name: " + frmLogin.usernamepassing;
            //Set the connection statement
            sql = "Data Source=Ashan\\SQLEXPRESS;Initial Catalog=Login;Integrated Security=True";
            //Assigning the connection
            sqlconn = new SqlConnection(sql);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmStudentDetails ab = new frmStudentDetails();
            ab.ShowDialog(this);

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            frmExamMarks cd = new frmExamMarks();
            cd.ShowDialog(this);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            frmChangePassword ef = new frmChangePassword();
            ef.ShowDialog(this);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            DialogResult diRes;
            diRes = MessageBox.Show("Do you want to Log out?", "Student Login", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (diRes == DialogResult.Yes)
            {
                this.Hide();
                frmLogin gh = new frmLogin();
                gh.Show();
            }
        }
    }
}
