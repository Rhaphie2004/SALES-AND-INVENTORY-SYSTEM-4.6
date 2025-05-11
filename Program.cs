using sims.Admin_Side;
using sims.Splash_page_and_Loading_Screen;
using sims.Staff_Side;
using System;
using System.IO;
using System.Windows.Forms;

namespace sims
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Add the database setup code here
            if (FirstTimeRun())
            {
                string dbName = "sims";
                string scriptPath = Path.Combine(Application.StartupPath, "sales and inventory system.sql");

                if (DatabaseSetup.SetupDatabase(dbName, scriptPath))
                {
                    MessageBox.Show("Database setup completed successfully!");
                }
            }

            Application.Run(new Login_Form());
        }

        // Add this method inside the Program class
        private static bool FirstTimeRun()
        {
            bool firstRun = Properties.Settings.Default.FirstRun;

            if (firstRun)
            {
                Properties.Settings.Default.FirstRun = false;
                Properties.Settings.Default.Save();
            }

            return firstRun;
        }
    }
}
