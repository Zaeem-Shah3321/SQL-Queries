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
    public partial class RemoveAssessment : Form
    {
        public RemoveAssessment()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String connectionString = "Data Source=DESKTOP-GEM7OTA\\SQLEXPRESS;Initial Catalog=desktopApp;Integrated Security=True;";
            SqlConnection conn = new SqlConnection(connectionString);

            string command = "DELETE FROM Assessment WHERE Title = @Title";

            conn.Open();

            SqlCommand cmd = new SqlCommand(command, conn);

            cmd.Parameters.AddWithValue("@Title", textBox1.Text);

            cmd.ExecuteNonQuery();

            conn.Close();

            MessageBox.Show("Assessment Removed Successfully");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
