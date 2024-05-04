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
    public partial class StudentAttendance : Form
    {
        private DataTable studentsData;
        public StudentAttendance()
        {
            InitializeComponent();
            studentsData = GetAllStudents(); // Populate data table from database (shown later)
            dataGridView1.DataSource = studentsData;
            showdate();
            showregno();
            showstatus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.connection.Open();
            //MessageBox.Show(date.Text);
            
            String query = "INSERT INTO StudentAttendance VALUES ((SELECT Id From ClassAttendance WHERE Id = @date), (SELECT Id From Student WHERE RegistrationNumber = @regno), @status)";
            SqlCommand cmd = new SqlCommand(query, Program.connection);
            cmd.Parameters.AddWithValue("@date", date.SelectedIndex) ;
            cmd.Parameters.AddWithValue("@regno", regno.SelectedItem);
            cmd.Parameters.AddWithValue("@status", status.SelectedItem);
            try
            {
            cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Attendance already marked " + ex.Message);
            }
            Program.connection.Close();
            MessageBox.Show("Attendance Added Successfully");
        }

        private void date_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void showdate()
        {
            Program.connection.Open();
            String query = "SELECT Id From ClassAttendance";
            SqlCommand cmd = new SqlCommand(query, Program.connection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                date.Items.Add(Convert.ToInt32(reader["Id"]));
            }
            Program.connection.Close();
        }

        private void showregno()
        {
            Program.connection.Open();
            String query = "SELECT RegistrationNumber From Student";
            SqlCommand cmd = new SqlCommand(query, Program.connection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                regno.Items.Add(reader["RegistrationNumber"].ToString());
            }
            Program.connection.Close();
        }

        private void showstatus()
        {
            
            Program.connection.Open();
            String query = "SELECT TOP 4 LookUpId FROM LookUp";
            SqlCommand cmd = new SqlCommand(query, Program.connection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                status.Items.Add(reader["LookUpId"]);

            }
            Program.connection.Close();

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
            studentsData.Columns.Add("AttendanceDate", typeof(string));



            //SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                Program.connection.Open();

                string sql = "SELECT Id,AttendanceDate FROM ClassAttendance";
                SqlCommand command = new SqlCommand(sql, Program.connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    //int ID = Convert.ToInt32(reader["Id"]);
                    int id = Convert.ToInt32(reader["Id"]);
                    string name = reader["AttendanceDate"].ToString();
                    studentsData.Rows.Add(id, name);
                }

                reader.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error getting Class attendance: " + ex.Message);
                // Handle potential database errors here (e.g., displaying an error message to the user)
            }
            finally
            {
                Program.connection.Close();
            }

            return studentsData;
        }

        private void status_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
