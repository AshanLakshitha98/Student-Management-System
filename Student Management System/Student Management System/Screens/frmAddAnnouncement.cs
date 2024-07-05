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
    public partial class frmAddAnnouncement : Form
    {
        public frmAddAnnouncement()
        {
            InitializeComponent();
        }

        //Create memory variable
        public static string Announcement;

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtType.Text == string.Empty)
            {
                MessageBox.Show("Please add message first", "Add Announcement", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Announcement = txtType.Text;
                MessageBox.Show("Announcement added successfully", "Add Announcement", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Announcement = "";
            txtType.Text = "";
            MessageBox.Show("Announcement deleted successfully", "Delete Announcement", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void frmAddAnnouncement_Load(object sender, EventArgs e)
        {
            txtType.Text = Announcement;
        }
    }
}
