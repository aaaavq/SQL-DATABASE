namespace coffee
{
    partial class LoginForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txbPassword = new System.Windows.Forms.TextBox();
            this.txbUsername = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboRole = new System.Windows.Forms.ComboBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txbPassword);
            this.panel1.Controls.Add(this.txbUsername);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cboRole);
            this.panel1.Controls.Add(this.lblRole);
            this.panel1.Controls.Add(this.btnLogin);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(744, 411);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // txbPassword
            // 
            this.txbPassword.Location = new System.Drawing.Point(364, 179);
            this.txbPassword.Name = "txbPassword";
            this.txbPassword.PasswordChar = '*';
            this.txbPassword.Size = new System.Drawing.Size(182, 22);
            this.txbPassword.TabIndex = 1;
            // 
            // txbUsername
            // 
            this.txbUsername.Location = new System.Drawing.Point(364, 109);
            this.txbUsername.Name = "txbUsername";
            this.txbUsername.Size = new System.Drawing.Size(182, 22);
            this.txbUsername.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(222, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "Password:";
            this.label2.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(222, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username:";
            // 
            // cboRole
            // 
            this.cboRole.FormattingEnabled = true;
            this.cboRole.Location = new System.Drawing.Point(364, 243);
            this.cboRole.Name = "cboRole";
            this.cboRole.Size = new System.Drawing.Size(182, 24);
            this.cboRole.TabIndex = 63;
            this.cboRole.SelectedIndexChanged += new System.EventHandler(this.cboRole_SelectedIndexChanged);
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRole.Location = new System.Drawing.Point(222, 246);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(57, 21);
            this.lblRole.TabIndex = 0;
            this.lblRole.Text = "Role:";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(255, 350);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(122, 23);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(235, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(285, 48);
            this.panel3.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(98, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 27);
            this.label3.TabIndex = 0;
            this.label3.Text = "Admin";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(502, 350);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(114, 23);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::coffee.Properties.Resources.eded27136779511_61fffcf0284ae;
            this.pictureBox2.Location = new System.Drawing.Point(3, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(738, 405);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 64;
            this.pictureBox2.TabStop = false;
            // 
            // LoginForm
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(827, 468);
            this.Controls.Add(this.panel1);
            this.Name = "LoginForm";
            this.Text = "Login";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Click += new System.EventHandler(this.LoginForm_Click);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txbPassword;
        private System.Windows.Forms.TextBox txbUsername;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.ComboBox cboRole;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}
