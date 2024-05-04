using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp
{
    public partial class Dashboard : Form
    {
        Form activeForm;
        public Dashboard()
        {
            InitializeComponent();
        }
        private void openChildForm(Form child, object sender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = child;

            child.TopLevel = false;
            child.FormBorderStyle = FormBorderStyle.None;
            child.Dock = DockStyle.Fill;

            this.panel1.Controls.Add(child);
            this.panel1.Tag = child;

            child.BringToFront();
            child.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            openChildForm(new ManageStudents(), sender);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openChildForm(new ManageAttendance(), sender);
        }
        private void button3_Click(object sender, EventArgs e)
        {
              openChildForm(new ManageAssesments(), sender);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            openChildForm(new ManageRubrics(), sender);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            openChildForm(new ManageCLO(), sender);
        }
        private void button6_Click(object sender, EventArgs e)
        {
            openChildForm(new AddRubricsLevel(), sender);  
        }
        private void button7_Click(object sender, EventArgs e)
        {
            openChildForm(new Studentresult(), sender);
        }
        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }




































        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

    }
}
