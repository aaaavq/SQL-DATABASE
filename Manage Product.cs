using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace coffee
{
    public partial class SaleForm : Form
    {
        private int productID;
        private string authorityLevel;
        private int userID;
        public SaleForm(string authorityLevel, int userID)
        {
            InitializeComponent();
            this.userID = userID;
            this.authorityLevel = authorityLevel;
            productID = 0;

        }

        private void LoadCategoryCombobox()
        {
            SqlConnection connection = DatabaseConnection.GetConnection();
            if (connection != null)
            {
                connection.Open();
                string query = "SELECT CategoryID FROM Category";
                SqlDataAdapter adapter = new SqlDataAdapter(query,connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                cbCategory.DataSource = dataTable;
                cbCategory.DisplayMember = "CategoryID";
                cbCategory.ValueMember = "CategoryID";
            }
        }

        private bool ValidateData(String productCode,
            String productName,
            String productPrice,
            string productQuantity)
        {
            double temp;
            int temp2;
            if (String.IsNullOrEmpty(productName)) { return false; }
            if (String.IsNullOrEmpty(productPrice)) {  return false; }
            if (!double.TryParse(productPrice, out temp)) { return false; }
            if (string.IsNullOrEmpty(productQuantity)) { return false; }
            return int.TryParse(productQuantity, out temp2);
        }

        private void UploadFile(String filter, string path)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = filter;
            openFileDialog.Title = "Select a file to upload";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string sourceFilePath = openFileDialog.FileName;
                string targetDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Upload");
                string targetFilePath = Path.Combine(targetDirectory,Path.GetFileName(sourceFilePath));

                try
                {
                    if (!Directory.Exists(targetDirectory))
                    {
                        Directory.CreateDirectory(targetDirectory);
                    }

                    File.Copy(sourceFilePath, targetFilePath, overwrite: true);
                    txtProductImg.Text = targetFilePath;
                    MessageBox.Show("File uploaded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error uploading file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void LoadProductData()
        {
            SqlConnection connection = DatabaseConnection.GetConnection();
            if (connection != null)
            {
                connection.Open();
                string query = "Select * FROM CoffeeProducts";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dtgProduct.DataSource = dataTable;
                connection.Close();
            }

        }

        private void ClearData()
        {
            txtProductCode.Text = string.Empty;
            txtProductName.Text = string.Empty;
            txtProductImg.Text = string.Empty;
            txtProductPrice.Text = string.Empty;
            txtProductQuantity.Text = string.Empty;
            txtSearch.Text = string.Empty;
        }

        private void AddCoffeeProducts()
        {
            SqlConnection connection = DatabaseConnection.GetConnection();
            if (connection != null) 
            {
                connection.Open();
                string productCode = txtProductCode.Text;
                string productName = txtProductName.Text;
                string productImg = txtProductImg.Text;
                string price = txtProductPrice.Text;
                string quantity = txtProductQuantity.Text;
                int categoryID = Convert.ToInt32(cbCategory.SelectedValue);

                if (ValidateData(productCode, productName, price, quantity))
                {
                    string sql = "INSERT INTO CoffeeProducts VALUES (" +
    "@productCode, @productName, @productPrice, @productQuantity, @productImg, @categoryID)";

                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("productCode", productCode);
                    command.Parameters.AddWithValue("productName", productName);
                    command.Parameters.AddWithValue("productPrice", Convert.ToDouble(price));
                    command.Parameters.AddWithValue("productQuantity", Convert.ToInt32(quantity));
                    command.Parameters.AddWithValue("productImg", productImg);
                    command.Parameters.AddWithValue("categoryID", categoryID);

                    int result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show(
                            "Successfully add new product",
                            "Information",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        ClearData();
                        LoadProductData();

                    }
                    else
                    {
                        MessageBox.Show(
                            "Cannot add new product",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

                    }
                    connection.Close();
                }
            }
        }

        private void UpdateCoffeeProducts()
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                if (connection != null)
                {
                    connection.Open();
                    string productCode = txtProductCode.Text;
                    string productName = txtProductName.Text;
                    string productImg = txtProductImg.Text;
                    string price = txtProductPrice.Text;
                    string quantity = txtProductQuantity.Text;
                    int categoryID;

                    // Kiểm tra xem giá trị categoryID có hợp lệ không
                    if (!int.TryParse(cbCategory.SelectedValue.ToString(), out categoryID))
                    {
                        MessageBox.Show("Invalid category selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (ValidateData(productCode, productName, price, quantity))
                    {
                        string sql = "UPDATE CoffeeProducts SET " +
                                     "productCode = @productCode, " +
                                     "productName = @productName, " +
                                     "price = @productPrice, " +
                                     "stock_quantity = @productQuantity, " +
                                     "image_url = @productImg, " +
                                     "categoryID = @categoryID " +
                                     "WHERE ProductID = @productID";

                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            command.Parameters.AddWithValue("@productCode", productCode);
                            command.Parameters.AddWithValue("@productName", productName);

                            // Kiểm tra và chuyển đổi giá trị price và quantity
                            if (!double.TryParse(price, out double productPrice))
                            {
                                MessageBox.Show("Invalid price value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            if (!int.TryParse(quantity, out int productQuantity))
                            {
                                MessageBox.Show("Invalid quantity value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            command.Parameters.AddWithValue("@productPrice", productPrice);
                            command.Parameters.AddWithValue("@productQuantity", productQuantity);
                            command.Parameters.AddWithValue("@productImg", productImg);
                            command.Parameters.AddWithValue("@categoryID", categoryID);
                            command.Parameters.AddWithValue("@productID", this.productID);

                            int result = command.ExecuteNonQuery();
                            if (result > 0)
                            {
                                MessageBox.Show(
                                    "Successfully updated product",
                                    "Information",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                                ClearData();
                                LoadProductData();
                            }
                            else
                            {
                                MessageBox.Show(
                                    "Cannot update product. Product may not exist.",
                                    "Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(
                            "Validation failed. Please check your input.",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show(
                        "Connection to the database failed.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }


        private bool IsProductInOrder(int productID)
        {
            SqlConnection connection = DatabaseConnection.GetConnection();
            if (connection != null)
            {
                connection.Open();
                string sql = "SELECT COUNT(*) FROM OrderDetail WHERE productID = @productID";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("productID", productID);
                int result = (int)command.ExecuteScalar();
                connection.Close();
                return result > 0;


            }
            return false;
        }


        private void DeleteCoffeeProducts()
        {
            // Ask for confirmation
            DialogResult dialogResult = MessageBox.Show("Do you want to delete the product?",
                                                        "Warning",
                                                        MessageBoxButtons.OKCancel,
                                                        MessageBoxIcon.Question);
            if (dialogResult == DialogResult.OK) // Sửa từ Yes thành OK
            {
                if (!IsProductInOrder(this.productID))
                {
                    using (SqlConnection connection = DatabaseConnection.GetConnection())
                    {
                        if (connection != null)
                        {
                            // Open the connection
                            connection.Open();

                            // Declare query
                            string sql = "DELETE FROM CoffeeProducts WHERE ProductID = @productId";

                            // Declare SqlCommand variable to manipulate query
                            using (SqlCommand command = new SqlCommand(sql, connection))
                            {
                                // Add parameters
                                command.Parameters.AddWithValue("@productId", this.productID); // Sửa tên tham số

                                // Execute query and get the result
                                int result = command.ExecuteNonQuery();

                                // Check result
                                if (result > 0)
                                {
                                    MessageBox.Show(
                                        "Successfully deleted product", // Sửa thông báo cho đúng
                                        "Information",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                                    ClearData();
                                    LoadProductData();
                                }
                                else
                                {
                                    MessageBox.Show(
                                        "Cannot delete product", // Sửa thông báo cho đúng
                                        "Error",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show(
                        "Product is in another order\nCannot delete",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void SearchCoffeeProducts(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                LoadProductData();
            }
            else
            {
                SqlConnection connection = DatabaseConnection.GetConnection();
                if (connection != null)
                {
                    connection.Open();
                    string sql = "SELECT p.productID, p.productCode, p.productName, p.price, " +
                        "p.stock_quantity, p.image_url, c.categoryName" +
                        "FROM CoffeeProducts p " +
                        "INNER JOIN Category c " +
                        "ON p.categoryID = c.CategoryID" +
                        "WHERE p.productCode LIKE @search" +
                        "OR p.productName LIKE @search " +
                        "OR c.categoryName LIKE @search";

                    SqlDataAdapter adapter = new SqlDataAdapter(sql,connection);
                    adapter.SelectCommand.Parameters.AddWithValue("search", "%" + search + "%");
                    DataTable data = new DataTable();
                    adapter.Fill(data);
                    dtgProduct.DataSource = data;
                    connection.Close();
                }
                
            }
        }


        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void personalInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void logOutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void personalInformationToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            
        }

        private void TableManager_Load(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void accountInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void lbCustomercode_Click(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void ManageProduct_Load(object sender, EventArgs e)
        {
            LoadProductData();
            LoadCategoryCombobox();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddCoffeeProducts();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateCoffeeProducts();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteCoffeeProducts();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            switch (authorityLevel)
            {
                case "Admin":
                    {
                        Admin admin = new Admin(this.userID, this.authorityLevel);
                        this.Hide();
                        admin.Show();
                        break;
                    }
                case "Warehouse Manager":
                    {
                        WarehouseManagerForm warehouseManagerForm = new WarehouseManagerForm(this.authorityLevel, this.userID);
                        this.Hide();
                        warehouseManagerForm.Show();
                        break;
                    }
                case "Sale":
                    {
                        SaleForm saleForm = new SaleForm(this.authorityLevel, this.userID);
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
            int index = dtgProduct.CurrentCell.RowIndex;
            if (index != -1 && !dtgProduct.Rows[index].IsNewRow)
            {
                productID = Convert.ToInt32(dtgProduct.Rows[index].Cells[0].Value);
                txtProductCode.Text = dtgProduct.Rows[index].Cells[1].Value.ToString();
                txtProductName.Text = dtgProduct.Rows[index].Cells[2].Value.ToString();
                txtProductPrice.Text = dtgProduct.Rows[index].Cells[3].Value.ToString();
                txtProductQuantity.Text = dtgProduct.Rows[index].Cells[4].Value.ToString();
                txtProductImg.Text = dtgProduct.Rows[index].Cells[5].Value.ToString();
                string categoryID = dtgProduct.Rows[index].Cells[6].Value.ToString();

                for (int i = 0; i < cbCategory.Items.Count; i++)
                {
                    if (cbCategory.SelectedText == categoryID)
                    {
                        cbCategory.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            string search = txtSearch.Text;
            SearchCoffeeProducts(search);
        }

        private void dtgProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtCategoryid_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
