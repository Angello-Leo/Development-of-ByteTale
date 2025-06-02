using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Final_Project___CGC_Sage
{
    public partial class frmReturningFromCareerPlan : Form
    {
        private List<string> dialogueLines;
        private int currentLineIndex = 0;
        private Timer typingTimer;
        private string fullTextToType = "";
        private int currentCharIndex = 0;
        private Action onTypingComplete;

        public frmReturningFromCareerPlan()
        {
            InitializeComponent();

            typingTimer = new Timer();
            typingTimer.Interval = 30; // milliseconds per character
            typingTimer.Tick += TypingTimer_Tick;

            // Sample dialogue lines
            dialogueLines = new List<string>
            {
                "Interesting, very interesting...",
                "You are definitely something special, child.",
                "If only I haven't....",
                "Ahem.",
                "Anyways, if you need some more counseling, just talk to me again."
            };

            this.Load += frmReturningFromCareerPlan_Load;
        }

        private void frmReturningFromCareerPlan_Load(object sender, EventArgs e)
        {
            this.Location = new Point(350, 500);
            ShowCurrentLine();
        }

        private void ShowCurrentLine()
        {
            if (currentLineIndex < dialogueLines.Count)
            {
                // Set label size and position
                lblDialogue.MaximumSize = new Size(500, 0);
                lblDialogue.Size = new Size(500, 0);
                lblDialogue.Left = 350;
                lblDialogue.Top = 100;

                StartTyping(dialogueLines[currentLineIndex]);
            }
        }

        private void StartTyping(string text, Action onComplete = null)
        {
            typingTimer.Stop();
            fullTextToType = text;
            lblDialogue.Text = "";
            currentCharIndex = 0;
            onTypingComplete = onComplete;
            typingTimer.Start();
        }

        private void TypingTimer_Tick(object sender, EventArgs e)
        {
            if (currentCharIndex < fullTextToType.Length)
            {
                lblDialogue.Text += fullTextToType[currentCharIndex];
                currentCharIndex++;
            }
            else
            {
                typingTimer.Stop();

                if (onTypingComplete != null)
                {
                    var callback = onTypingComplete;
                    onTypingComplete = null;
                    callback();
                }
                else
                {
                    lblGuide.Text = "Press \"Z\" to Continue";
                    lblGuide.Top = lblDialogue.Bottom + 10;
                    lblGuide.Left = 350;
                    lblGuide.Visible = true;
                }
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Z)
            {
                if (typingTimer.Enabled)
                {
                    // Skip animation
                    typingTimer.Stop();
                    lblDialogue.Text = fullTextToType;
                    lblGuide.Text = "Press \"Z\" to Continue";
                    lblGuide.Top = lblDialogue.Bottom + 10;
                    lblGuide.Left = 350;
                    lblGuide.Visible = true;
                }
                else
                {
                    lblGuide.Visible = false;
                    currentLineIndex++;

                    if (currentLineIndex < dialogueLines.Count)
                    {
                        ShowCurrentLine(); // Show next
                    }
                    else
                    {
                        this.Close(); // End of dialogue
                    }
                }

                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblOption1_Click(object sender, EventArgs e)
        {

        }
    }
}
