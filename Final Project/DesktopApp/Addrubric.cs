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
using System.Collections;

namespace DesktopApp
{


    public partial class Addrubric : Form
    {
        private DataTable studentsData;
        public Addrubric()
        {
            InitializeComponent();
            studentsData = GetAllStudents(); // Populate data table from database (shown later)
            dataGridView1.DataSource = studentsData;
            LoadComboBox();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String connectionString = "Data Source=DESKTOP-GEM7OTA\\SQLEXPRESS;Initial Catalog=desktopApp;Integrated Security=True;";

            SqlConnection conn = new SqlConnection(connectionString);

            String command = "INSERT INTO Rubric (Details, CloId) VALUES (@details, (SELECT Id FROM Clo WHERE Name = @cloName))";

            conn.Open();

            SqlCommand cmd = new SqlCommand(command, conn);

            // Add the parameters if required

            cmd.Parameters.AddWithValue("@details", textBox1.Text);

            cmd.Parameters.AddWithValue("@cloName", Clos.Text);

            cmd.ExecuteNonQuery();

            conn.Close();

            MessageBox.Show("Rubric Added Successfully");

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
            studentsData.Columns.Add("Name", typeof(string));
            


            //SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                Program.connection.Open();

                string sql = "SELECT Id,Name FROM Clo";
                SqlCommand command = new SqlCommand(sql, Program.connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    //int ID = Convert.ToInt32(reader["Id"]);
                    int id = Convert.ToInt32(reader["Id"]);
                    string name = reader["Name"].ToString();
                    

                    studentsData.Rows.Add(id,name);
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
             
        }

        private void LoadComboBox()
        {
            String connectionString = "Data Source=DESKTOP-GEM7OTA\\SQLEXPRESS;Initial Catalog=desktopApp;Integrated Security=True;";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            String query = "SELECT Name FROM Clo";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Clos.Items.Add(reader["Name"].ToString());
            }
            conn.Close();
        }

    }
}
