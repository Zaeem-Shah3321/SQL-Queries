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
    public partial class Addassesment : Form
    {
        public Addassesment()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String connectionString = "Data Source=DESKTOP-GEM7OTA\\SQLEXPRESS;Initial Catalog=desktopApp;Integrated Security=True;";

            SqlConnection conn = new SqlConnection(connectionString);

            String command = "INSERT INTO Assessment VALUES(@Title, @DateCreated , @TotalMarks, @TotalWeightage)";

            DateTime dateTime = DateTime.Now;

            conn.Open();
            SqlCommand cmd = new SqlCommand(command, conn);
            // Add the parameters if required

            cmd.Parameters.AddWithValue("@Title", textBox1.Text);
            cmd.Parameters.AddWithValue("@DateCreated", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@TotalMarks", int.Parse(textBox2.Text));
            cmd.Parameters.AddWithValue("@TotalWeightage", int.Parse(textBox3.Text));

            cmd.ExecuteNonQuery();

            conn.Close();
            MessageBox.Show("Assessment Added Successfully");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
