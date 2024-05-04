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
    public partial class ClassAttendence : Form
    {
        public ClassAttendence()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.connection.Open();
            String query = "INSERT INTO ClassAttendance VALUES(@date);";
            SqlCommand cmd = new SqlCommand(query, Program.connection);
            cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value);
            cmd.ExecuteNonQuery();
            Program.connection.Close();
            MessageBox.Show("Class Attendance Added Successfully");


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
