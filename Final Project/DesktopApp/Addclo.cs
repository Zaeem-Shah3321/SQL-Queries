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
    public partial class Addclo : Form
    {
        public Addclo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String connectionString = "Data Source=DESKTOP-GEM7OTA\\SQLEXPRESS;Initial Catalog=desktopApp;Integrated Security=True;";

            SqlConnection conn = new SqlConnection(connectionString);

            String command = "INSERT INTO Clo VALUES(@Name, @DateCreated , @DateUpdated)";

            DateTime dateTime = DateTime.Now;

            conn.Open();
            SqlCommand cmd = new SqlCommand(command, conn);
            // Add the parameters if required

            cmd.Parameters.AddWithValue("@Name", textBox1.Text);
            cmd.Parameters.AddWithValue("@DateCreated", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@DateUpdated", dateTimePicker1.Value);

            cmd.ExecuteNonQuery();

            conn.Close();
            MessageBox.Show("Clo Added Successfully");


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
