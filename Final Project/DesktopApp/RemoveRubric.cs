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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace DesktopApp
{
    public partial class RemoveRubric : Form
    {
        private DataTable studentsData;
        public RemoveRubric()
        {
            InitializeComponent();
            studentsData = GetAllStudents(); // Populate data table from database (shown later)
            dataGridView1.DataSource = studentsData;
            ShowRubrics();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ShowRubrics()
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

        private void button1_Click(object sender, EventArgs e)
        {
            Program.connection.Open();
            String query = "DELETE FROM Rubric WHERE Id = @id";
            SqlCommand cmd = new SqlCommand(query, Program.connection);
            cmd.Parameters.AddWithValue("@id", rubrics.SelectedItem);
            cmd.ExecuteNonQuery();
            Program.connection.Close();
            MessageBox.Show("Rubric Deleted Successfully");

            // Refresh grid data after deletion
            studentsData = GetAllStudents(); // Refetch data
            dataGridView1.DataSource = studentsData; // Rebind data source
            // Clear the ComboBox selection (optional)
            rubrics.SelectedIndex = -1;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private DataTable GetAllStudents()
        {
            DataTable studentsData = new DataTable();
            studentsData.Columns.Add("Id", typeof(int));
            studentsData.Columns.Add("Details", typeof(string));



            //SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                Program.connection.Open();

                string sql = "SELECT Id,Details FROM Rubric";
                SqlCommand command = new SqlCommand(sql, Program.connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    //int ID = Convert.ToInt32(reader["Id"]);
                    int id = Convert.ToInt32(reader["Id"]);
                    string name = reader["Details"].ToString();


                    studentsData.Rows.Add(id, name);
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
                Program.connection.Close();
            }

            return studentsData;
        }

        //private DataTable GetAllRubrics()
        //{
        //    DataTable studentsData = new DataTable(); // Renamed to reflect actual data
        //    studentsData.Columns.Add("Id", typeof(int));
        //    studentsData.Columns.Add("Details", typeof(string)); // Assuming "Details" is the column name

        //    try
        //    {
        //        Program.connection.Open();

        //        string sql = "SELECT Id, Details FROM Rubric"; // Assuming "Details" is the column name
        //        SqlCommand command = new SqlCommand(sql, Program.connection);

        //        SqlDataReader reader = command.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            int id = Convert.ToInt32(reader["Id"]);
        //            string details = reader["Details"].ToString();

        //            studentsData.Rows.Add(id, details);
        //        }

        //        reader.Close();
        //    }
        //    catch (SqlException ex)
        //    {
        //        Console.WriteLine("Error getting rubrics: " + ex.Message);
        //        // Handle potential database errors here (e.g., displaying an error message to the user)
        //    }
        //    finally
        //    {
        //        Program.connection.Close();
        //    }

        //    return studentsData;
        //}
    }
}
