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
    public partial class UpdateClo : Form
    {
        public UpdateClo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String connectionString = "Data Source=DESKTOP-GEM7OTA\\SQLEXPRESS;Initial Catalog=desktopApp;Integrated Security=True;";

            SqlConnection conn = new SqlConnection(connectionString);

            String command = "UPDATE Clo SET Name = @Name, DateUpdated = @DateUpdated WHERE Name = @Name";

            DateTime dateTime = DateTime.Now;

            conn.Open();

            SqlCommand cmd = new SqlCommand(command, conn);

            // Add the parameters if required

            cmd.Parameters.AddWithValue("@Name", textBox1.Text);

            cmd.Parameters.AddWithValue("@DateUpdated", dateTime);

            cmd.ExecuteNonQuery();

            conn.Close();

            MessageBox.Show("Clo Updated Successfully");

        }

        private void button2_Click(object sender, EventArgs e)
        { 
            this.Hide();
        }
    }
}
