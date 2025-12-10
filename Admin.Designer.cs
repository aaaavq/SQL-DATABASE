namespace coffee
{
    partial class Admin
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
            this.gbAdminFeature = new System.Windows.Forms.GroupBox();
            this.btnViewStatistic = new System.Windows.Forms.Button();
            this.btnManageOrder = new System.Windows.Forms.Button();
            this.btnManageCategory = new System.Windows.Forms.Button();
            this.btnManageImport = new System.Windows.Forms.Button();
            this.btnManageProduct = new System.Windows.Forms.Button();
            this.btnManageEmployee = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gbAdminFeature.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbAdminFeature
            // 
            this.gbAdminFeature.Controls.Add(this.btnViewStatistic);
            this.gbAdminFeature.Controls.Add(this.btnManageOrder);
            this.gbAdminFeature.Controls.Add(this.btnManageCategory);
            this.gbAdminFeature.Controls.Add(this.btnManageImport);
            this.gbAdminFeature.Controls.Add(this.btnManageProduct);
            this.gbAdminFeature.Controls.Add(this.btnManageEmployee);
            this.gbAdminFeature.Controls.Add(this.pictureBox1);
            this.gbAdminFeature.Location = new System.Drawing.Point(12, 12);
            this.gbAdminFeature.Name = "gbAdminFeature";
            this.gbAdminFeature.Size = new System.Drawing.Size(766, 418);
            this.gbAdminFeature.TabIndex = 0;
            this.gbAdminFeature.TabStop = false;
            this.gbAdminFeature.Text = "Admin feature";
            this.gbAdminFeature.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnViewStatistic
            // 
            this.btnViewStatistic.Location = new System.Drawing.Point(284, 333);
            this.btnViewStatistic.Name = "btnViewStatistic";
            this.btnViewStatistic.Size = new System.Drawing.Size(185, 49);
            this.btnViewStatistic.TabIndex = 5;
            this.btnViewStatistic.Text = "View Statistic";
            this.btnViewStatistic.UseVisualStyleBackColor = true;
            // 
            // btnManageOrder
            // 
            this.btnManageOrder.Location = new System.Drawing.Point(444, 69);
            this.btnManageOrder.Name = "btnManageOrder";
            this.btnManageOrder.Size = new System.Drawing.Size(201, 48);
            this.btnManageOrder.TabIndex = 3;
            this.btnManageOrder.Text = "Manage Order";
            this.btnManageOrder.UseVisualStyleBackColor = true;
            this.btnManageOrder.Click += new System.EventHandler(this.btnManageOrder_Click);
            // 
            // btnManageCategory
            // 
            this.btnManageCategory.Location = new System.Drawing.Point(94, 250);
            this.btnManageCategory.Name = "btnManageCategory";
            this.btnManageCategory.Size = new System.Drawing.Size(201, 51);
            this.btnManageCategory.TabIndex = 2;
            this.btnManageCategory.Text = "Manage Category";
            this.btnManageCategory.UseVisualStyleBackColor = true;
            this.btnManageCategory.Click += new System.EventHandler(this.btnManageCategory_Click);
            // 
            // btnManageImport
            // 
            this.btnManageImport.Location = new System.Drawing.Point(444, 165);
            this.btnManageImport.Name = "btnManageImport";
            this.btnManageImport.Size = new System.Drawing.Size(201, 43);
            this.btnManageImport.TabIndex = 4;
            this.btnManageImport.Text = "Manage Import";
            this.btnManageImport.UseVisualStyleBackColor = true;
            // 
            // btnManageProduct
            // 
            this.btnManageProduct.Location = new System.Drawing.Point(94, 165);
            this.btnManageProduct.Name = "btnManageProduct";
            this.btnManageProduct.Size = new System.Drawing.Size(201, 43);
            this.btnManageProduct.TabIndex = 1;
            this.btnManageProduct.Text = "Manage Product";
            this.btnManageProduct.UseVisualStyleBackColor = true;
            this.btnManageProduct.Click += new System.EventHandler(this.btnManageProduct_Click);
            // 
            // btnManageEmployee
            // 
            this.btnManageEmployee.Location = new System.Drawing.Point(94, 69);
            this.btnManageEmployee.Name = "btnManageEmployee";
            this.btnManageEmployee.Size = new System.Drawing.Size(201, 48);
            this.btnManageEmployee.TabIndex = 0;
            this.btnManageEmployee.Text = "Manage Employee";
            this.btnManageEmployee.UseVisualStyleBackColor = true;
            this.btnManageEmployee.Click += new System.EventHandler(this.btnManageEmployee_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::coffee.Properties.Resources.background_anime_bau_troi_xanh_034129059;
            this.pictureBox1.Location = new System.Drawing.Point(0, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(766, 396);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 455);
            this.Controls.Add(this.gbAdminFeature);
            this.Name = "Admin";
            this.Text = "Admin";
            this.Load += new System.EventHandler(this.Admin_Load);
            this.gbAdminFeature.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbAdminFeature;
        private System.Windows.Forms.Button btnViewStatistic;
        private System.Windows.Forms.Button btnManageImport;
        private System.Windows.Forms.Button btnManageOrder;
        private System.Windows.Forms.Button btnManageCategory;
        private System.Windows.Forms.Button btnManageProduct;
        private System.Windows.Forms.Button btnManageEmployee;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
