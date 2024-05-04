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
    public partial class AddStudent : Form
    {
        public AddStudent()
        {
            InitializeComponent();
            showstatus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String connectionString = "Data Source=DESKTOP-GEM7OTA\\SQLEXPRESS;Initial Catalog=desktopApp;Integrated Security=True;";
            SqlConnection conn = new SqlConnection(connectionString);
            
            String command = "INSERT INTO Student VALUES(@Column_1_Name, @Column_2_Name , @Column_3_Name , @Column_4_Name, @Column_5_Name , @Column_6_Name)";
            
            conn.Open();
            SqlCommand cmd = new SqlCommand(command, conn);
            // Add the parameters if required

            cmd.Parameters.AddWithValue("@Column_1_Name", textBox1.Text);
            cmd.Parameters.AddWithValue("@Column_2_Name", textBox2.Text);
            cmd.Parameters.AddWithValue("@Column_3_Name", textBox3.Text);
            cmd.Parameters.AddWithValue("@Column_4_Name", textBox4.Text);
            cmd.Parameters.AddWithValue("@Column_5_Name", textBox5.Text);
            cmd.Parameters.AddWithValue("@Column_6_Name", status.SelectedItem);
            //cmd.Parameters.AddWithValue("@Column_6_Name", int.Parse(textBox6.Text));

            cmd.ExecuteNonQuery();

            conn.Close();
            MessageBox.Show("Student Added Successfully");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void status_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void showstatus()
        {
            Program.connection.Open();
            String query = "SELECT CASE WHEN LookUpId = 5 THEN 1 WHEN LookUpId = 6 THEN 0 END AS DisplayId,  LookUpId FROM LookUp WHERE LookUpId IN (5, 6);";
            SqlCommand cmd = new SqlCommand(query, Program.connection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                status.Items.Add(reader["LookUpId"].ToString());
            }
            Program.connection.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
