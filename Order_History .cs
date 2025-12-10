using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace coffee
{
    public partial class Order_History : Form
    {
        string authorityLevel;
        int employeeId;

        public Order_History(string authorityLevel, int employeeId)
        {
            InitializeComponent();
            this.authorityLevel = authorityLevel;
            this.employeeId = employeeId;
        }

        private void dtgProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LoadOrderHistory()
        {
            SqlConnection connection = DatabaseConnection.GetConnection();

            if (connection != null)
            {
                connection.Open();
                string query = "SELECT o.OrderDate, " +
                               "e.EmployeeName, " +
                               "c.CustomerName " +  // Added space here
                               "FROM Orders o " +
                               "INNER JOIN Employees e ON o.EmployeeID = e.EmployeeID " +  // Fixed table name
                               "INNER JOIN Customers c ON o.CustomerID = c.CustomerID " +  // Fixed table name
                               "WHERE o.EmployeeID = @employeeID " +  // Added space here
                               "GROUP BY o.OrderDate, e.EmployeeName, c.CustomerName"; // Changed e.EmployeeCode to c.CustomerName

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@employeeID", employeeId); // Added '@' to parameter name
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                adapter.Fill(dataTable);
                dtgOrderHistory.DataSource = dataTable;
            }
        }
        private void RedirectPage()
        {
            {
                switch (this.authorityLevel)
                {
                    case "Admin":
                        {
                            Admin admin = new Admin(employeeId, authorityLevel);
                            this.Hide();
                            admin.Show();
                            break;
                        }
                    case "Warehouse Manager":
                        {
                            WarehouseManagerForm warehouseManagerForm = new WarehouseManagerForm(authorityLevel, employeeId);
                            this.Hide();
                            warehouseManagerForm.Show();
                            break;
                        }
                    case "Sale":
                        {
                            SaleForm saleForm = new SaleForm(authorityLevel, employeeId);
                            this.Hide();
                            saleForm.Show();
                            break;
                        }

                    default:
                        {
                            break;
                        }
                }
            }
        }

        private void OrderHistory_Load(object sender, EventArgs e)
        {
            LoadOrderHistory();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            RedirectPage();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
