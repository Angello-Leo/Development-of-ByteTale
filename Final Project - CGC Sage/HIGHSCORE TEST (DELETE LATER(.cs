using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Final_Project___CGC_Sage
{
    public partial class HIGHSCORE_TEST__DELETE_LATER_ : Form
    {
        string encconstring = "yONu9LKbdAh6y11QkhjHWg454/GtKyEL+80njGSLgV7kdSfxb0ubTtP2TSxI/r51BordTEAGk/dMIz+6bAHE40vptOn9vqcaVPF15lCNb2w=";
        private string currentUsername;
        Random rnd = new Random();
        private int generatedHighscore;


        public HIGHSCORE_TEST__DELETE_LATER_(string username)
        {
            InitializeComponent();
            currentUsername = username;
        }

        private void HIGHSCORE_TEST__DELETE_LATER__Load(object sender, EventArgs e)
        {
            // Generate a random score and show it
            generatedHighscore = rnd.Next(0, 1001); // Random number between 0 and 1000
            lblHighscore.Text = generatedHighscore.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int highscore = generatedHighscore;
            string constring = Guardian.Decrypt(encconstring);

            using (MySqlConnection conn = new MySqlConnection(constring))
            {
                try
                {
                    conn.Open();

                    string checkQuery = "SELECT highscore FROM highscore WHERE username = @username";
                    MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@username", currentUsername.ToLower());
                    object existingScore = checkCmd.ExecuteScalar();

                    bool isNewHighscore = false;
                    int existingHighscore = existingScore != null ? Convert.ToInt32(existingScore) : 0;

                    if (existingScore != null && highscore > existingHighscore)
                    {
                        string updateQuery = "UPDATE highscore SET highscore = @highscore WHERE username = @username";
                        MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn);
                        updateCmd.Parameters.AddWithValue("@username", currentUsername.ToLower());
                        updateCmd.Parameters.AddWithValue("@highscore", highscore);
                        updateCmd.ExecuteNonQuery();
                        isNewHighscore = true;
                    }
                    else if (existingScore == null)
                    {
                        string insertQuery = "INSERT INTO highscore (username, highscore) VALUES (@username, @highscore)";
                        MySqlCommand insertCmd = new MySqlCommand(insertQuery, conn);
                        insertCmd.Parameters.AddWithValue("@username", currentUsername.ToLower());
                        insertCmd.Parameters.AddWithValue("@highscore", highscore);
                        insertCmd.ExecuteNonQuery();
                        isNewHighscore = true;
                    }

                    // Open frmGameOver
                    frmGameOver gameOverForm = new frmGameOver(highscore, existingHighscore, isNewHighscore);
                    gameOverForm.Show();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

    }
}

