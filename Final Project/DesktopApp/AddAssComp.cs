using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp
{
    public partial class AddAssComp : Form
    {
        private DataTable rubricData;
        private DataTable assessmentData;
        public AddAssComp()
        {
            InitializeComponent();
            rubricData = GetAllRubrics(); // Populate data table from database (shown later)
            dataGridView1.DataSource = rubricData;
            assessmentData = GetAllAssessment(); // Populate data table from database (shown later)
            dataGridView2.DataSource = assessmentData;
            Showrubrics();
            Showassess();
        }

        private void rubrics_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Showrubrics()
        {
            Program.connection.Open();
            String query = "SELECT Id From Rubric";
            SqlCommand cmd = new SqlCommand(query, Program.connection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                rubrics.Items.Add(reader["Id"].ToString());
            }
            Program.connection.Close();
        }

        private void Showassess()
        {
            Program.connection.Open();
            String query = "SELECT Id From Assessment";
            SqlCommand cmd = new SqlCommand(query, Program.connection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                assessment.Items.Add(reader["Id"].ToString());
            }
            Program.connection.Close();
        }

        private DataTable GetAllRubrics()
        {
            DataTable rubricData = new DataTable(); // Renamed to reflect actual data
            rubricData.Columns.Add("Id", typeof(int));
            rubricData.Columns.Add("Details", typeof(string)); // Assuming "Details" is the column name

            try
            {
                Program.connection.Open();

                string sql = "SELECT Id, Details FROM Rubric"; // Assuming "Details" is the column name
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
                Console.WriteLine("Error getting rubrics: " + ex.Message);
                // Handle potential database errors here (e.g., displaying an error message to the user)
            }
            finally
            {
                Program.connection.Close();
            }

            return rubricData;
        }

        private DataTable GetAllAssessment()
        {
            DataTable assessmentData = new DataTable(); // Renamed to reflect actual data
            assessmentData.Columns.Add("Id", typeof(int));
            assessmentData.Columns.Add("Title", typeof(string)); // Assuming "Details" is the column name

            try
            {
                Program.connection.Open();

                string sql = "SELECT Id, Title FROM Assessment"; // Assuming "Details" is the column name
                SqlCommand command = new SqlCommand(sql, Program.connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["Id"]);
                    string details = reader["Title"].ToString();

                    assessmentData.Rows.Add(id, details);
                }

                reader.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error getting assessments: " + ex.Message);
                // Handle potential database errors here (e.g., displaying an error message to the user)
            }
            finally
            {
                Program.connection.Close();
            }

            return assessmentData;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.connection.Open();
            String query = "INSERT INTO AssessmentComponent VALUES(@Name , @rubric , @marks , @date , @date , @assessment);";
            SqlCommand cmd = new SqlCommand(query, Program.connection);
            cmd.Parameters.AddWithValue("@Name", textBox1.Text);
            cmd.Parameters.AddWithValue("@rubric", rubrics.SelectedItem);
            cmd.Parameters.AddWithValue("@marks", textBox2.Text);
            cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@assessment" , assessment.SelectedItem);
            cmd.ExecuteNonQuery();
            Program.connection.Close();
            MessageBox.Show("Assessment Component Added Successfully");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
