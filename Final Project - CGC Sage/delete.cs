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
    public partial class delete : Form
    {
        public string MessageContent { get; set; }

        // Constructor that takes a message to display (in case you want to pass it)
        public delete(string messageContent)
        {
            InitializeComponent();
            MessageContent = messageContent;
        }

        private void delete_Load(object sender, EventArgs e)
        {
            // Perform any necessary operations when the form is loaded
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Your original connection string
            string plainConStr = "server=localhost;uid=root;pwd=I_F0rGoT-MyF#CK!nGP@sSW0Rd?!!?;database=sage.db;";

            // Encrypt the connection string using the Guardian class
            string encryptedConStr = Guardian.Encrypt(plainConStr);

            // Display the encrypted string in label1
            label1.Text = encryptedConStr;  // Set the Label's text to the encrypted connection string
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Copy the encrypted connection string from label1 to clipboard
            Clipboard.SetText(label1.Text);  // Copy the content of label1 to clipboard
            MessageBox.Show("Content copied to clipboard!", "Copy Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
