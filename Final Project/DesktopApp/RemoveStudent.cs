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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DesktopApp
{
    public partial class RemoveStudent : Form
    {
        private string connectionString = "Data Source=DESKTOP-GEM7OTA\\SQLEXPRESS;Initial Catalog=desktopApp;Integrated Security=True;";

        public RemoveStudent()
        {
            InitializeComponent();
            showrubrics();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //String connectionString = "Data Source=DESKTOP-IC90SRH\\SQLEXPRESS01;Initial Catalog=desktopApp;Integrated Security=True;";
            string registrationNumber = comb.Text;

            if (string.IsNullOrEmpty(registrationNumber))
            {
                MessageBox.Show("Please enter the student's registration number.", "Missing Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                try
                {
                    // Check if student exists before deletion
                    string checkStudentExists = "SELECT COUNT(*) FROM Student WHERE RegistrationNumber = @RegistrationNumber";
                    SqlCommand checkCmd = new SqlCommand(checkStudentExists, conn);
                    checkCmd.Parameters.AddWithValue("@RegistrationNumber", registrationNumber);

                    int studentCount = (int)checkCmd.ExecuteScalar();

                    if (studentCount > 0)
                    {
                        // Student exists, proceed with deletion
                        string deleteStudent = "DELETE FROM Student WHERE RegistrationNumber = @RegistrationNumber";
                        SqlCommand deleteCmd = new SqlCommand(deleteStudent, conn);
                        deleteCmd.Parameters.AddWithValue("@RegistrationNumber", registrationNumber);

                        int rowsDeleted = deleteCmd.ExecuteNonQuery();

                        showrubrics();

                        MessageBox.Show($"Student with registration number '{registrationNumber}' deleted successfully.", "Student Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Student with registration number '{registrationNumber}' not found.", "Student Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
            private void textBox1_TextChanged(object sender, EventArgs e)
            {

            }

        private void showrubrics()
        {
            comb.Items.Clear();
            Program.connection.Open();
            String query = "SELECT RegistrationNumber From Student";
            SqlCommand cmd = new SqlCommand(query, Program.connection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comb.Items.Add(reader["RegistrationNumber"].ToString());
            }
            Program.connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
