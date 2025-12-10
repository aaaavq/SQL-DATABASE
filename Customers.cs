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
    public partial class Customers : Form
    {
        private int customerID;
        private string authorityLevel;
        private int employeeId;


        
            
        public Customers(string authorityLevel, int employeeId)
        {
            
            InitializeComponent();
            this.authorityLevel = authorityLevel;
            this.employeeId = employeeId;
            this.customerID = 0;
        }

        private void ChangeButtonStatus(bool buttonStatus)
        {
            btnUpdate.Enabled = buttonStatus;
            btnDelete.Enabled = buttonStatus;
            btnAdd.Enabled = buttonStatus;
        }

        private void FlushCustomerId()
        {
            this.customerID = 0;
            ChangeButtonStatus(false);
        }

        private bool ValidateData(string customerCode,
                          string customerName,
                          string phone,
                          string address)
        {
            bool isValid = true;

            if (string.IsNullOrEmpty(customerCode))
            {
                MessageBox.Show(
                    "Customer Code cannot be blank",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtCustomerCode.Focus();
                isValid = false;
            }
            else if (string.IsNullOrEmpty(customerName))
            {
                MessageBox.Show(
                    "Customer Name cannot be blank",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtCustomerName.Focus();
                isValid = false;
            }
            else if (string.IsNullOrEmpty(phone))
            {
                MessageBox.Show(
                    "Phone cannot be blank",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtPhone.Focus();
                isValid = false;
            }
            else if (string.IsNullOrEmpty(address))
            {
                MessageBox.Show(
                    "Address cannot be blank",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtAddress.Focus();
                isValid = false;
            }
            

            return isValid;
        }

        

        private void LoadCustomersData()
        {
            SqlConnection connection = DatabaseConnection.GetConnection();
            if (connection != null)
            {
                connection.Open();
                string query = "SELECT customerID, customerCode, customerName, phone, address FROM Customers";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();

                    adapter.Fill(dataTable);
                    dtgCustomer.DataSource = dataTable; // dtgCustomers là tên của DataGridView
                }

            }
        }


        private bool CheckUserExistence(int customerID)
        {
            bool isExit = false;
            SqlConnection connection = DatabaseConnection.GetConnection();
            if (connection != null)
            {
                connection.Open();
                string CheckCustomerQuery = "SELECT * FROM Customers WHERE CustomerID = @customerID";
                SqlCommand command = new SqlCommand(CheckCustomerQuery, connection);
                command.Parameters.AddWithValue("customerID", customerID);
                SqlDataReader reader = command.ExecuteReader();
                isExit = reader.HasRows;
                connection.Close();

            }
            return isExit;
        }

        

        private void lbCustomertype_Click(object sender, EventArgs e)
        {

        }

        private void lbCustomername_Click(object sender, EventArgs e)
        {

        }

        private bool ValidateCustomerData(string customerCode, string customerName, string phone, string address, string product, decimal quantity, DateTime date)
        {
            // Kiểm tra mã khách hàng
            if (string.IsNullOrWhiteSpace(customerCode))
            {
                MessageBox.Show("Mã khách hàng không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Kiểm tra tên khách hàng
            if (string.IsNullOrWhiteSpace(customerName))
            {
                MessageBox.Show("Tên khách hàng không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Kiểm tra số điện thoại
            if (string.IsNullOrWhiteSpace(phone))
            {
                MessageBox.Show("Số điện thoại không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Kiểm tra địa chỉ
            if (string.IsNullOrWhiteSpace(address))
            {
                MessageBox.Show("Địa chỉ không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            

            return true; // Nếu tất cả đều hợp lệ
        }
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            string customerCode = txtCustomerCode.Text;
            string customerName = txtCustomerName.Text;
            string phone = txtPhone.Text;
            string address = txtAddress.Text;
            
            bool isValid = ValidateCustomerData(customerCode, customerName, phone, address);
            if (isValid)
            {
                AddCustomer(customerCode, customerName, phone, address);
            }
        }

        private bool ValidateCustomerData(string customerCode, string customerName, string phone, string address)
        {
            // Implement your validation logic here
            // Return true if the data is valid, false otherwise
            return true;
        }

        


        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Customers_Load(object sender, EventArgs e)
        {
            LoadCustomersData();
        }

        

        private void ClearCustomerData()
        {
            
            txtCustomerCode.Text = string.Empty;
            txtCustomerName.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtAddress.Text = string.Empty;
            
            txtCustomerCode.Focus();
        }
        private bool CheckCustomerExistence(string customerCode)
        {
            bool isExist = false;
            SqlConnection connection = DatabaseConnection.GetConnection();
            if (connection != null)
            {
                connection.Open();
                string checkCustomerQuery = "SELECT * FROM Customers WHERE CustomerID = @customerId";
                SqlCommand command = new SqlCommand(checkCustomerQuery, connection);
                command.Parameters.AddWithValue("@customerCode", customerCode);
                SqlDataReader reader = command.ExecuteReader();
                isExist = reader.HasRows;
                reader.Close();
                connection.Close();
            }
            return isExist;
        }

        private void AddCustomer(string customerCode,
                         string customerName,
                         string phone,
                         string address)
                         
        {
            SqlConnection connection = DatabaseConnection.GetConnection();
            if (connection != null)
            {
                connection.Open();
                string query = "INSERT INTO Customers (CustomerCode, CustomerName, phone, address) " +
                             "VALUES (@customerCode, @customerName, @phone, @address)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@customerCode", customerCode);
                command.Parameters.AddWithValue("@customerName", customerName);
                command.Parameters.AddWithValue("@phone", phone);
                command.Parameters.AddWithValue("@address", address);
                
                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show(
                        "Successfully added new customer",
                        "Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    
                }
                else
                {
                    MessageBox.Show(
                        "Cannot add new customer",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                connection.Close();
                
                LoadCustomersData();
            }
        }

        private void UpdateCustomer(int customerID, string customerCode, string customerName, string phone, string address)
        {
            SqlConnection connection = DatabaseConnection.GetConnection();
            if (connection != null)
            {
                connection.Open();
                string query = "UPDATE Customers SET " +
                               "CustomerCode = @customerCode, " +
                               "CustomerName = @customerName, " +
                               "Phone = @phone, " +
                               "Address = @address " +  // Xóa dấu phẩy ở đây
                               "WHERE CustomerID = @customerID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@customerCode", customerCode);
                command.Parameters.AddWithValue("@customerName", customerName);
                command.Parameters.AddWithValue("@phone", phone);
                command.Parameters.AddWithValue("@address", address);
                command.Parameters.AddWithValue("@customerID", customerID);
                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Customer updated successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearCustomerData();
                    LoadCustomersData();
                }
                else
                {
                    MessageBox.Show("Cannot update customer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                connection.Close();
            }
        }

        private void DeleteCustomer(int customerId)
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                if (connection != null)
                {
                    connection.Open();

                    // Xóa OrderDetail trước
                    string deleteOrderDetailQuery = "DELETE FROM OrderDetail WHERE OrderID IN " +
                                                     "(SELECT OrderID FROM Orders WHERE CustomerID = @CustomerID)";
                    using (SqlCommand command = new SqlCommand(deleteOrderDetailQuery, connection))
                    {
                        command.Parameters.AddWithValue("@CustomerID", customerId);
                        command.ExecuteNonQuery();
                    }

                    // Xóa Orders
                    string deleteOrderQuery = "DELETE FROM Orders WHERE CustomerID = @CustomerID";
                    using (SqlCommand command = new SqlCommand(deleteOrderQuery, connection))
                    {
                        command.Parameters.AddWithValue("@CustomerID", customerId);
                        command.ExecuteNonQuery();
                    }

                    // Xóa Customer
                    string deleteCustomerQuery = "DELETE FROM Customers WHERE CustomerID = @CustomerID";
                    using (SqlCommand command = new SqlCommand(deleteCustomerQuery, connection))
                    {
                        command.Parameters.AddWithValue("@CustomerID", customerId);
                        int deleteCustomerResult = command.ExecuteNonQuery();

                        if (deleteCustomerResult > 0)
                        {
                            MessageBox.Show(
                                "Successfully deleted customer",
                                "Information",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            ClearCustomerData();
                            LoadCustomersData();
                        }
                        else
                        {
                            MessageBox.Show(
                                "Cannot delete customer",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                    }

                    connection.Close();
                }
            }
        }

        private void SearchCustomer(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                LoadCustomersData();
            }
            else
            { 
                SqlConnection connection = DatabaseConnection.GetConnection();
            
            
                connection.Open();
                string query = "SELECT * FROM Customers WHERE CustomerCode LIKE @search OR CustomerName LIKE @search OR Phone LIKE @search OR address LIKE @search";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.SelectCommand.Parameters.AddWithValue("search", "%" + search + "%");
                DataTable table = new DataTable();
                adapter.Fill(table);
                dtgCustomer.DataSource = table;
                connection.Close();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (customerID > 0)
            {
                bool isUserExist = CheckUserExistence(customerID);
                if (isUserExist)
                {
                    string customerCode = txtCustomerCode.Text;
                    string customerName = txtCustomerName.Text;
                    string phone = txtPhone.Text;
                    string address = txtAddress.Text;
                    bool isValid = ValidateData(customerCode, customerName, phone, address);
                    if (isValid)
                    {
                        // Gọi phương thức UpdateCustomer
                        UpdateCustomer(customerID, customerCode, customerName, phone, address);
                    }
                    else
                {
                    MessageBox.Show(
                        "No customer found",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
                }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (customerID > 0)
            {
                DialogResult result = MessageBox.Show(
                                                    "Do you want to delete this customer with all related date?",
                                                    "Warning",
                                                    MessageBoxButtons.OKCancel,
                                                    MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    bool isUserExist = CheckUserExistence(customerID);
                    if (isUserExist)
                    {
                        DeleteCustomer(customerID);
                    }
                    else
                    {
                        MessageBox.Show(
                                    "No customer found",
                                    "Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);

                    }
                }
            }
        }



        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            string search = txtSearch.Text;
            SearchCustomer(search);
        }

        private void dtgCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        

        private void dtgCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            switch (authorityLevel)
            {
                case "Admin":
                    {
                        Admin admin = new Admin(this.employeeId, this.authorityLevel);
                        this.Hide();
                        admin.Show();
                        break;
                    }
                case "Warehouse Manager":
                    {
                        WarehouseManagerForm warehouseManagerForm = new WarehouseManagerForm(this.authorityLevel , this.employeeId);
                        this.Hide();
                        warehouseManagerForm.Show();
                        break;
                    }
                case "Sale":
                    {
                        SaleForm saleForm = new SaleForm(this.authorityLevel, this.employeeId);
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

        private void dtgProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dtgCustomer.CurrentCell.RowIndex;
            if (index > -1)
            {
                customerID = (int)dtgCustomer.Rows[index].Cells[0].Value;
                txtCustomerCode.Text = dtgCustomer.Rows[index].Cells[1].Value.ToString();
                txtCustomerName.Text = dtgCustomer.Rows[index].Cells[2].Value.ToString();
                txtPhone.Text = dtgCustomer.Rows[index].Cells[3].Value.ToString();
                txtAddress.Text = dtgCustomer.Rows[index].Cells[4].Value.ToString();
                
            }
        }
        private void dtgCustomer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dtgCustomer.CurrentCell.RowIndex;
            if (index > -1)
            {
                customerID = (int)dtgCustomer.Rows[index].Cells[0].Value;
                string customerName = dtgCustomer.Rows[index].Cells[2].Value.ToString();

            }
        }
    }
}
