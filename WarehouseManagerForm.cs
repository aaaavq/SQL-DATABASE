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
    public partial class WarehouseManagerForm : Form
    {
        string authorityLevel;
        int employeeId;
        public WarehouseManagerForm(string authorityLevel, int employeeId)
        {
            InitializeComponent();
            this.authorityLevel = authorityLevel;
            this.employeeId = employeeId;
        }

        private void WarehouseManagerForm_Load(object sender, EventArgs e)
        {
            SaleForm saleForm = new SaleForm(authorityLevel, employeeId);
            this.Hide();
            saleForm.Show();
        }

        private void btnManageProduct_Click(object sender, EventArgs e)
        {


        }
    }
}
