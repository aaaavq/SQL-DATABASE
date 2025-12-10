using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace coffee
{
    internal class DatabaseConnection
    {
        
        private static string _connectionString = @"Data Source=DESKTOP-G6DBEPP\SQLEXPRESS;Initial Catalog=coffee_management1abcd;Integrated Security=True;";

        
        public static SqlConnection GetConnection()
        {
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(_connectionString);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(
                    "Error while connecting to the database",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return null;
            }

            return connection;
        }

        public static void QueryAndDisplayEmployees(SqlConnection connection)
        {
            string query = "SELECT * FROM Employees";
            SqlCommand command = new SqlCommand(query, connection);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    // Xử lý dữ liệu từ reader
                    Console.WriteLine(reader["EmployeeName"]);
                }
            }

            // Kết nối sẽ được đóng tự động khi khối using kết thúc
        }
    }



      
        
        
    
}
