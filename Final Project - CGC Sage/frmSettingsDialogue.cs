using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project___CGC_Sage
{
    public partial class frmSettingsDialogue : Form
    {
        private string currentUsername;
        public event Action OnSettingsDialogClosed;
        public frmSettingsDialogue(string username)
        {
            InitializeComponent();
            this.currentUsername = username;

            if (username == "ALZ")
            {
                lblAdmin.Visible = true;
            }
            else
            {
                lblAdmin.Visible = false;   
            }
            this.FormClosing += FrmSettingsDialogue_FormClosing;
        }
        private void FrmSettingsDialogue_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Trigger event when dialog is closing
            OnSettingsDialogClosed?.Invoke();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmSettingsDialogue_Load(object sender, EventArgs e)
        {
            
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.C)
            {
                this.Close();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {
            frmLeaderbords leaderbords = new frmLeaderbords();
            leaderbords.Show();
            this.Close();
        }

        private void lblAdmin_Click(object sender, EventArgs e)
        {
            UsersDb usersData = new UsersDb();
            usersData.ShowDialog(this); 
            //OnSettingsDialogClosed?.Invoke();
            this.Close();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
