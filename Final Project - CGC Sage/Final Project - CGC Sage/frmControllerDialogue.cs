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
    public partial class frmControllerDialogue : Form
    {
        private List<string> dialogueLines;
        private int currentLineIndex = 0;
        private int currentOptionIndex = 0;
        private List<Label> optionLabels;
        private bool optionsVisible = false;

        private List<string> dialogueLine2;
        private int currentLineIndex2 = 0;
        private int currentOptionIndex2 = 0;
        private List<Label> optionLabels2;
        private bool optionsVisible2 = false;

        private List<string> dialogueLine3;
        private int currentLineIndex3 = 0;
        private int currentOptionIndex3 = 0;
        private List<Label> optionLabels3;
        private bool optionsVisible3 = false;

        private Timer typingTimer;
        private string fullTextToType = "";
        private int currentCharIndex = 0;
        private Action onTypingComplete;
        private bool isTypingComplete = false;

        int currentCharIndex1 = 0;
        int currentCharIndex2 = 0;
        int currentCharIndex3 = 0;
        private bool isAtEnd = false;

        public frmControllerDialogue()
        {
            InitializeComponent();
            typingTimer = new Timer();
            typingTimer.Interval = 30; // milliseconds per character
            typingTimer.Tick += typingTimer_Tick;

            dialogueLines = new List<string>
                {
                    "You inspected the controller",
                    "The buttons are mashed..",
                    "You tried turning it on",
                    "It had no batteries...",
                    "Controller of Ralfh Justine N. Lindog"
                };
            dialogueLine2 = new List<string>
            {
                "(Developer)"
            };
            dialogueLine3 = new List<string>
            {
                "Press \"C\" to exit.."
            };

            this.Width = 800;
            this.Height = 200;
            this.FormBorderStyle = FormBorderStyle.None;
            this.KeyPreview = true;
            this.StartPosition = FormStartPosition.Manual;

            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;

            this.Location = new Point(350, 500);
        }

        private void ShowCurrentLine()
        {
            lblContinue.Visible = false;
            lblInstructions.Visible = false;

            // Typing main dialogue
            if (currentLineIndex < dialogueLines.Count)
            {
                StartTyping(dialogueLines[currentLineIndex], () =>
                {
                    isTypingComplete = true;

                    // Only show "Press Z" if NOT the final dialogue line
                    if (currentLineIndex < dialogueLines.Count - 1)
                    {
                        lblContinue.Visible = true;
                    }
                    else
                    {
                        // Start developer line immediately after last main line
                        currentLineIndex++;
                        currentCharIndex = 0;
                        StartTypingDevLine();
                    }
                });
            }
        }
        private void StartTypingDevLine()
        {
            fullTextToType = dialogueLine2[0];
            lblDev.Text = "";
            currentCharIndex2 = 0;
            typingTimer.Tick -= typingTimer_Tick;
            typingTimer.Tick += TypingDev_Tick;
            typingTimer.Start();
        }
        private void TypingDev_Tick(object sender, EventArgs e)
        {
            if (currentCharIndex2 < dialogueLine2[0].Length)
            {
                lblDev.Text += dialogueLine2[0][currentCharIndex2];
                currentCharIndex2++;
            }
            else
            {
                typingTimer.Stop();
                typingTimer.Tick -= TypingDev_Tick;
                StartTypingExitLine();
            }
        }
        private void StartTypingExitLine()
        {
            fullTextToType = dialogueLine3[0];
            lblInstructions.Text = "";
            currentCharIndex3 = 0;
            typingTimer.Tick += TypingExit_Tick;
            typingTimer.Start();
        }
        private void TypingExit_Tick(object sender, EventArgs e)
        {
            if (currentCharIndex3 < dialogueLine3[0].Length)
            {
                lblInstructions.Text += dialogueLine3[0][currentCharIndex3];
                currentCharIndex3++;
            }
            else
            {
                typingTimer.Stop();
                typingTimer.Tick -= TypingExit_Tick;
                isTypingComplete = true;
                isAtEnd = true;

                lblInstructions.Visible = true;  // Ensure this is visible when typing is complete
            }
        }

        private void frmControllerDialogue_Load(object sender, EventArgs e)
        {
            lblDev.Visible = false;
            ShowCurrentLine();
            StartTypingEffect();
            CenterLabels();
        }

        private void StartTyping(string text, Action onComplete = null)
        {
            typingTimer.Stop();
            fullTextToType = text;  // Use dialogue lines directly
            lblRalfh.Text = "";
            currentCharIndex = 0;
            isTypingComplete = false;
            onTypingComplete = onComplete;
            typingTimer.Start();
        }

        private void typingTimer_Tick(object sender, EventArgs e)
        {
            bool anyTextLeft = false;

            // Handle main dialogue lines
            if (currentLineIndex < dialogueLines.Count && currentCharIndex < dialogueLines[currentLineIndex].Length)
            {
                lblRalfh.Text += dialogueLines[currentLineIndex][currentCharIndex];
                currentCharIndex++;
                anyTextLeft = true;
            }
            // Handle developer line
            else if (currentLineIndex == dialogueLines.Count && currentCharIndex2 < dialogueLine2[0].Length)
            {
                lblDev.Visible = true;
                lblDev.Text += dialogueLine2[0][currentCharIndex2];
                currentCharIndex2++;
                anyTextLeft = true;
            }
            // Handle exit instructions
            else if (currentLineIndex == dialogueLines.Count && currentCharIndex2 == dialogueLine2[0].Length && currentCharIndex3 < dialogueLine3[0].Length)
            {
                lblInstructions.Text += dialogueLine3[0][currentCharIndex3];
                currentCharIndex3++;
                anyTextLeft = true;
            }

            if (!anyTextLeft)
            {
                typingTimer.Stop();
                isTypingComplete = true;

                // Show "Continue" for first two lines
                if (currentLineIndex < dialogueLines.Count - 1)
                {
                    lblContinue.Visible = true;
                }
                // On the last line, we move directly to developer and exit message
                else if (currentLineIndex == dialogueLines.Count - 1)
                {
                    currentLineIndex++; // Move to next index
                    currentCharIndex2 = 0;
                    currentCharIndex3 = 0;
                    StartTypingDevAndExit(); // Handle developer and exit line automatically
                }
                else
                {
                    lblContinue.Visible = false;
                    lblInstructions.Visible = true;
                    isAtEnd = true;
                }
            }
        }
        private void StartTypingDevAndExit()
        {
            lblContinue.Visible = false;
            lblDev.Text = "";
            lblInstructions.Text = "";
            typingTimer.Start();
        }


        private void StartTypingEffect()
        {
            lblRalfh.Text = "";
            lblDev.Text = "";
            lblInstructions.Text = "";

            currentCharIndex = 0;
            currentCharIndex2 = 0;
            currentCharIndex3 = 0;

            typingTimer.Interval = 20;
            typingTimer.Start();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (isAtEnd)
            {
                if (keyData == Keys.C)
                {
                    this.Close(); // Close the form when C is pressed
                    return true;  // Stop further processing of any other keys
                }
            }

            // Handle the "Z" key to move between dialogue lines
            if (keyData == Keys.Z)
            {
                if (isTypingComplete)
                {
                    if (currentLineIndex < dialogueLines.Count)
                    {
                        currentLineIndex++; // Move to the next line of dialogue
                        ShowCurrentLine();   // Show the next line of dialogue
                    }
                    // Do nothing here — dev line and exit message now handled automatically
                }
                else
                {
                    typingTimer.Stop();

                    if (currentLineIndex < dialogueLines.Count)
                    {
                        lblRalfh.Text = dialogueLines[currentLineIndex];
                        currentCharIndex = dialogueLines[currentLineIndex].Length;
                        isTypingComplete = true;

                        if (currentLineIndex < dialogueLines.Count - 1)
                        {
                            lblContinue.Visible = true;
                        }
                        else
                        {
                            // Trigger dev + exit when skipping last line
                            currentLineIndex++;
                            currentCharIndex2 = 0;
                            currentCharIndex3 = 0;
                            StartTypingDevAndExit();
                        }
                    }
                }

                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData); // Let the base handle other keys
        }

        private void CenterLabels()
        {
            int formWidth = this.ClientSize.Width;

            // Set the width of the labels to match the form width
            lblRalfh.Width = formWidth;
            lblDev.Width = formWidth;
            lblInstructions.Width = formWidth;
            lblContinue.Width = formWidth; // Add this line for Continue label

            // Set padding to zero to avoid any unwanted space around the text
            lblRalfh.Padding = new Padding(0);
            lblDev.Padding = new Padding(0);
            lblInstructions.Padding = new Padding(0);
            lblContinue.Padding = new Padding(0); // Ensure padding is zero for Continue

            // Set text alignment to middle-center for both vertical and horizontal centering
            lblRalfh.TextAlign = ContentAlignment.MiddleCenter;
            lblDev.TextAlign = ContentAlignment.MiddleCenter;
            lblInstructions.TextAlign = ContentAlignment.MiddleCenter;
            lblContinue.TextAlign = ContentAlignment.MiddleCenter; // Add this for Continue label

            // Adjust the Y positioning if you want to center the labels vertically
            lblRalfh.Location = new Point(0, (this.ClientSize.Height / 3) - (lblRalfh.Height / 2));
            lblDev.Location = new Point(0, (this.ClientSize.Height / 2) - (lblDev.Height / 2));
            lblInstructions.Location = new Point(0, (this.ClientSize.Height * 2 / 3) - (lblInstructions.Height / 2) + 20);
            lblContinue.Location = new Point(0, (this.ClientSize.Height * 2 / 3) - (lblInstructions.Height / 2) + 20);
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            CenterLabels();  // Recenter the labels every time the form is resized
        }
    }
}
    

