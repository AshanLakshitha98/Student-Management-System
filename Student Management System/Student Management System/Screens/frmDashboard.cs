using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_Management_System.Screens
{
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();
        }


        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmAddNewStudent ab = new frmAddNewStudent();
            ab.ShowDialog(this);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            frmEditStudentDetails cd = new frmEditStudentDetails();
            cd.ShowDialog(this);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            //Display message with yes no buttons
            DialogResult dirRes;
            dirRes = MessageBox.Show("Do you want to Log Out?", "Dashboard", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dirRes == DialogResult.Yes)
            {
                //Exit the program
                this.Hide();
                frmLogin ab = new frmLogin();
                ab.ShowDialog(this);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            frmAddExamMarks cd = new frmAddExamMarks();
            cd.ShowDialog(this);
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            frmAddAnnouncement ab = new frmAddAnnouncement();
            ab.ShowDialog(this);
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            if (frmLogin.useridpassing == "1")
            {
                btnAddTeacher.Enabled = true;
            }
        }

        private void btnEditTeacherProfile_Click(object sender, EventArgs e)
        {
            if (frmLogin.useridpassing =="1")
            {
                frmEditTeacherProfile bb = new frmEditTeacherProfile();
                bb.ShowDialog(this);
            }
            else
            {
                frmTeacherDetails cc = new frmTeacherDetails();
                cc.ShowDialog(this);
            }
        }

        private void btnAddTeacher_Click(object sender, EventArgs e)
        {
            frmAddTeacher aa = new frmAddTeacher();
            aa.ShowDialog(this);
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            if (frmLogin.useridpassing == "1")
            {
                frmChangePasswordAdmin bb = new frmChangePasswordAdmin();
                bb.ShowDialog(this);
            }
            else
            {
                frmChangePasswordTeacher cc = new frmChangePasswordTeacher();
                cc.ShowDialog(this);
            }
        }
    }
}
