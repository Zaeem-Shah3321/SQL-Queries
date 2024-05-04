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

namespace DesktopApp
{
    public partial class ViewStudents : Form
    {
        private DataTable studentsData;
        public ViewStudents()
        {
            InitializeComponent();
            studentsData = GetAllStudents(); // Populate data table from database (shown later)
            dataGridView1.DataSource = studentsData;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private DataTable GetAllStudents()
        {
            DataTable studentsData = new DataTable();
            studentsData.Columns.Add("FirstName", typeof(string));
            studentsData.Columns.Add("LastName", typeof(string));
            studentsData.Columns.Add("Contact", typeof(string)); // Adjust data type if needed (e.g., long for phone numbers)
            studentsData.Columns.Add("Email", typeof(string));
            studentsData.Columns.Add("RegistrationNumber", typeof(string));
            studentsData.Columns.Add("Status", typeof(int));

            string connectionString = "Data Source=DESKTOP-GEM7OTA\\SQLEXPRESS;Initial Catalog=desktopApp;Integrated Security=True;"; // Replace with your actual connection string

            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();

                string sql = "SELECT FirstName, LastName, Contact, Email, RegistrationNumber, Status FROM Student";
                SqlCommand command = new SqlCommand(sql, connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    //int ID = Convert.ToInt32(reader["Id"]);
                    string firstName = reader["FirstName"].ToString();
                    string lastName = reader["LastName"].ToString();
                    string contact = reader["Contact"].ToString(); // Adjust data type conversion if needed
                    string email = reader["Email"].ToString();
                    string registrationNumber = reader["RegistrationNumber"].ToString();
                    int status = Convert.ToInt32(reader["Status"]); // Convert retrieved value to int

                    studentsData.Rows.Add(firstName, lastName, contact, email, registrationNumber, status);
                }

                reader.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error getting students: " + ex.Message);
                // Handle potential database errors here (e.g., displaying an error message to the user)
            }
            finally
            {
                connection.Close();
            }

            return studentsData;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
