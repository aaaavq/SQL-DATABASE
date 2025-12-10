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
    public partial class ChangePassword : Form
    {
        private int employeeId;
        private string authorityLevel;

        public ChangePassword(string authorityLevel, int employeeId)
        {
            InitializeComponent();
            this.employeeId = employeeId;
            this.authorityLevel = authorityLevel;
        }

        private void AccountProfile_Load(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            {
                string newPassword = txbNewpassword.Text;
                string confirmPassword = txbReenter.Text;

                if (string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPassword))
                {
                    MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (newPassword != confirmPassword)
                {
                    MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Update password in the database
                bool isPasswordChanged = ChangePasswordInDatabase(employeeId, newPassword);

                if (isPasswordChanged)
                {
                    MessageBox.Show("Password changed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NavigateToNextForm();
                }
                else
                {
                    MessageBox.Show("Failed to change password. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private bool ChangePasswordInDatabase(int employeeId, string newPassword)
        {
            try
            {
                // Replace with your database connection logic
                SqlConnection connection = DatabaseConnection.GetConnection();
                if (connection != null)
                {
                    connection.Open();
                    string sql = "UPDATE Employees SET Password = @password WHERE EmployeeID = @employeeId";
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("password", newPassword);
                    command.Parameters.AddWithValue("employeeId", employeeId);

                    int result = command.ExecuteNonQuery();
                    connection.Close();

                    return result > 0; // Returns true if the update was successful
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false; // Return false if there was an issue
        }

        private void NavigateToNextForm()
        {
            switch (authorityLevel)
            {
                case "Sale1":
                    {
                        SaleForm saleForm = new SaleForm(authorityLevel, employeeId);
                        this.Hide();
                        saleForm.Show();
                        break;
                    }
                case "Warehouse Manager":
                    {
                        WarehouseManagerForm warehouseForm = new WarehouseManagerForm(authorityLevel, employeeId);
                        this.Hide();
                        warehouseForm.Show();
                        break;
                    }
                default:
                    {
                        MessageBox.Show("Invalid authority level.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
            }
        }
    }
}
