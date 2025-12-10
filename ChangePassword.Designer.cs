namespace coffee
{
    partial class ChangePassword
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.txbNewpassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txbReenter = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txbNewpassword);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Location = new System.Drawing.Point(80, 54);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(519, 49);
            this.panel3.TabIndex = 6;
            // 
            // txbNewpassword
            // 
            this.txbNewpassword.Location = new System.Drawing.Point(220, 14);
            this.txbNewpassword.Name = "txbNewpassword";
            this.txbNewpassword.PasswordChar = '*';
            this.txbNewpassword.Size = new System.Drawing.Size(268, 22);
            this.txbNewpassword.TabIndex = 2;
            this.txbNewpassword.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(25, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 21);
            this.label4.TabIndex = 0;
            this.label4.Text = "New Password:";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txbReenter);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Location = new System.Drawing.Point(80, 137);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(519, 49);
            this.panel4.TabIndex = 7;
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // txbReenter
            // 
            this.txbReenter.Location = new System.Drawing.Point(220, 16);
            this.txbReenter.Name = "txbReenter";
            this.txbReenter.PasswordChar = '*';
            this.txbReenter.Size = new System.Drawing.Size(268, 22);
            this.txbReenter.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(22, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(183, 21);
            this.label5.TabIndex = 0;
            this.label5.Text = "Re-enter password:";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(314, 204);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(113, 23);
            this.btnUpdate.TabIndex = 8;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(464, 204);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(117, 23);
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 282);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Name = "ChangePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChangePassword";
            this.Load += new System.EventHandler(this.AccountProfile_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txbNewpassword;
        private System.Windows.Forms.TextBox txbReenter;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnExit;
    }
}
