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
    public partial class AddRubricsLevel : Form
    {
        private DataTable studentsData;
        public AddRubricsLevel()
        {
            InitializeComponent();
            studentsData = GetAllStudents(); // Populate data table from database (shown later)
            dataGridView1.DataSource = studentsData;
            showrubrics();
        }

        private void rubrics_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void showrubrics()
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

        private void button1_Click(object sender, EventArgs e)
        {
            Program.connection.Open();
            String query = "INSERT INTO RubricLevel VALUES(@Id , @Details , @Level)";
            SqlCommand cmd = new SqlCommand(query, Program.connection);
            cmd.Parameters.AddWithValue("@Id", rubrics.SelectedItem);
            cmd.Parameters.AddWithValue("@Details", textBox1.Text);
            cmd.Parameters.AddWithValue("@Level", int.Parse(textBox2.Text));
            cmd.ExecuteNonQuery();
            Program.connection.Close();
            MessageBox.Show("Rubric Level Added Successfully");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
