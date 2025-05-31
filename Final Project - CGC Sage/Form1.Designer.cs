namespace Final_Project___CGC_Sage
{
    partial class Login_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login_Form));
            this.Button_login = new System.Windows.Forms.Button();
            this.Label_pass = new System.Windows.Forms.Label();
            this.Textbox_pass = new System.Windows.Forms.TextBox();
            this.Textbox_username = new System.Windows.Forms.TextBox();
            this.Label_username = new System.Windows.Forms.Label();
            this.Label_login = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Label_nouser = new System.Windows.Forms.Label();
            this.Label_register = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // Button_login
            // 
            this.Button_login.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Button_login.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Button_login.Font = new System.Drawing.Font("Pixel Operator SC", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_login.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Button_login.Location = new System.Drawing.Point(384, 387);
            this.Button_login.Name = "Button_login";
            this.Button_login.Size = new System.Drawing.Size(142, 55);
            this.Button_login.TabIndex = 10;
            this.Button_login.Text = "Login";
            this.Button_login.UseVisualStyleBackColor = false;
            this.Button_login.Click += new System.EventHandler(this.Button_login_Click);
            // 
            // Label_pass
            // 
            this.Label_pass.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Label_pass.AutoSize = true;
            this.Label_pass.Font = new System.Drawing.Font("Pixel Operator Mono", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_pass.ForeColor = System.Drawing.Color.Gold;
            this.Label_pass.Location = new System.Drawing.Point(379, 292);
            this.Label_pass.Name = "Label_pass";
            this.Label_pass.Size = new System.Drawing.Size(133, 30);
            this.Label_pass.TabIndex = 4;
            this.Label_pass.Text = "Password";
            this.Label_pass.Click += new System.EventHandler(this.Label3_Click);
            // 
            // Textbox_pass
            // 
            this.Textbox_pass.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Textbox_pass.BackColor = System.Drawing.SystemColors.InfoText;
            this.Textbox_pass.Font = new System.Drawing.Font("Pixel Operator", 13.8F);
            this.Textbox_pass.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Textbox_pass.Location = new System.Drawing.Point(383, 325);
            this.Textbox_pass.Multiline = true;
            this.Textbox_pass.Name = "Textbox_pass";
            this.Textbox_pass.PasswordChar = '*';
            this.Textbox_pass.Size = new System.Drawing.Size(742, 39);
            this.Textbox_pass.TabIndex = 5;
            this.Textbox_pass.TextChanged += new System.EventHandler(this.TextBox2_TextChanged);
            // 
            // Textbox_username
            // 
            this.Textbox_username.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Textbox_username.BackColor = System.Drawing.SystemColors.InfoText;
            this.Textbox_username.Font = new System.Drawing.Font("Pixel Operator", 13.8F);
            this.Textbox_username.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Textbox_username.Location = new System.Drawing.Point(383, 231);
            this.Textbox_username.Multiline = true;
            this.Textbox_username.Name = "Textbox_username";
            this.Textbox_username.Size = new System.Drawing.Size(742, 37);
            this.Textbox_username.TabIndex = 3;
            this.Textbox_username.TextChanged += new System.EventHandler(this.Textbox_username_TextChanged);
            // 
            // Label_username
            // 
            this.Label_username.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Label_username.AutoSize = true;
            this.Label_username.Font = new System.Drawing.Font("Pixel Operator Mono", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_username.ForeColor = System.Drawing.Color.Gold;
            this.Label_username.Location = new System.Drawing.Point(378, 186);
            this.Label_username.Name = "Label_username";
            this.Label_username.Size = new System.Drawing.Size(133, 30);
            this.Label_username.TabIndex = 2;
            this.Label_username.Text = "Username";
            this.Label_username.Click += new System.EventHandler(this.Label2_Click);
            // 
            // Label_login
            // 
            this.Label_login.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Label_login.AutoSize = true;
            this.Label_login.Font = new System.Drawing.Font("Pixel Operator HB 8", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_login.ForeColor = System.Drawing.Color.Gold;
            this.Label_login.Location = new System.Drawing.Point(353, 79);
            this.Label_login.Name = "Label_login";
            this.Label_login.Size = new System.Drawing.Size(772, 59);
            this.Label_login.TabIndex = 1;
            this.Label_login.Text = "Welcome Back!";
            this.Label_login.Click += new System.EventHandler(this.Label1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Location = new System.Drawing.Point(-6, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(0, 0);
            this.panel1.TabIndex = 0;
            // 
            // Label_nouser
            // 
            this.Label_nouser.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Label_nouser.AutoSize = true;
            this.Label_nouser.Font = new System.Drawing.Font("Pixel Operator HB", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_nouser.ForeColor = System.Drawing.Color.Gold;
            this.Label_nouser.Location = new System.Drawing.Point(556, 534);
            this.Label_nouser.Name = "Label_nouser";
            this.Label_nouser.Size = new System.Drawing.Size(239, 30);
            this.Label_nouser.TabIndex = 7;
            this.Label_nouser.Text = "Don\'t have a user?";
            this.Label_nouser.Click += new System.EventHandler(this.Label4_Click);
            // 
            // Label_register
            // 
            this.Label_register.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Label_register.AutoSize = true;
            this.Label_register.BackColor = System.Drawing.Color.Transparent;
            this.Label_register.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Label_register.Font = new System.Drawing.Font("Pixel Operator HB", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_register.ForeColor = System.Drawing.Color.Yellow;
            this.Label_register.Location = new System.Drawing.Point(800, 534);
            this.Label_register.Name = "Label_register";
            this.Label_register.Size = new System.Drawing.Size(196, 30);
            this.Label_register.TabIndex = 8;
            this.Label_register.Text = "Register Here\r\n";
            this.Label_register.Click += new System.EventHandler(this.Label5_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1083, 325);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(42, 39);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(1083, 325);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(42, 39);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 23;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip1_Popup);
            // 
            // Login_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1421, 730);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Button_login);
            this.Controls.Add(this.Label_register);
            this.Controls.Add(this.Label_nouser);
            this.Controls.Add(this.Textbox_pass);
            this.Controls.Add(this.Label_pass);
            this.Controls.Add(this.Textbox_username);
            this.Controls.Add(this.Label_username);
            this.Controls.Add(this.Label_login);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login_Form";
            this.Load += new System.EventHandler(this.Login_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Button_login;
        private System.Windows.Forms.Label Label_pass;
        private System.Windows.Forms.TextBox Textbox_pass;
        private System.Windows.Forms.TextBox Textbox_username;
        private System.Windows.Forms.Label Label_username;
        private System.Windows.Forms.Label Label_login;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label Label_nouser;
        private System.Windows.Forms.Label Label_register;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

