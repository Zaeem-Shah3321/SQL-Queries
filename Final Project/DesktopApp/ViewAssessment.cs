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
    public partial class ViewAssessment : Form
    {
        private DataTable studentsData;
        public ViewAssessment()
        {
            InitializeComponent();
            studentsData = GetAllStudents(); // Populate data table from database (shown later)
            dataGridView1.DataSource = studentsData;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //String connectionString = "Data Source=DESKTOP-IC90SRH\\SQLEXPRESS01;Initial Catalog=desktopApp;Integrated Security=True;";
            
        }

        private DataTable GetAllStudents()
        {
            DataTable studentsData = new DataTable();
            studentsData.Columns.Add("FirstName", typeof(string));
            studentsData.Columns.Add("LastName", typeof(string));
            studentsData.Columns.Add("Contact", typeof(int)); // Adjust data type if needed (e.g., long for phone numbers)
            studentsData.Columns.Add("Email", typeof(int));

            string connectionString = "Data Source=DESKTOP-GEM7OTA\\SQLEXPRESS;Initial Catalog=desktopApp;Integrated Security=True;"; // Replace with your actual connection string

            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();

                string sql = "SELECT Title,DateCreated, TotalMarks, TotalWeightage FROM Assessment";
                SqlCommand command = new SqlCommand(sql, connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    //int ID = Convert.ToInt32(reader["Id"]);
                    string title = reader["Title"].ToString();
                    string dateCreated = reader["DateCreated"].ToString();
                    int marks = Convert.ToInt32(reader["TotalMarks"]); // Adjust data type conversion if needed
                    int weightage = Convert.ToInt32(reader["TotalWeightage"]);

                    studentsData.Rows.Add(title,dateCreated,marks,weightage);
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
