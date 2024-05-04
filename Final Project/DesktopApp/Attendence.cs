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
    public partial class Attendence : Form
    {
        public Attendence()
        {
            InitializeComponent();
        }

        private void Attendence_Load(object sender, EventArgs e)
        {
            List<StudentDisplayData> studentsToDisplay = new List<StudentDisplayData>();
            List<Student> students = StudentData.GetStudents();

            foreach (Student student in students)
            {
                studentsToDisplay.Add(new StudentDisplayData
                {
                    RegistrationNumber = student.RegistrationNumber,
                    FullName = student.FirstName + " " + student.LastName,
                    Attendance = student.Attendance
                });
            }

            dataGridView1.DataSource = studentsToDisplay;

            // Optional: Customize grid column formatting (e.g., set column widths)
            //dataGridView1.Columns["RegistrationNumber"].Width = 120;
            //dataGridView1.Columns["FullName"].Width = 200;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }

    public class DatabaseConnection
    {
        private static string connectionString = "Data Source=DESKTOP-GEM7OTA\\SQLEXPRESS;Initial Catalog=desktopApp;Integrated Security=True;"; // Replace if needed

        public static SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }
    }

    public class StudentData
    {
        public static List<Student> GetStudents()
        {
            List<Student> students = new List<Student>();
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = "SELECT RegistrationNumber, FirstName, LastName FROM Student"; // Adjust query if needed
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    students.Add(new Student
                    {
                        RegistrationNumber = reader.GetString(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        Attendance = false // Initialize attendance as false
                    });
                }

                reader.Close();
            }
            return students;
        }
    }

    public class StudentDisplayData // Optional for clarity
    {
        public string RegistrationNumber { get; set; }
        public string FullName { get; set; }
        public bool Attendance { get; set; }
    }
    public class Student
    {
        public string RegistrationNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Attendance { get; set; }
    }
}
