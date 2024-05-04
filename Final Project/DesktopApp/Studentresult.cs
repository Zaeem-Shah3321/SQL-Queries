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
    public partial class Studentresult : Form
    {
        private DataTable assessmentData;
        private DataTable studentsData;
        private DataTable rubricData;
        public Studentresult()
        {
            InitializeComponent();
            showstud();
            showass();
            showrubric();
            studentsData = GetAllStudents(); // Populate data table from database (shown later)
            dataGridView1.DataSource = studentsData;
            assessmentData = GetAllAssessment(); // Populate data table from database (shown later)
            dataGridView2.DataSource = assessmentData;
            rubricData = GetAllRubrics(); // Populate data table from database (shown later)
            dataGridView3.DataSource = rubricData;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private DataTable GetAllStudents()
        {
            DataTable studentsData = new DataTable();
            studentsData.Columns.Add("Id", typeof(int));
            studentsData.Columns.Add("RegistrationNumber", typeof(string));

            string connectionString = "Data Source=DESKTOP-GEM7OTA\\SQLEXPRESS;Initial Catalog=desktopApp;Integrated Security=True;"; // Replace with your actual connection string

            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();

                string sql = "SELECT Id, RegistrationNumber FROM Student";
                SqlCommand command = new SqlCommand(sql, connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    //int ID = Convert.ToInt32(reader["Id"]);
                    int id = Convert.ToInt32(reader["Id"]);
                    string registrationNumber = reader["RegistrationNumber"].ToString();

                    studentsData.Rows.Add(id, registrationNumber);
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

        private DataTable GetAllAssessment()
        {
            DataTable assessmentData = new DataTable(); // Renamed to reflect actual data
            assessmentData.Columns.Add("Id", typeof(int));
            assessmentData.Columns.Add("Name", typeof(string)); // Assuming "Details" is the column name

            try
            {
                Program.connection.Open();

                string sql = "SELECT Id, Name FROM AssessmentComponent"; // Assuming "Details" is the column name
                SqlCommand command = new SqlCommand(sql, Program.connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["Id"]);
                    string details = reader["Name"].ToString();

                    assessmentData.Rows.Add(id, details);
                }

                reader.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error getting assessment component: " + ex.Message);
                // Handle potential database errors here (e.g., displaying an error message to the user)
            }
            finally
            {
                Program.connection.Close();
            }

            return assessmentData;
        }


        private DataTable GetAllRubrics()
        {
            DataTable rubricData = new DataTable(); // Renamed to reflect actual data
            rubricData.Columns.Add("Id", typeof(int));
            rubricData.Columns.Add("Details", typeof(string)); // Assuming "Details" is the column name

            try
            {
                Program.connection.Open();

                string sql = "SELECT Id, Details FROM RubricLevel"; // Assuming "Details" is the column name
                SqlCommand command = new SqlCommand(sql, Program.connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["Id"]);
                    string details = reader["Details"].ToString();

                    rubricData.Rows.Add(id, details);
                }

                reader.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error getting rubric value: " + ex.Message);
                // Handle potential database errors here (e.g., displaying an error message to the user)
            }
            finally
            {
                Program.connection.Close();
            }

            return rubricData;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void showstud()
        {
            Program.connection.Open();
            string query = "SELECT Id FROM Student";
            SqlCommand cmd = new SqlCommand(query, Program.connection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                student.Items.Add(reader["Id"].ToString());
            }
            Program.connection.Close();
        }

        private void showass()
        {
            Program.connection.Open();
            String query = "SELECT Id FROM AssessmentComponent";
            SqlCommand cmd = new SqlCommand(query, Program.connection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                assessment.Items.Add(reader["Id"].ToString());
            }
            Program.connection.Close();
        }

        private void showrubric()
        {
            Program.connection.Open();
            String query = "SELECT Id FROM RubricLevel";
            SqlCommand cmd = new SqlCommand(query, Program.connection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                rubric.Items.Add(reader["Id"].ToString());
            }
            Program.connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.connection.Open();
            String query = "INSERT INTO StudentResult VALUES(@student , @assessment , @rubric , @date);";
            SqlCommand cmd = new SqlCommand(query, Program.connection);
            cmd.Parameters.AddWithValue("@student", student.SelectedItem);
            cmd.Parameters.AddWithValue("@assessment", assessment.SelectedItem);
            cmd.Parameters.AddWithValue("@rubric", rubric.SelectedItem);
            cmd.Parameters.AddWithValue("@date", DateTime.Now);
            try
            {
            cmd.ExecuteNonQuery();
            MessageBox.Show("Student Result Added Successfully");
            Program.connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: dublicate values can not be inserted" );
                Program.connection.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
