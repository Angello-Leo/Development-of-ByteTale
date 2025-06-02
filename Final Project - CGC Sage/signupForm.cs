using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Media;

namespace Final_Project___CGC_Sage
{
    public partial class signupForm : Form
    {
        private ToolTip toolTip;
        private SoundPlayer signupSound;
        string encconstring = "yONu9LKbdAh6y11QkhjHWg454/GtKyEL+80njGSLgV7kdSfxb0ubTtP2TSxI/r51BordTEAGk/dMIz+6bAHE40vptOn9vqcaVPF15lCNb2w=";
        public signupForm()
        {
            this.WindowState = FormWindowState.Maximized;
            InitializeComponent();
            pictureBox1.Click += new EventHandler(pictureBox1_Click);
            pictureBox2.Click += new EventHandler(pictureBox2_Click);
            Setup();

            // Attach KeyDown handlers for all three textboxes
            this.textUsername.KeyDown += new KeyEventHandler(this.textUsername_KeyDown);
            this.textPassword.KeyDown += new KeyEventHandler(this.textPassword_KeyDown);
            this.textConfirmPassword.KeyDown += new KeyEventHandler(this.textConfirmPassword_KeyDown);
        }
        private void Setup()
        {
            toolTip1.SetToolTip(pictureBox2, "Show Password");
            toolTip1.SetToolTip(pictureBox1, "Hide Password");
            toolTip1.SetToolTip(labelloginhere, "Go to Login");
            this.BackgroundImage = Properties.Resources.loginbg;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.DoubleBuffered = true;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void signupForm_Load(object sender, EventArgs e)
        {
            textPassword.PasswordChar = '*';
            textConfirmPassword.PasswordChar = '*';
            pictureBox1.BringToFront();

            // Load and play a different sound (change the path to your file)
            System.Media.SoundPlayer sfx = new System.Media.SoundPlayer(Properties.Resources.Register_Sound);
            sfx.PlayLooping();

            textUsername.TabIndex = 0;
            textPassword.TabIndex = 1;
            textConfirmPassword.TabIndex = 2;
            buttoncreateuser.TabIndex = 3;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            new Login_Form().Show();
            this.Hide();
        }

        private void Textusername_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelx_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttoncreateuser_Click(object sender, EventArgs e)
        {
            string username = textUsername.Text.Trim();
            string password = textPassword.Text.Trim();
            string confirmPassword = textConfirmPassword.Text.Trim();

            if (username == "" || password == "" || confirmPassword == "")
            {
                MessageBox.Show("Please make sure that all fields are not empty.");
                return;
            }
            else if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match!");
                return;
            }
            else
            {
                try
                {
                    string constring = Guardian.Decrypt(encconstring);
                    MySqlConnection conn = new MySqlConnection(constring);
                    using (conn)
                    {
                        conn.Open();
                        string query = "insert into users(username,password) values(@username,@password)";

                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("username", username);
                        cmd.Parameters.AddWithValue ("password", password);

                        int status = cmd.ExecuteNonQuery();
                        if (status > 0)
                        {
                            MessageBox.Show("User has been successfully created!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            PlayerState.Username = textUsername.Text;
                            conn.Close();
                            this.Hide();
                            new Login_Form().Show();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            
        }

        // Show password (eye-open)
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            textPassword.PasswordChar = '\0';
            textConfirmPassword.PasswordChar = '\0';
            pictureBox2.BringToFront(); // Show "eye-closed"

        }

        // Hide password (eye-closed)
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            textPassword.PasswordChar = '*';
            textConfirmPassword.PasswordChar = '*';
            pictureBox1.BringToFront(); // Show "eye-open"

        }
        private void textUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                textPassword.Focus(); // Move focus to the next textbox
            }
        }

        private void textPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                textConfirmPassword.Focus(); // Move to the confirm password box
            }
        }

        private void textConfirmPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                buttoncreateuser.PerformClick(); // Submit
            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            new Login_Form().Show();
            this.Hide();
        }

        private void labelusername_Click(object sender, EventArgs e)
        {

        }

        private void labelpass_Click(object sender, EventArgs e)
        {

        }

        private void textPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelalreadyhaveauser_Click(object sender, EventArgs e)
        {

        }
        
        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            new signupForm().Show();
            this.Hide();
        }
    }
}
