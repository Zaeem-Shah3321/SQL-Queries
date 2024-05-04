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
    public partial class Viewclo : Form
    {
        private DataTable studentsData;
        public Viewclo()
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
            studentsData.Columns.Add("Name", typeof(string));
            studentsData.Columns.Add("DateCreated", typeof(string));
            studentsData.Columns.Add("DateUpated", typeof(string)); // Adjust data type if needed (e.g., long for phone numbers)


            string connectionString = "Data Source=DESKTOP-GEM7OTA\\SQLEXPRESS;Initial Catalog=desktopApp;Integrated Security=True;"; // Replace with your actual connection string

            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();

                string sql = "SELECT Name,DateCreated,DateUpdated FROM Clo";
                SqlCommand command = new SqlCommand(sql, connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    //int ID = Convert.ToInt32(reader["Id"]);
                    string name = reader["Name"].ToString();
                    string dateCreated = reader["DateCreated"].ToString();
                    string updated = reader["DateUpdated"].ToString(); // Adjust data type conversion if needed

                    studentsData.Rows.Add(name,dateCreated,updated);
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
