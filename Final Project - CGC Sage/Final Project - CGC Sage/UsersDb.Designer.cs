namespace Final_Project___CGC_Sage
{
    partial class UsersDb
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsersDb));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnDeleteUsers = new System.Windows.Forms.Button();
            this.btnDeleteAllUsers = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textboxSearch = new System.Windows.Forms.TextBox();
            this.pictureBoxSearch = new System.Windows.Forms.PictureBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.textBoxUpdate = new System.Windows.Forms.TextBox();
            this.pictureBoxRefresh = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRefresh)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1147, 582);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnDeleteUsers
            // 
            this.btnDeleteUsers.BackColor = System.Drawing.Color.IndianRed;
            this.btnDeleteUsers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteUsers.Location = new System.Drawing.Point(782, 600);
            this.btnDeleteUsers.Name = "btnDeleteUsers";
            this.btnDeleteUsers.Size = new System.Drawing.Size(178, 39);
            this.btnDeleteUsers.TabIndex = 1;
            this.btnDeleteUsers.Text = "Delete user";
            this.btnDeleteUsers.UseVisualStyleBackColor = false;
            this.btnDeleteUsers.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnDeleteAllUsers
            // 
            this.btnDeleteAllUsers.BackColor = System.Drawing.Color.Firebrick;
            this.btnDeleteAllUsers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteAllUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteAllUsers.Location = new System.Drawing.Point(966, 600);
            this.btnDeleteAllUsers.Name = "btnDeleteAllUsers";
            this.btnDeleteAllUsers.Size = new System.Drawing.Size(193, 39);
            this.btnDeleteAllUsers.TabIndex = 2;
            this.btnDeleteAllUsers.Text = "Delete All users";
            this.btnDeleteAllUsers.UseVisualStyleBackColor = false;
            this.btnDeleteAllUsers.Click += new System.EventHandler(this.btnDeleteAllUsers_Click);
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(670, 600);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 39);
            this.button1.TabIndex = 3;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // textboxSearch
            // 
            this.textboxSearch.Location = new System.Drawing.Point(12, 600);
            this.textboxSearch.Multiline = true;
            this.textboxSearch.Name = "textboxSearch";
            this.textboxSearch.Size = new System.Drawing.Size(456, 39);
            this.textboxSearch.TabIndex = 4;
            // 
            // pictureBoxSearch
            // 
            this.pictureBoxSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxSearch.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxSearch.Image")));
            this.pictureBoxSearch.Location = new System.Drawing.Point(414, 600);
            this.pictureBoxSearch.Name = "pictureBoxSearch";
            this.pictureBoxSearch.Size = new System.Drawing.Size(54, 39);
            this.pictureBoxSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxSearch.TabIndex = 5;
            this.pictureBoxSearch.TabStop = false;
            this.pictureBoxSearch.Click += new System.EventHandler(this.pictureBoxSearch_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.ForestGreen;
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(547, 600);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(117, 39);
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // textBoxUpdate
            // 
            this.textBoxUpdate.Location = new System.Drawing.Point(338, 542);
            this.textBoxUpdate.Multiline = true;
            this.textBoxUpdate.Name = "textBoxUpdate";
            this.textBoxUpdate.Size = new System.Drawing.Size(456, 39);
            this.textBoxUpdate.TabIndex = 7;
            this.textBoxUpdate.Visible = false;
            this.textBoxUpdate.TextChanged += new System.EventHandler(this.textBoxUpdate_TextChanged);
            // 
            // pictureBoxRefresh
            // 
            this.pictureBoxRefresh.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxRefresh.Image")));
            this.pictureBoxRefresh.Location = new System.Drawing.Point(474, 600);
            this.pictureBoxRefresh.Name = "pictureBoxRefresh";
            this.pictureBoxRefresh.Size = new System.Drawing.Size(56, 39);
            this.pictureBoxRefresh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxRefresh.TabIndex = 8;
            this.pictureBoxRefresh.TabStop = false;
            this.pictureBoxRefresh.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // UsersDb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1171, 651);
            this.Controls.Add(this.pictureBoxRefresh);
            this.Controls.Add(this.textBoxUpdate);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.pictureBoxSearch);
            this.Controls.Add(this.textboxSearch);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnDeleteAllUsers);
            this.Controls.Add(this.btnDeleteUsers);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UsersDb";
            this.Text = "UsersDb";
            this.Load += new System.EventHandler(this.UsersDb_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRefresh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnDeleteUsers;
        private System.Windows.Forms.Button btnDeleteAllUsers;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textboxSearch;
        private System.Windows.Forms.PictureBox pictureBoxSearch;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox textBoxUpdate;
        private System.Windows.Forms.PictureBox pictureBoxRefresh;
    }
}