using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace coffee
{
    public partial class Admin : Form
    {
        int employeeId;
        string authorityLevel;
       
        
        public Admin(int employeeId, string authorityLevel)
        {
            this.employeeId = employeeId;
            this.authorityLevel = authorityLevel;
            InitializeComponent();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnManageEmployee_Click(object sender, EventArgs e)
        {
            Manageemployee manageEmployee = new Manageemployee(authorityLevel);
            this.Hide();
            manageEmployee.Show();
        }

        private void btnManageProduct_Click(object sender, EventArgs e)
        {
            SaleForm saleForm = new SaleForm(authorityLevel, employeeId);
            this.Hide();
            saleForm.Show();
        }

        private void btnManageCategory_Click(object sender, EventArgs e)
        {
            
        }

        private void btnManageOrder_Click(object sender, EventArgs e)
        {
            Order_History order_History = new Order_History(this.authorityLevel, this.employeeId);
            this.Hide();
            order_History.Show();
        }
    }
}
