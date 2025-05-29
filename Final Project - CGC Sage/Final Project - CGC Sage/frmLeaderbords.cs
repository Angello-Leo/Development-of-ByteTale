using MySql.Data.MySqlClient;
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
    public partial class frmLeaderbords : Form
    {
        string encconstring = "yONu9LKbdAh6y11QkhjHWg454/GtKyEL+80njGSLgV7kdSfxb0ubTtP2TSxI/r51BordTEAGk/dMIz+6bAHE40vptOn9vqcaVPF15lCNb2w=";
        public frmLeaderbords()
        {
            this.TopMost = true;
            InitializeComponent();
            this.Load += new EventHandler(this.frmLeaderbords_Load);
            LoadTopHighscores();
        }

        private void LoadTopHighscores()
        {
            try
            {
                string constring = Guardian.Decrypt(encconstring); // Decrypted Constring
                using (MySqlConnection conn = new MySqlConnection(constring))
                {
                    conn.Open();
                    string query = "SELECT username, highscore FROM highscore ORDER BY highscore DESC LIMIT 10";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();

                    // Define schema before filling in case the query returns 0 rows
                    dt.Columns.Add("username", typeof(string));
                    dt.Columns.Add("highscore", typeof(int));

                    adapter.Fill(dt);

                    // DEBUG: Show how many rows are loaded
                    //MessageBox.Show($"Rows loaded from DB: {dt.Rows.Count}", "Debug");

                    // Pad with empty rows if less than 10
                    while (dt.Rows.Count < 10)
                    {
                        DataRow emptyRow = dt.NewRow();
                        emptyRow["username"] = "";
                        emptyRow["highscore"] = DBNull.Value;
                        dt.Rows.Add(emptyRow);
                    }

                    dataGridView1.DataSource = dt;

                    // Format headers
                    dataGridView1.Columns["username"].HeaderText = "Player";
                    dataGridView1.Columns["highscore"].HeaderText = "Score";
                    dataGridView1.Columns["highscore"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    // Optional: Set minimum column widths
                    dataGridView1.Columns["username"].MinimumWidth = 100;
                    dataGridView1.Columns["highscore"].MinimumWidth = 60;

                    // Read-only columns
                    foreach (DataGridViewColumn column in dataGridView1.Columns)
                    {
                        column.ReadOnly = true;
                    }

                    dataGridView1.Dock = DockStyle.Fill; // Ensures the DataGridView fills the form

                    // Visual fixes for the DataGridView
                    dataGridView1.RowTemplate.Height = 30;
                    dataGridView1.DefaultCellStyle.BackColor = Color.White;
                    dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
                    dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 10);
                    dataGridView1.RowsDefaultCellStyle.SelectionBackColor = Color.LightBlue;
                    dataGridView1.RowsDefaultCellStyle.SelectionForeColor = Color.Black;

                    // Replace empty highscore values with em dash
                    dataGridView1.CellFormatting += (s, e) =>
                    {
                        if (dataGridView1.Columns[e.ColumnIndex].Name == "highscore")
                        {
                            if (e.Value == DBNull.Value || string.IsNullOrWhiteSpace(e.Value?.ToString()))
                            {
                                e.Value = "—";
                                e.FormattingApplied = true;
                            }
                        }
                    };

                    // Scroll to top
                    if (dataGridView1.Rows.Count > 0)
                    {
                        dataGridView1.FirstDisplayedScrollingRowIndex = 0;
                        dataGridView1.Rows[0].Selected = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading leaderboard: " + ex.Message);
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Close();
            frmSettingsDialogue settings = new frmSettingsDialogue(PlayerState.Username);
            settings.ShowDialog();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void frmLeaderbords_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BringToFront();
            this.Focus();
        }
    }
}

