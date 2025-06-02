using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project___CGC_Sage
{
    public partial class frmBassDialogue : Form
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

        int currentCharIndex1 = 0;
        int currentCharIndex2 = 0;
        int currentCharIndex3 = 0;

        private Timer typingTimer;
        private string fullTextToType = "";
        private int currentCharIndex = 0;
        private Action onTypingComplete;
        private bool isTypingComplete = false;
        private bool isAllTextTyped = false;
        private bool isTypingFinished = false;
        private bool isAtEnd = false;


        public frmBassDialogue()
        {
            InitializeComponent();

            typingTimer = new Timer();
            typingTimer.Interval = 30; // milliseconds per character
            typingTimer.Tick += typingTimer_Tick;

            dialogueLines = new List<string>
                {
                    "You played the Bass Guitar",
                    "You got shocked",
                    "It made a sound without an amplifier",
                    "And you realized you have no hands...",
                    "Bass Guitar of Leo Angello P. Visto"
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
                lblInstructions.Visible = true;
            }
        }


        private void frmBassDialogue_Load(object sender, EventArgs e)
        {
            lblDev.Visible = false;
            PlaySound();
            CenterLabels();
        }
        private void PlaySound()
        {
            try
            {
                System.Media.SoundPlayer sfx = new System.Media.SoundPlayer(Properties.Resources.bASSsound);
                sfx.PlaySync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error playing sound: {ex.Message}");
            }

            // After the sound finishes, show the dialogue
            ShowCurrentLine();
        }
        private void StartTyping(string text, Action onComplete = null)
        {
            typingTimer.Stop();
            fullTextToType = text;  // Use dialogue lines directly
            lblLeo.Text = "";
            currentCharIndex = 0;
            isTypingComplete = false;
            onTypingComplete = onComplete;
            typingTimer.Start();
        }

        private void typingTimer_Tick(object sender, EventArgs e)
        {
            bool anyTextLeft = false;

            if (currentLineIndex < dialogueLines.Count && currentCharIndex < dialogueLines[currentLineIndex].Length)
            {
                lblLeo.Text += dialogueLines[currentLineIndex][currentCharIndex];
                currentCharIndex++;
                anyTextLeft = true;
            }
            else if (currentLineIndex == dialogueLines.Count && currentCharIndex2 < dialogueLine2[0].Length)
            {
                lblDev.Visible = true;
                lblDev.Text += dialogueLine2[0][currentCharIndex2];
                currentCharIndex2++;
                anyTextLeft = true;
            }
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

                if (currentLineIndex < dialogueLines.Count - 1)
                {
                    lblContinue.Visible = true;
                }
                else if (currentLineIndex == dialogueLines.Count - 1)
                {
                    // After the final dialogue line, auto-show dev and exit text
                    currentLineIndex++; // Advance to prevent retrigger
                    currentCharIndex2 = 0;
                    currentCharIndex3 = 0;
                    StartTypingDevAndExit();
                }
                else
                {
                    // All done, show only "Press C to exit"
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
                        lblLeo.Text = dialogueLines[currentLineIndex];
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
            lblLeo.Width = formWidth;
            lblDev.Width = formWidth;
            lblInstructions.Width = formWidth;
            lblContinue.Width = formWidth; // Add this line for Continue label

            // Set padding to zero to avoid any unwanted space around the text
            lblLeo.Padding = new Padding(0);
            lblDev.Padding = new Padding(0);
            lblInstructions.Padding = new Padding(0);
            lblContinue.Padding = new Padding(0); // Ensure padding is zero for Continue

            // Set text alignment to middle-center for both vertical and horizontal centering
            lblLeo.TextAlign = ContentAlignment.MiddleCenter;
            lblDev.TextAlign = ContentAlignment.MiddleCenter;
            lblInstructions.TextAlign = ContentAlignment.MiddleCenter;
            lblContinue.TextAlign = ContentAlignment.MiddleCenter; // Add this for Continue label

            // Adjust the Y positioning if you want to center the labels vertically
            lblLeo.Location = new Point(0, (this.ClientSize.Height / 3) - (lblLeo.Height / 2));
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

