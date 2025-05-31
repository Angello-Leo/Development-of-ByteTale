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
    public partial class frmCareerPlanningGuardDialogue : Form
    {
        private List<string> dialogueLines;
        private int currentLineIndex = 0;
        private int currentOptionIndex = 0;
        private List<Label> optionLabels;
        private bool optionsVisible = false;

        private List<string> helpLines;
        private int currentHelpLineIndex = 0;
        private int currentHelpIndex = 0;
        private List<Label> helpLabels;
        private bool helpVisible = false;

        private Timer typingTimer;
        private string fullTextToType = "";
        private int currentCharIndex = 0;
        private Action onTypingComplete;

        private List<string> guideLines;
        private int currentguideLineIndex = 0;
        private int currentguideIndex = 0;
        private List<Label> guideLabels;
        private bool guideVisible = false;

        private List<string> guideLines2;
        private int currentguideLineIndex2 = 0;
        private int currentguideIndex2 = 0;
        private List<Label> guideLabels2;
        private bool guideVisible2 = false;

        int caveMenuCount = 0;
        Form formToHide = null;

        public frmCareerPlanningGuardDialogue()
        {
            InitializeComponent();
            typingTimer = new Timer();
            typingTimer.Interval = 30; // milliseconds per character
            typingTimer.Tick += TypingTimer_Tick;

            dialogueLines = new List<string>
                {
                    "Hmmm... Your path seems blurry and undecided..",
                    "I sense something ominous about you...",
                    "I will grant you the opportunity to enter."
                };

            helpLines = new List<string>
                {
                    "This Cave is all about Career Planning",
                    "I will ask you a bunch of questions that you must answer",
                    "Beware, you must answer the questions honestly."
                };
            guideLines = new List<string>
                 {
                    "Press \"Z\" to Continue"
                 };
            guideLines2 = new List<string>
                 {
                    "Press \"Z\" to Select and Continue"
                 };


            // Prepare options
            optionLabels = new List<Label> { lblOption1, lblOption2, lblOption3 };

            // Hide them initially
            lblSelect.Visible = false;
            lblOption1.Visible = false;
            lblOption2.Visible = false;
            lblOption3.Visible = false;
            pictureBoxSoul.Visible = false;

            this.KeyPreview = true; // So the form receives key events before controls
            ShowCurrentLine();

            pictureBoxSoul.Image = Properties.Resources.soul;
        }
        private void ShowCurrentLine()
        {
            if (currentLineIndex < dialogueLines.Count)
            {
                // Set position only for the first line
                if (currentLineIndex == 0)
                {
                    lblDialogue.MaximumSize = new Size(500, 0);
                    lblDialogue.Size = new Size(500, 0);
                    lblDialogue.Left = 350;  // Adjust X position
                    lblDialogue.Top = 100;   // Adjust Y position
                }
                else
                {
                    // Optional: Reset for other lines if needed
                    lblDialogue.MaximumSize = new Size(500, 0);
                    lblDialogue.Size = new Size(500, 0);
                    lblDialogue.Left = 350;
                    lblDialogue.Top = 100;
                }

                StartTyping(dialogueLines[currentLineIndex]);
            }
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
                typingTimer.Stop(); // Stop typing when done

                // Only show guide if no custom callback was given
                if (onTypingComplete != null)
                {
                    var callback = onTypingComplete;
                    onTypingComplete = null; // clear it to avoid repeat calls
                    callback(); // invoke
                }
                else
                {
                    // Now show the guide text after the dialogue is fully typed
                    lblGuide.Text = "Press \"Z\" to Continue";
                    lblGuide.Top = lblDialogue.Bottom + 10;  // Position guide just below the dialogue
                    lblGuide.Left = 350;  // Center horizontally with the dialogue
                    lblGuide.Visible = true;
                }
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


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // Prevent any input if the typing animation is still running
            if (typingTimer.Enabled)
            {
                if (keyData == Keys.Z)
                {
                    // Skip to full line immediately when Z is pressed
                    typingTimer.Stop();
                    lblDialogue.Text = fullTextToType; // Show the full dialogue
                    lblGuide.Text = "Press \"Z\" to Continue";  // Show the prompt for next step
                    lblGuide.Top = lblDialogue.Bottom + 10;  // Position below dialogue
                    lblGuide.Left = 350;  // Center horizontally with the dialogue
                    lblGuide.Visible = true; // Show the guide after skipping typing
                }
                return true; // Indicate we handled the "Z" key press
            }

            // Handle Help Lines (if help is visible)
            if (helpVisible && keyData == Keys.Z)
            {
                lblGuide.Visible = false;  // Hide the prompt while typing next line

                currentHelpLineIndex++;
                if (currentHelpLineIndex < helpLines.Count)
                {
                    StartTyping(helpLines[currentHelpLineIndex]);
                }
                else
                {
                    helpVisible = false;
                    ShowOptions();  // After help is done, show options
                }
                return true;
            }

            // Handle Dialogue Lines (normal dialogue flow)
            if (!optionsVisible)
            {
                if (keyData == Keys.Z)
                {
                    lblGuide.Visible = false;  // Hide instruction immediately after Z is pressed

                    // If the typing timer is still enabled (meaning typing is not finished)
                    if (typingTimer.Enabled)
                    {
                        // Skip to full line immediately when Z is pressed
                        typingTimer.Stop();
                        lblDialogue.Text = fullTextToType;
                        lblGuide.Text = "Press \"Z\" to Continue";  // Show the prompt for next step
                        lblGuide.Visible = true;
                    }
                    else
                    {
                        // Otherwise, go to the next line of dialogue
                        currentLineIndex++;
                        if (currentLineIndex < dialogueLines.Count)
                        {
                            ShowCurrentLine();  // Show next dialogue line
                        }
                        else
                        {
                            ShowOptions();  // If there are no more dialogue lines, show options
                        }
                    }
                    return true; // Indicate we handled the "Z" key press
                }
            }
            else
            {
                // Handle Option Selection (when options are visible)
                if (keyData == Keys.A && currentOptionIndex > 0)
                {
                    currentOptionIndex--;
                    MoveSoulToCurrentOption();
                }
                else if (keyData == Keys.D && currentOptionIndex < optionLabels.Count - 1)
                {
                    currentOptionIndex++;
                    MoveSoulToCurrentOption();
                }
                else if (keyData == Keys.Z)
                {
                    HandleOptionSelection(currentOptionIndex);
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void ShowOptions()
        {
            lblDialogue.Visible = true;
            lblDialogue.Text = "I will grant you the opportunity to enter";
            lblDialogue.TextAlign = ContentAlignment.TopCenter;

            lblDialogue.Left = 350;
            lblDialogue.Top = 75;

            // Set text and autosize to ensure proper width
            lblOption1.Text = "Enter the Cave";
            lblOption2.Text = "What is this Cave all about?";
            lblOption3.Text = "Leave";

            lblOption1.AutoSize = true;
            lblOption2.AutoSize = true;
            lblOption3.AutoSize = true;

            lblOption1.Visible = true;
            lblOption2.Visible = true;
            lblOption3.Visible = true;
            pictureBoxSoul.Visible = true;

            // Align options in a horizontal row centered + offset to the right
            int spacing = 50;
            int horizontalOffset = 115;

            int totalWidth = lblOption1.Width + lblOption2.Width + lblOption3.Width + (2 * spacing);
            int startLeft = (this.ClientSize.Width - totalWidth) / 2 + horizontalOffset;
            int top = lblDialogue.Bottom + 40;

            lblOption1.Left = startLeft;
            lblOption1.Top = top;

            lblOption2.Left = lblOption1.Right + spacing;
            lblOption2.Top = top;

            lblOption3.Left = lblOption2.Right + spacing;
            lblOption3.Top = top;

            currentOptionIndex = 0;
            MoveSoulToCurrentOption();

            // Adjust guide position with same offset
            lblGuide.Text = "Press \"Z\" to Select and Continue";
            lblGuide.AutoSize = true;
            lblGuide.Top = lblOption1.Bottom + 40;
            lblGuide.Left = (this.ClientSize.Width - lblGuide.Width) / 2 + horizontalOffset;
            lblGuide.Visible = true;

            optionsVisible = true;
        }

        private void ShowHelpLines()
        {
            currentHelpLineIndex = 0;
            // After each help line finishes typing, show the next help line or stop showing help
            lblGuide.Visible = false;
            lblDialogue.TextAlign = ContentAlignment.TopCenter;
            lblDialogue.Left = 275;
            lblDialogue.Top = 125;

            helpVisible = true;

            // Hide options while help is being shown
            lblOption1.Visible = false;
            lblOption2.Visible = false;
            lblOption3.Visible = false;
            pictureBoxSoul.Visible = false;

            optionsVisible = false;

            if (currentHelpIndex < helpLines.Count)
            {
                if (currentLineIndex == 0)
                {
                    lblDialogue.MaximumSize = new Size(500, 0);
                    lblDialogue.Size = new Size(500, 0);
                    lblDialogue.Left = 350;  // Adjust X position
                    lblDialogue.Top = 100;   // Adjust Y position
                }
                else
                {
                    // Optional: Reset for other lines if needed
                    lblDialogue.MaximumSize = new Size(500, 0);
                    lblDialogue.Size = new Size(500, 0);
                    lblDialogue.Left = 350;
                    lblDialogue.Top = 100;
                }
                // Start typing the first help line
                StartTyping(helpLines[currentHelpLineIndex]);
            }
        }
        

        private void MoveSoulToCurrentOption()
        {
            foreach (Label label in optionLabels)
            {
                label.ForeColor = Color.White;
            }
            Label selectedLabel = optionLabels[currentOptionIndex];
            selectedLabel.ForeColor = Color.Yellow;

            pictureBoxSoul.Left = selectedLabel.Left + (selectedLabel.Width / 2) - (pictureBoxSoul.Width / 2);
            pictureBoxSoul.Top = selectedLabel.Bottom + 5;
        }

        private void HandleOptionSelection(int index)
        {
            //string choice = optionLabels[index].Text;
            //essageBox.Show($"You selected: {choice}");

            //Debugging
            //Console.WriteLine($"Option {index} selected: {choice}");

            /// Example actions based on selection (you can expand this logic)
            if (index == 0)
            {
                PlayerState.ReturningFromCareerResults = true;
                CareerPlanGame careerPlan = new CareerPlanGame(); // Pass the saved player state
                careerPlan.Show();
                this.Close();

                List<Form> caveMenus = new List<Form>();

                foreach (Form openForm in Application.OpenForms)
                {
                    if (openForm is caveMenu)
                    {
                        caveMenus.Add(openForm);
                    }
                }

                Form formToHide = null;

                for (int i = 0; i < caveMenus.Count; i++)
                {
                    if (i == 0)
                    {
                        formToHide = caveMenus[i]; // First one to hide
                    }
                    else
                    {
                        caveMenus[i].Close(); // Close the rest
                    }
                }

                if (formToHide != null)
                {
                    formToHide.Hide(); // Hide the first one
                }
            }
            else if (index == 1)
            {
                ShowHelpLines(); // Help flow will manage visibility
                return; // Exit early to avoid hiding labels here
            }
            else
            {
                MessageBox.Show("You step back from the cave.");
                this.Close(); // Or transition to next scene
            }

            // Hide the options only if not going to help
            lblOption1.Visible = false;
            lblOption2.Visible = false;
            lblOption3.Visible = false;
            pictureBoxSoul.Visible = false;

            optionsVisible = false;


        }

        private void frmCareerPlanningGuardDialogue_Load(object sender, EventArgs e)
        {
            this.Location = new Point(350, 500);
            
        }
      
   

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBoxSoul_Click(object sender, EventArgs e)
        {

        }

        private void lblDialogue_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void lblOption2_Click(object sender, EventArgs e)
        {

        }

        private void lblOption1_Click(object sender, EventArgs e)
        {

        }

        private void typingTimerCareer_Tick(object sender, EventArgs e)
        {

        }

        private void txtSelect_Click(object sender, EventArgs e)
        {

        }

        private void lblGuide_Click(object sender, EventArgs e)
        {

        }
    }
}
