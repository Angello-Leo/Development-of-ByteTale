using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Final_Project___CGC_Sage
{
    public partial class TitleScreen : Form
    {
        private SoundPlayer titleSound;
        private Timer Timing;
        public TitleScreen()
        {
            this.WindowState = FormWindowState.Maximized;
            InitializeComponent();
            label1.Visible = false;
            label2.Visible = false;
            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;
        }

        private void TextTimer_Tick(object sender, EventArgs e)
        {
            textTimer.Stop(); // or Timing.Stop() if you used that name
            label1.Visible = true;
            label2.Visible = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (label1.Visible && label2.Visible)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    Login_Form Login = new Login_Form();
                    Login.Show();
                    this.Hide();
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void TitleScreen_Load(object sender, EventArgs e)
        {
            try
            {
                // Load and play sound
                System.Media.SoundPlayer sfx = new System.Media.SoundPlayer(Properties.Resources.Title);
                sfx.Play();

                // Set up a timer to show the text
                textTimer = new Timer();
                textTimer.Interval = 1000; // time in milliseconds (1.5 seconds)
                textTimer.Tick += TextTimer_Tick;
                textTimer.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error playing title screen sound: " + ex.Message);
            }
        }
    }
}
