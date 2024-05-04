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
    public partial class ManageStudents : Form
    {
        Form activeForm;
        public ManageStudents()
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
           openChildForm(new AddStudent(), sender);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openChildForm(new RemoveStudent(), sender);
        }

        private void button3_Click(object sender, EventArgs e)
        {
           openChildForm(new ViewStudents(), sender);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
