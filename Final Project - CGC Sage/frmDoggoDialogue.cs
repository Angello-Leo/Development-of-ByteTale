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
    public partial class frmDoggoDialogue : Form
    {
        string fullText1 = "This Application is inspired by TobyFox\r\n";
        int currentCharIndex = 0;
        string fullText2 = "(Creator and Developer of Undertale)";
        int currentCharIndex2 = 0;
        string fullText3 = "Press \"C\" to exit..";
        int currentCharIndex3 = 0;
        public frmDoggoDialogue()
        {
            InitializeComponent();

            this.Width = 800;
            this.Height = 200;
            this.FormBorderStyle = FormBorderStyle.None;

            this.StartPosition = FormStartPosition.Manual;

            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;

            this.Location = new Point(350, 500);
        }

        private void frmDoggoDialogue_Load(object sender, EventArgs e)
        {
            StartTypingEffect();
        }

        private void typingTimer_Tick(object sender, EventArgs e)
        {
            bool anyTextLeft = false;

            if (currentCharIndex < fullText1.Length)
            {
                lblToby.Text += fullText1[currentCharIndex];
                currentCharIndex++;
                anyTextLeft = true;
            }
            else if (currentCharIndex2 < fullText2.Length)
            {
                lblDev.Text += fullText2[currentCharIndex2];
                currentCharIndex2++;
                anyTextLeft = true;
            }
            else if (currentCharIndex3 < fullText3.Length)
            {
                lblInstructions.Text += fullText3[currentCharIndex3];
                currentCharIndex3++;
                anyTextLeft = true;
            }

            if (!anyTextLeft)
            {
                typingTimer.Stop();
            }
        }
        private void StartTypingEffect()
        {
            lblToby.Text = "";
            lblDev.Text = "";
            lblInstructions.Text = "";

            currentCharIndex = 0;
            currentCharIndex2 = 0;
            currentCharIndex3 = 0;

            typingTimer.Interval = 20;
            typingTimer.Tick += typingTimer_Tick; // Ensure it's only added once
            typingTimer.Start();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.C)
            {
                this.Close();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
