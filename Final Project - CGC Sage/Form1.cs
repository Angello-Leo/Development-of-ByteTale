using MySql.Data.MySqlClient;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Final_Project___CGC_Sage
{
    public partial class Login_Form : Form
    {
        private SoundPlayer signupSound;
        string encconstring = "yONu9LKbdAh6y11QkhjHWg454/GtKyEL+80njGSLgV7kdSfxb0ubTtP2TSxI/r51BordTEAGk/dMIz+6bAHE40vptOn9vqcaVPF15lCNb2w="; //decypted constring
        public Login_Form()
        {
            this.WindowState = FormWindowState.Maximized;
            InitializeComponent();
            Setup();

            // Attach KeyDown handlers for all three textboxes
            this.Textbox_username.KeyDown += new KeyEventHandler(this.textUsername_KeyDown);
            this.Textbox_pass.KeyDown += new KeyEventHandler(this.textPassword_KeyDown);


        }

        private void Setup()
        {
            this.BackgroundImage = Image.FromFile(@"C:\Users\gello\source\repos\Final Project - CGC Sage\Final Project - CGC Sage\signin.jpg"); // put bg here
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.DoubleBuffered = true;
            toolTip1.SetToolTip(pictureBox2, "Show Password");
            toolTip1.SetToolTip(pictureBox1, "Hide Password");
            toolTip1.SetToolTip(Label_register, "Go to Signup");

        }


        private void Button_login_Click(object sender, EventArgs e)
        {
            string username = Textbox_username.Text.Trim();
            string password = Textbox_pass.Text.Trim();

            if (username == "" || password == "")
            {
                MessageBox.Show("Please make sure that you entered a username and a password!");
                return;
            }

            try
            {
                string constring = Guardian.Decrypt(encconstring);
                using (MySqlConnection conn = new MySqlConnection(constring))
                {
                    conn.Open();

                    // 1. Check if a username exists (case-insensitive)
                    string checkUserQuery = "SELECT username FROM users WHERE LOWER(username) = LOWER(@username) LIMIT 1";
                    MySqlCommand checkUserCmd = new MySqlCommand(checkUserQuery, conn);
                    checkUserCmd.Parameters.AddWithValue("@username", username);

                    object matchedUsernameObj = checkUserCmd.ExecuteScalar();

                    if (matchedUsernameObj == null)
                    {
                        MessageBox.Show("Username not found.");
                        return;
                    }

                    string matchedUsername = matchedUsernameObj.ToString();

                    // 2. Now check if exact case username exists and get the password
                    string checkExactQuery = "SELECT password FROM users WHERE BINARY username = @username LIMIT 1";
                    MySqlCommand exactUserCmd = new MySqlCommand(checkExactQuery, conn);
                    exactUserCmd.Parameters.AddWithValue("@username", username);

                    object passwordObj = exactUserCmd.ExecuteScalar();

                    if (passwordObj == null)
                    {
                        MessageBox.Show(
                            "Incorrect username or password.\n\n" +
                            "Note: The username is case-sensitive.\n" +
                            "Please check that uppercase and lowercase letters are correct."
                        );
                        return;
                    }

                    string storedPassword = passwordObj.ToString();

                    if (storedPassword != password)
                    {
                        MessageBox.Show(
                            "Incorrect username or password.\n\n" +
                            "Note: The username is case-sensitive.\n" +
                            "Please check that uppercase and lowercase letters are correct."
                        );
                        return;
                    }

                    // 3. Login successful
                    MessageBox.Show("Logged in successfully!");
                    PlayerState.Username = username;
                    new mainDashboard().Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ApplyCustomFont(Control parent, float size)
        {
            foreach (Control c in parent.Controls)
            {
                c.Font = FontManager.GetFont(size);
                if (c.HasChildren)
                {
                    ApplyCustomFont(c, size);
                }
            }
        }
        private void Login_Form_Load(object sender, EventArgs e)
        {
            Textbox_pass.PasswordChar = '*';                  // Use asterisk for masking
            pictureBox1.BringToFront();

            Label_login.BackColor = Color.Transparent;
            Label_username.BackColor = Color.Transparent;
            Label_pass.BackColor = Color.Transparent;
            Label_nouser.BackColor = Color.Transparent;
            Label_register.BackColor = Color.Transparent;

      
            // Load and play a different sound (change the path to your file)
            signupSound = new SoundPlayer(@"C:\Users\gello\source\repos\Final Project - CGC Sage\Final Project - CGC Sage\Login sound.wav");
            signupSound.Load();
            signupSound.PlayLooping();
        }

        private void textUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                Textbox_pass.Focus(); // Move focus to the password textbox
            }
        }

        private void textPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                Button_login.Focus(); // Move to the confirm password box
            }
        }
        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void Label5_Click(object sender, EventArgs e)
        {
            new signupForm().Show();
            this.Hide();
        }

        private void Label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        private void Textbox_username_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Show password (eye-open)
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Textbox_pass.PasswordChar = '\0';
            pictureBox2.BringToFront(); // show eye-closed
            
        }

        // Hide password (eye-closed)
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Textbox_pass.PasswordChar = '*';
            pictureBox1.BringToFront(); // show eye-open
            
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }
    }
}
