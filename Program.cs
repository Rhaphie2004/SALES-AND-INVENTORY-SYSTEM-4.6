using System;
using System.Diagnostics;
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

            StartMySQLServer(); // Start the MySQL server before connecting

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

        // Starts the portable MySQL server
        private static void StartMySQLServer()
        {
            string appPath = Application.StartupPath;
            string mysqlBin = Path.Combine(appPath, "mysql", "bin", "mysqld.exe");
            string myIni = Path.Combine(appPath, "mysql", "my.ini");

            if (!File.Exists(mysqlBin))
            {
                MessageBox.Show("mysqld.exe not found:\n" + mysqlBin);
                return;
            }

            if (!File.Exists(myIni))
            {
                MessageBox.Show("my.ini not found:\n" + myIni);
                return;
            }

            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = mysqlBin,
                Arguments = $"--defaults-file=\"{myIni}\"",
                UseShellExecute = false,
                CreateNoWindow = true
            };

            try
            {
                Process.Start(psi);
                System.Threading.Thread.Sleep(3000); // Wait a bit to allow the server to start
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to start MySQL Server:\n{ex.Message}");
            }
        }

        // Checks if this is the first time the app is run
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
