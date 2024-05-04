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
    public partial class UpdAssCom : Form
    {
        private DataTable assessmentData;
        public UpdAssCom()
        {
            InitializeComponent();
            showass();
            assessmentData = GetAllAssessment(); // Populate data table from database (shown later)
            dataGridView1.DataSource = assessmentData;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

        private void button1_Click(object sender, EventArgs e)
        {
            Program.connection.Open();
            string sql = "UPDATE AssessmentComponent SET Name = @Name , TotalMarks = @Marks   WHERE Id = @Id";
            SqlCommand command = new SqlCommand(sql, Program.connection);
            command.Parameters.AddWithValue("@Id", asscomp.SelectedItem);
            command.Parameters.AddWithValue("@Name", textBox1.Text);
            command.Parameters.AddWithValue("@Marks", textBox2.Text);
            command.ExecuteNonQuery();
            Program.connection.Close();
            MessageBox.Show("Assessment component Updated successfully");
            // Refresh grid data after deletion
            assessmentData = GetAllAssessment(); // Refetch data
            dataGridView1.DataSource = assessmentData; // Rebind data source
            // Clear the ComboBox selection (optional)
            asscomp.SelectedIndex = -1;
        }

        private void showass()
        {
            Program.connection.Open();
            string sql = "SELECT Id FROM AssessmentComponent";
            SqlCommand command = new SqlCommand(sql, Program.connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                asscomp.Items.Add(reader["Id"]);
            }
            Program.connection.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
