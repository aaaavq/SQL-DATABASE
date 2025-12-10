
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
    public partial class Manageemployee : Form
    {

        int employeeId;
        string employeePosition;

        public Manageemployee(string employeePosition)
        {
            employeeId = 0;
            InitializeComponent();
            this.employeePosition = employeePosition;
        }

        

        
        public void ManageEmployeeDetails()
        {
            // Implement logic for managing employee details
            // Use the employeePosition property as needed
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void ManageEmpolyee_Load(object sender, EventArgs e)
        {
            LoadEmployeeData();
            InitializeCombobox();
        }

        private bool ValidateData(string employeeCode,
                                  string employeeName,
                                  string employeePosition,
                                  string authoritylevel,
                                  string username,
                                  string password)
        {
            bool IsValid = true;
            if (employeeCode == null || employeeCode == string.Empty)
            {
                MessageBox.Show(
                    "Employee Code cannot be blank",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtEmployeeCode.Focus();
                IsValid = false;

            }
            else if (employeeName == null || employeeName == string.Empty)
            {
                MessageBox.Show(
                    "Employee Code cannot be blank",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtEmployeeName.Focus();
                IsValid = false;
            }
            else if (employeePosition == null || employeePosition == string.Empty)
            {
                MessageBox.Show(
                    "Employee Code cannot be blank",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtEmployeePosition.Focus();
                IsValid = false;
            }
            else if (authoritylevel == null || authoritylevel == string.Empty)
            {
                MessageBox.Show(
                    "Employee Code cannot be blank",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                cbAuthorityLevel.Focus();
                IsValid = false;
            }
            else if (username == null || username == string.Empty)
            {
                MessageBox.Show(
                    "Employee Code cannot be blank",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtUsername.Focus();
                IsValid = false;
            }
            else if (password == null || password == string.Empty)
            {
                MessageBox.Show(
                    "Employee Code cannot be blank",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtPassword.Focus();
                IsValid = false;
            }
            return IsValid;
        }
        private void LoadEmployeeData()
        {
            SqlConnection connection = DatabaseConnection.GetConnection();
            if (connection != null)
            {
                connection.Open();
                string sql = "SELECT * FROM Employees";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dtgEmployee.DataSource = table;
                connection.Close();

            }
        }
        private void ClearData()
        {
            txtEmployeeCode.Text = string.Empty;
            txtEmployeeName.Text = string.Empty;
            txtEmployeePosition.Text = string.Empty;
            cbAuthorityLevel.SelectedIndex = 0;
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtEmployeeCode.Focus();
        }
        public void InitializeCombobox()
        {
            cbAuthorityLevel.Items.Add("Admin");
            cbAuthorityLevel.Items.Add("Warehouse Manager");
            cbAuthorityLevel.Items.Add("Sale1");
            cbAuthorityLevel.SelectedIndex = 0;

        }
        private bool CheckUserExistence(int employeeId)
        {
            bool isExist = false;
            SqlConnection connection = DatabaseConnection.GetConnection();
            if (connection != null)
            {
                connection.Open();
                string checkCustomerQuery = "SELECT * FROM Employees WHERE Employees = @employeeId";
                SqlCommand command = new SqlCommand(checkCustomerQuery, connection);
                command.Parameters.AddWithValue("employeeId", employeeId);
                SqlDataReader reader = command.ExecuteReader();
                isExist = reader.HasRows;
                connection.Close();

            }
            return isExist;
        }
        private void AddUser(string employeeCode,
                        string employeeName,
                        string employeePosition,
                        string authorityLevel,
                        string username,
                        string password)
        {
            SqlConnection connection = DatabaseConnection.GetConnection();
            if (connection != null)
            {
                connection.Open();
                string sql = "INSERT INTO Employees VALUES (@employeeCode, " +
                             "@employeeName, @employeePosition, " +
                             "@authoritylevel, @username, @password, 0)";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("employeeCode", employeeCode);
                command.Parameters.AddWithValue("employeeName", employeeName);
                command.Parameters.AddWithValue("employeePosition", employeePosition);
                command.Parameters.AddWithValue("authoritylevel", authorityLevel);
                command.Parameters.AddWithValue("username", username);
                command.Parameters.AddWithValue("password", password);
                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show(
                        "Successfully add new user",
                        "Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    ClearData();
                    LoadEmployeeData();
                }
                else
                {
                    MessageBox.Show(
                        "Cannot add new user",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                connection.Close();
            }
        }

            
        private void DeleteUser(int employeeId)
        {
            SqlConnection connection = DatabaseConnection.GetConnection();
            if (connection != null)
            {
                connection.Open();
                string sql = "DELETE Employees WHERE EmployeeID = @employeeId";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("employeeId", employeeId);
                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show(
                        "Successfully delete user",
                        "Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    ClearData();    
                    LoadEmployeeData();
                }
                else
                {
                    MessageBox.Show(
                        "Cannot delete user",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                connection.Close();
            }
        }
        private void SearchUser(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                LoadEmployeeData();
            }
            else
            {
                SqlConnection connection = DatabaseConnection.GetConnection();
                if (connection != null)
                {
                    connection.Open();
                    string query = "SELECT * FROM Employees WHERE " +
                                   "(EmployeeCode LIKE @search OR " +
                                   "EmployeeName LIKE @search OR " +
                                   "Position LIKE @search OR " +
                                   "AuthorityLevel LIKE @search OR " +
                                   "Username LIKE @search OR " +
                                   "Password LIKE @search)";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@search", "%" + search + "%"); // Thêm ký tự % để tìm kiếm

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dtgEmployee.DataSource = table;

                    connection.Close(); // Đảm bảo đóng kết nối
                }
            }
        }

        private bool ValidateEmployeeData(string employeeCode, string employeeName, string employeePosition, string authorityLevel, string username, string password)
        {
            // Kiểm tra mã nhân viên
            if (string.IsNullOrWhiteSpace(employeeCode))
            {
                MessageBox.Show("Mã nhân viên không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Kiểm tra tên nhân viên
            if (string.IsNullOrWhiteSpace(employeeName))
            {
                MessageBox.Show("Tên nhân viên không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Kiểm tra vị trí
            if (string.IsNullOrWhiteSpace(employeePosition))
            {
                MessageBox.Show("Vị trí không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Kiểm tra quyền hạn
            if (string.IsNullOrWhiteSpace(authorityLevel))
            {
                MessageBox.Show("Quyền hạn không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Kiểm tra tên đăng nhập
            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Tên đăng nhập không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Kiểm tra mật khẩu
            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Mật khẩu không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true; // Nếu tất cả đều hợp lệ
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string employeeCode = txtEmployeeCode.Text;
            string employeeName = txtEmployeeName.Text;
            string employeePosition = txtEmployeePosition.Text;
            string authorityLevel = cbAuthorityLevel.SelectedItem.ToString();
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            
            bool IsValid = ValidateData(employeeCode,
                                        employeeName,
                                        employeePosition,
                                        authorityLevel,
                                        username,
                                        password);
            if (IsValid)
            {
                AddUser(employeeCode, employeeName, employeePosition, authorityLevel, username, password);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string employeeCode = txtEmployeeCode.Text.Trim();
            string employeeName = txtEmployeeName.Text.Trim();
            string employeePosition = txtEmployeePosition.Text.Trim();
            string authorityLevel = cbAuthorityLevel.SelectedItem?.ToString()?.Trim();
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Gọi phương thức UpdateUser
            UpdateUser(employeeCode, employeeName, employeePosition, authorityLevel, username, password);
        }

        private void UpdateUser(
                    string employeeCode,
                    string employeeName,
                    string employeePosition,
                    string authorityLevel,
                    string username,
                    string password)
        {
            SqlConnection connection = DatabaseConnection.GetConnection();
            if (connection != null)
            {
                try
                {
                    connection.Open();
                    string sql = "UPDATE Employees SET EmployeeCode = @employeeCode, " +
                                 "EmployeeName = @employeeName, " +
                                 "Position = @employeePosition, " +
                                 "AuthorityLevel = @authorityLevel, " +
                                 "Username = @username, " +
                                 "Password = @password " + // Loại bỏ dấu phẩy dư thừa
                                 "WHERE EmployeeID = @employeeId";
                    SqlCommand command = new SqlCommand(sql, connection);

                    // Gắn tham số cho câu lệnh SQL
                    command.Parameters.AddWithValue("@employeeCode", employeeCode);
                    command.Parameters.AddWithValue("@employeeName", employeeName);
                    command.Parameters.AddWithValue("@employeePosition", employeePosition);
                    command.Parameters.AddWithValue("@authorityLevel", authorityLevel);
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);
                    command.Parameters.AddWithValue("@employeeId", employeeId);

                    int result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show(
                            "Successfully updated user",
                            "Information",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        ClearData();
                        LoadEmployeeData();
                    }
                    else
                    {
                        MessageBox.Show(
                            "Cannot update user",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"An error occurred: {ex.Message}",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                                                  "Do you want to delete this user",
                                                  "Warning",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                DeleteUser(employeeId);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            switch (employeePosition)
            {
                case "Admin":
                    {
                        Admin admin = new Admin(employeeId, employeePosition);
                        this.Hide();
                        admin.Show();
                        break;
                    }
                case "Warehouse Manager":
                    {
                        WarehouseManagerForm warehouseManagerForm = new WarehouseManagerForm(employeePosition, employeeId);
                        this.Hide();
                        warehouseManagerForm.Show();
                        break;
                    }
                case "Sale":
                    {
                        SaleForm saleForm = new SaleForm(employeePosition, employeeId);
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


        private void btnClear_Click(object sender, EventArgs e)
        {

            ClearData();

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string search = txtSearch.Text;
            SearchUser(search);
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void dtgEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dtgEmployee.CurrentCell.RowIndex;
            if (index != -1)
            {
                employeeId = Convert.ToInt32(dtgEmployee.Rows[index].Cells[0].Value);
                txtEmployeeCode.Text = dtgEmployee.Rows[index].Cells[1].Value.ToString();
                txtEmployeeName.Text = dtgEmployee.Rows[index].Cells[2].Value.ToString();
                txtEmployeePosition.Text = dtgEmployee.Rows[index].Cells[3].Value.ToString();
                string authorityLevel = dtgEmployee.Rows[index].Cells[4].Value.ToString();
                if (authorityLevel == "Admin")
                {
                    cbAuthorityLevel.SelectedIndex = 0;
                }
                else if (authorityLevel == "Warehouse Manager")
                {
                    cbAuthorityLevel.SelectedIndex = 1;
                }
                else if (authorityLevel == "Sale")
                {
                    cbAuthorityLevel.SelectedIndex = 2;
                }
                txtUsername.Text = dtgEmployee.Rows[index].Cells[5].Value.ToString();
                txtPassword.Text = dtgEmployee.Rows[index].Cells[6].Value.ToString();
            }
        }

        private void dtgEmployee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cbAuthorityLevel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
