using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Final_Project___CGC_Sage
{
    public partial class UsersDb : Form
    {
        string encconstring = "yONu9LKbdAh6y11QkhjHWg454/GtKyEL+80njGSLgV7kdSfxb0ubTtP2TSxI/r51BordTEAGk/dMIz+6bAHE40vptOn9vqcaVPF15lCNb2w="; // Encrypted COnstring
        private string placeholderText = "Input new password here";

        public UsersDb()
        {
            InitializeComponent();
            LoadUsers();
        }

        private void UsersDb_Load(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            textBoxUpdate.Visible = false;
            pictureBoxSearch.Click += pictureBoxSearch_Click;
            pictureBoxSearch.MouseEnter += pictureBoxSearch_MouseEnter;
            pictureBoxSearch.MouseLeave += pictureBoxSearch_MouseLeave;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;

            
            textBoxUpdate.Text = placeholderText;
            textBoxUpdate.ForeColor = Color.Gray; 
            textBoxUpdate.Font = new Font(textBoxUpdate.Font, FontStyle.Italic); 

            textBoxUpdate.GotFocus += textBoxUpdate_GotFocus; 
            textBoxUpdate.LostFocus += textBoxUpdate_LostFocus; 
            textBoxUpdate.TextChanged += textBoxUpdate_TextChanged; 

            // Set ToolTips for your controls
            toolTip.SetToolTip(pictureBoxRefresh, "Refresh Users");
            toolTip.SetToolTip(pictureBoxSearch, "Search Users");
            toolTip.SetToolTip(btnUpdate, "Update Password");
            toolTip.SetToolTip(btnDeleteUsers, "Delete Selected User");
            toolTip.SetToolTip(btnDeleteAllUsers, "Delete All Users");

            this.WindowState = FormWindowState.Normal;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BringToFront();
            this.Focus();

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
        }

        private void LoadUsers()
        {
            try
            {
                string constring = Guardian.Decrypt(encconstring); // Decrypted Constring
                using (MySqlConnection conn = new MySqlConnection(constring))
                {
                    conn.Open();
                    string query = "SELECT * FROM users WHERE username != 'ALZ'";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells["username"].Value?.ToString() == "ALZ")
                        {
                            row.ReadOnly = true;
                            row.DefaultCellStyle.BackColor = Color.LightGray;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading users: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string selectedUsername = dataGridView1.SelectedRows[0].Cells["username"].Value.ToString();

                if (selectedUsername == "ALZ")
                {
                    MessageBox.Show("No."); // Cannot delete this user
                    return;
                }

                DialogResult confirmResult = MessageBox.Show(
                    $"Are you sure you want to delete the user '{selectedUsername}'?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirmResult == DialogResult.No)
                    return;

                int selectedUserId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["UserID"].Value);

                try
                {
                    string constring = Guardian.Decrypt(encconstring); // Decrypted COnstring
                    using (MySqlConnection conn = new MySqlConnection(constring))
                    {
                        conn.Open();
                        string query = "DELETE FROM users WHERE UserID = @UserID";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@UserID", selectedUserId);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("User deleted successfully.");
                            LoadUsers(); // Refresh table
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting user: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select a user to delete.");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDeleteAllUsers_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to delete ALL users?",
                                         "Confirm Delete",
                                         MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    string constring = Guardian.Decrypt(encconstring); // Decrypted COnstring
                    using (MySqlConnection conn = new MySqlConnection(constring))
                    {
                        conn.Open();
                        string query = "DELETE FROM users WHERE username != @adminUsername";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@adminUsername", "ALZ");
                            int rowsAffected = cmd.ExecuteNonQuery();
                            MessageBox.Show($"{rowsAffected} user(s) deleted.");
                            LoadUsers();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting users: " + ex.Message);
                }
            }
        }

        private void SearchUsers(string keyword)
        {
            try
            {
                string constring = Guardian.Decrypt(encconstring); // Decrypted Consstring
                using (MySqlConnection conn = new MySqlConnection(constring))
                {
                    conn.Open();
                    string query = "SELECT * FROM users WHERE username LIKE @keyword AND username != 'ALZ'";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridView1.DataSource = dt;

                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (row.Cells["username"].Value?.ToString() == "ALZ")
                            {
                                row.ReadOnly = true;
                                row.DefaultCellStyle.BackColor = Color.LightGray;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching users: " + ex.Message);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
            frmSettingsDialogue settings = new frmSettingsDialogue(PlayerState.Username);
            settings.ShowDialog();
        }

        private void pictureBoxSearch_Click(object sender, EventArgs e)
        {
            string keyword = textboxSearch.Text.Trim();
            SearchUsers(keyword);
        }

        private void pictureBoxSearch_MouseEnter(object sender, EventArgs e)
        {
            pictureBoxSearch.BackColor = Color.LightGray; // Or change image
        }

        private void pictureBoxSearch_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxSearch.BackColor = Color.Transparent; // Or revert image
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Make the update text box visible
            textBoxUpdate.Visible = true;

            // Check if a row is selected in the DataGridView
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to update their password.");
                return;
            }

            // Get the selected username from the DataGridView
            string selectedUsername = dataGridView1.SelectedRows[0].Cells["username"].Value.ToString();

            // Check if the selected user is "ALZ" (admin user)
            if (selectedUsername == "ALZ")
            {
                MessageBox.Show("Nu-uh");//Cannot update admin user
                return;
            }

            // Get the new password from the text box
            string newPassword = textBoxUpdate.Text.Trim();

            // Validate that the password is not empty or just the placeholder text
            if (newPassword == placeholderText || string.IsNullOrWhiteSpace(newPassword))
            {
                MessageBox.Show("Please enter a valid new password.");
                return;
            }

            try
            {
                string constring = Guardian.Decrypt(encconstring); // Decrypt connection string
                using (MySqlConnection conn = new MySqlConnection(constring))
                {
                    conn.Open();
                    string query = "UPDATE users SET password = @password WHERE username = @username";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@password", newPassword);
                        cmd.Parameters.AddWithValue("@username", selectedUsername);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        // Check if the update was successful
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Password updated successfully.");
                            textBoxUpdate.Clear();
                            textBoxUpdate.Visible = false;
                            SetPlaceholderText(); // Set the placeholder text back
                        }
                        else
                        {
                            MessageBox.Show("Password update failed.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating password: " + ex.Message);
            }
        }

        private void SetPlaceholderText()
        {
            textBoxUpdate.Text = placeholderText;
            textBoxUpdate.ForeColor = Color.Gray;
            textBoxUpdate.Font = new Font(textBoxUpdate.Font, FontStyle.Italic);
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            LoadUsers();
        }
        private void textBoxUpdate_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxUpdate.Text))
            {
                SetPlaceholderText(); 
            }
        }
        private void textBoxUpdate_GotFocus(object sender, EventArgs e)
        {
            if (textBoxUpdate.Text == placeholderText)
            {
                textBoxUpdate.Text = "";
                textBoxUpdate.ForeColor = Color.Black;  
                textBoxUpdate.Font = new Font(textBoxUpdate.Font, FontStyle.Regular); 
            }
        }

        private void textBoxUpdate_TextChanged(object sender, EventArgs e)
        {
            
            if (!string.IsNullOrEmpty(textBoxUpdate.Text) && textBoxUpdate.Text != placeholderText)
            {
                textBoxUpdate.ForeColor = Color.Black;  
                textBoxUpdate.Font = new Font(textBoxUpdate.Font, FontStyle.Regular); 
            }
        }
    }
}
