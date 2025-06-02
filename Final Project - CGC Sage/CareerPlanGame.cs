using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Media;
using System.Collections.Generic;

namespace Final_Project___CGC_Sage
{
    public partial class CareerPlanGame : Form
    {
        private bool textFinished = false;
        private string text;
        private int len = 0;
        string fullText1 = "Choosing the right path isn’t just about picking a subject — it’s about aligning your passions, strengths, and goals. Each track offers unique experiences and career opportunities. \r\n\r\nWhen you find the right fit, you can focus your energy on what excites you and build a future you’re proud of.\r\n\r\nTo help you decide, here are some key questions to uncover what truly aligns with you.";
        public CareerPlanGame()
        {
            InitializeComponent();
            this.DoubleBuffered = true; // Prevent flickering
        }

        private void CareerPlanGame_Load(object sender, EventArgs e)
        {
            pictureBox2.Location = new Point(400, 550);
            lblContinue.Visible = false;
            text = fullText1;
            lbl1.Text = ""; // Clear text before typing animation starts
            timer1.Start(); // Start animation

            // Make form full screen
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);

            lbl1.AutoSize = true;
            lbl1.MaximumSize = new Size(800, 0); // Set label width limit
            lbl1.Width = 800; // Set fixed width

            CenterLabelTextAtTop(); // Center label
        }

        private void CenterLabelTextAtTop()
        {
            int labelWidth = lbl1.Width;
            int topMargin = 75;
            int x = (this.ClientSize.Width - labelWidth) / 2;
            int y = topMargin;

            lbl1.Location = new Point(x, y); // Position label
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            CenterLabelTextAtTop(); // Re-center when resized
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            if (len < text.Length)
            {
                lbl1.Text += text.ElementAt(len);
                len++;
                CenterLabelTextAtTop(); // Re-center after each char
            }
            else
            {
                textFinished = true; // Mark text as finished once typing is complete
                timer1.Stop(); // Stop once text is fully typed
                Invalidate(); // Trigger redraw
            }
        }

        // Handle key presses
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Z && textFinished)
            {
                // Hide everything
                lbl1.Visible = false;
                lblContinue.Visible = false;

                // Play the sound
                try
                {
                    using (System.Media.SoundPlayer sfx = new System.Media.SoundPlayer(Properties.Resources.AfterIntroSound))
                    {
                        sfx.PlaySync();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error playing sound: " + ex.Message);
                }

                // Go to next form after sound
                CareerPlanQuestions form2 = new CareerPlanQuestions();
                pictureBox2.Visible = false;
                form2.Show();
                this.Hide();

                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        // Custom method to draw justified text
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Font font = new Font("Arial", 12);
            Brush brush = Brushes.Black;
            int x = (this.ClientSize.Width - lbl1.Width) / 2;
            int y = 50;

            if (IsPictureBoxNextToLabel())
            {
                // Change the label color to yellow if the pictureBox is near
                brush = Brushes.Yellow;
            }

            // Draw the justified text
            DrawJustifiedText(e.Graphics, fullText1, font, brush, x, y, lbl1.Width);

            // Calculate the height of the drawn text
            SizeF textSize = e.Graphics.MeasureString(fullText1, font, lbl1.Width);

            if (textFinished)
            {

                lblContinue.Visible = true;
                lblContinue.Location = new Point(600, 650);  // Set the correct position
            }
        }

        private void DrawJustifiedText(Graphics graphics, string text, Font font, Brush brush, int x, int y, int width)
        {
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Near;

            RectangleF layoutRect = new RectangleF(x, y, width, 0);
            graphics.DrawString(text, font, brush, layoutRect, format); // Draw the justified text
        }
        private bool IsPictureBoxNextToLabel()
        {
            // Define the threshold distance
            int threshold = 100;

            // Get the center of the PictureBox and the Label
            Point pictureBoxCenter = new Point(pictureBox2.Left + pictureBox2.Width / 2, pictureBox2.Top + pictureBox2.Height / 2);
            Point labelCenter = new Point(lbl1.Left + lbl1.Width / 2, lbl1.Top + lbl1.Height / 2);

            // Calculate the distance between the centers
            double distance = Math.Sqrt(Math.Pow(pictureBoxCenter.X - labelCenter.X, 2) + Math.Pow(pictureBoxCenter.Y - labelCenter.Y, 2));

            // Return true if the distance is smaller than the threshold
            return distance < threshold;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
