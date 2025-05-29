namespace Final_Project___CGC_Sage
{
    partial class signupForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(signupForm));
            this.textConfirmPassword = new System.Windows.Forms.TextBox();
            this.labelsignuptitle = new System.Windows.Forms.Label();
            this.labelusername = new System.Windows.Forms.Label();
            this.textUsername = new System.Windows.Forms.TextBox();
            this.labelpass = new System.Windows.Forms.Label();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.labelalreadyhaveauser = new System.Windows.Forms.Label();
            this.labelloginhere = new System.Windows.Forms.Label();
            this.buttoncreateuser = new System.Windows.Forms.Button();
            this.labelconfirmpass = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // textConfirmPassword
            // 
            this.textConfirmPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textConfirmPassword.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.textConfirmPassword.Font = new System.Drawing.Font("Pixel Operator", 13.8F);
            this.textConfirmPassword.ForeColor = System.Drawing.SystemColors.Window;
            this.textConfirmPassword.Location = new System.Drawing.Point(138, 401);
            this.textConfirmPassword.Multiline = true;
            this.textConfirmPassword.Name = "textConfirmPassword";
            this.textConfirmPassword.PasswordChar = '*';
            this.textConfirmPassword.Size = new System.Drawing.Size(889, 39);
            this.textConfirmPassword.TabIndex = 23;
            this.textConfirmPassword.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // labelsignuptitle
            // 
            this.labelsignuptitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelsignuptitle.AutoSize = true;
            this.labelsignuptitle.BackColor = System.Drawing.Color.Transparent;
            this.labelsignuptitle.Font = new System.Drawing.Font("Pixel Operator HB 8", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelsignuptitle.ForeColor = System.Drawing.Color.Gold;
            this.labelsignuptitle.Location = new System.Drawing.Point(130, 107);
            this.labelsignuptitle.Name = "labelsignuptitle";
            this.labelsignuptitle.Size = new System.Drawing.Size(882, 43);
            this.labelsignuptitle.TabIndex = 12;
            this.labelsignuptitle.Text = "Let\'s get you started!";
            this.labelsignuptitle.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelusername
            // 
            this.labelusername.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelusername.AutoSize = true;
            this.labelusername.BackColor = System.Drawing.Color.Transparent;
            this.labelusername.Font = new System.Drawing.Font("Pixel Operator Mono", 18F);
            this.labelusername.ForeColor = System.Drawing.Color.Gold;
            this.labelusername.Location = new System.Drawing.Point(133, 182);
            this.labelusername.Name = "labelusername";
            this.labelusername.Size = new System.Drawing.Size(133, 30);
            this.labelusername.TabIndex = 13;
            this.labelusername.Text = "Username";
            this.labelusername.Click += new System.EventHandler(this.labelusername_Click);
            // 
            // textUsername
            // 
            this.textUsername.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textUsername.BackColor = System.Drawing.SystemColors.Desktop;
            this.textUsername.Font = new System.Drawing.Font("Pixel Operator", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textUsername.ForeColor = System.Drawing.SystemColors.Window;
            this.textUsername.Location = new System.Drawing.Point(138, 215);
            this.textUsername.Multiline = true;
            this.textUsername.Name = "textUsername";
            this.textUsername.Size = new System.Drawing.Size(889, 37);
            this.textUsername.TabIndex = 14;
            this.textUsername.TextChanged += new System.EventHandler(this.Textusername_TextChanged);
            // 
            // labelpass
            // 
            this.labelpass.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelpass.AutoSize = true;
            this.labelpass.BackColor = System.Drawing.Color.Transparent;
            this.labelpass.Font = new System.Drawing.Font("Pixel Operator Mono", 18F);
            this.labelpass.ForeColor = System.Drawing.Color.Gold;
            this.labelpass.Location = new System.Drawing.Point(133, 271);
            this.labelpass.Name = "labelpass";
            this.labelpass.Size = new System.Drawing.Size(133, 30);
            this.labelpass.TabIndex = 15;
            this.labelpass.Text = "Password";
            this.labelpass.Click += new System.EventHandler(this.labelpass_Click);
            // 
            // textPassword
            // 
            this.textPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textPassword.BackColor = System.Drawing.SystemColors.InfoText;
            this.textPassword.Font = new System.Drawing.Font("Pixel Operator", 13.8F);
            this.textPassword.ForeColor = System.Drawing.Color.White;
            this.textPassword.Location = new System.Drawing.Point(138, 304);
            this.textPassword.Multiline = true;
            this.textPassword.Name = "textPassword";
            this.textPassword.PasswordChar = '*';
            this.textPassword.Size = new System.Drawing.Size(889, 39);
            this.textPassword.TabIndex = 16;
            this.textPassword.TextChanged += new System.EventHandler(this.textPassword_TextChanged);
            // 
            // labelalreadyhaveauser
            // 
            this.labelalreadyhaveauser.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelalreadyhaveauser.AutoSize = true;
            this.labelalreadyhaveauser.BackColor = System.Drawing.Color.Transparent;
            this.labelalreadyhaveauser.Font = new System.Drawing.Font("Pixel Operator HB", 16.2F, System.Drawing.FontStyle.Bold);
            this.labelalreadyhaveauser.ForeColor = System.Drawing.Color.Gold;
            this.labelalreadyhaveauser.Location = new System.Drawing.Point(388, 581);
            this.labelalreadyhaveauser.Name = "labelalreadyhaveauser";
            this.labelalreadyhaveauser.Size = new System.Drawing.Size(289, 30);
            this.labelalreadyhaveauser.TabIndex = 18;
            this.labelalreadyhaveauser.Text = "Already have a user?";
            this.labelalreadyhaveauser.Click += new System.EventHandler(this.labelalreadyhaveauser_Click);
            // 
            // labelloginhere
            // 
            this.labelloginhere.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelloginhere.AutoSize = true;
            this.labelloginhere.BackColor = System.Drawing.Color.Transparent;
            this.labelloginhere.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelloginhere.Font = new System.Drawing.Font("Pixel Operator HB", 16.2F, System.Drawing.FontStyle.Bold);
            this.labelloginhere.ForeColor = System.Drawing.Color.Yellow;
            this.labelloginhere.Location = new System.Drawing.Point(671, 581);
            this.labelloginhere.Name = "labelloginhere";
            this.labelloginhere.Size = new System.Drawing.Size(153, 30);
            this.labelloginhere.TabIndex = 19;
            this.labelloginhere.Text = "Login Here\r\n";
            this.labelloginhere.Click += new System.EventHandler(this.label5_Click);
            // 
            // buttoncreateuser
            // 
            this.buttoncreateuser.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttoncreateuser.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.buttoncreateuser.Font = new System.Drawing.Font("Pixel Operator SC", 13.8F);
            this.buttoncreateuser.ForeColor = System.Drawing.Color.Black;
            this.buttoncreateuser.Location = new System.Drawing.Point(138, 469);
            this.buttoncreateuser.Name = "buttoncreateuser";
            this.buttoncreateuser.Size = new System.Drawing.Size(165, 40);
            this.buttoncreateuser.TabIndex = 21;
            this.buttoncreateuser.Text = "Create User";
            this.buttoncreateuser.UseVisualStyleBackColor = false;
            this.buttoncreateuser.Click += new System.EventHandler(this.buttoncreateuser_Click);
            // 
            // labelconfirmpass
            // 
            this.labelconfirmpass.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelconfirmpass.AutoSize = true;
            this.labelconfirmpass.BackColor = System.Drawing.Color.Transparent;
            this.labelconfirmpass.Font = new System.Drawing.Font("Pixel Operator Mono", 18F);
            this.labelconfirmpass.ForeColor = System.Drawing.Color.Gold;
            this.labelconfirmpass.Location = new System.Drawing.Point(133, 356);
            this.labelconfirmpass.Name = "labelconfirmpass";
            this.labelconfirmpass.Size = new System.Drawing.Size(253, 30);
            this.labelconfirmpass.TabIndex = 22;
            this.labelconfirmpass.Text = "Confirm Password";
            this.labelconfirmpass.Click += new System.EventHandler(this.label7_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Location = new System.Drawing.Point(-15, 79);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(0, 0);
            this.panel1.TabIndex = 11;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(985, 401);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(42, 39);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 24;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(985, 401);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(42, 39);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 25;
            this.pictureBox1.TabStop = false;
            // 
            // signupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1137, 730);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.textConfirmPassword);
            this.Controls.Add(this.labelconfirmpass);
            this.Controls.Add(this.buttoncreateuser);
            this.Controls.Add(this.labelloginhere);
            this.Controls.Add(this.labelalreadyhaveauser);
            this.Controls.Add(this.textPassword);
            this.Controls.Add(this.labelpass);
            this.Controls.Add(this.textUsername);
            this.Controls.Add(this.labelusername);
            this.Controls.Add(this.labelsignuptitle);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "signupForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "signupForm";
            this.Load += new System.EventHandler(this.signupForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textConfirmPassword;
        private System.Windows.Forms.Label labelsignuptitle;
        private System.Windows.Forms.Label labelusername;
        private System.Windows.Forms.TextBox textUsername;
        private System.Windows.Forms.Label labelpass;
        private System.Windows.Forms.TextBox textPassword;
        private System.Windows.Forms.Label labelalreadyhaveauser;
        private System.Windows.Forms.Label labelloginhere;
        private System.Windows.Forms.Button buttoncreateuser;
        private System.Windows.Forms.Label labelconfirmpass;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}