using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp
{

    internal static class Program
    {

        public static string connectionString = "Data Source=DESKTOP-GEM7OTA\\SQLEXPRESS;Initial Catalog=desktopApp;Integrated Security=True;"; // Replace with your actual connection string
        public static SqlConnection connection = new SqlConnection(connectionString);
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
