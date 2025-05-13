using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace sims
{
    internal class DatabaseSetup
    {
        private const string DEFAULT_SERVER = "localhost";
        private const string DEFAULT_PORT = "3306";
        private const string DEFAULT_USER = "root";
        private const string DEFAULT_PASSWORD = "";

        private static Process mysqlProcess;

        public static bool SetupDatabase(string databaseName, string scriptPath)
        {
            try
            {
                StartMySQL();

                StartMySQL();

                bool connected = false;
                int retries = 0;

                while (!connected && retries < 10)
                {
                    try
                    {
                        using (var testConn = new MySqlConnection("Server=localhost;Port=3306;User ID=root;Password="))
                        {
                            testConn.Open();
                            connected = true;
                        }
                    }
                    catch
                    {
                        Thread.Sleep(1000);
                        retries++;
                    }
                }

                if (!connected)
                {
                    MessageBox.Show("Failed to start MySQL server.", "Startup Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }


                string connectionString = $"Server={DEFAULT_SERVER};Port={DEFAULT_PORT};" +
                                          $"User ID={DEFAULT_USER};Password={DEFAULT_PASSWORD}";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Create database if it doesn't exist
                    string createDbQuery = $"CREATE DATABASE IF NOT EXISTS `{databaseName}`";
                    using (MySqlCommand createDbCommand = new MySqlCommand(createDbQuery, connection))
                    {
                        createDbCommand.ExecuteNonQuery();
                    }

                    // Switch to the new database
                    connection.ChangeDatabase(databaseName);

                    // Execute SQL script if provided
                    if (!string.IsNullOrEmpty(scriptPath) && File.Exists(scriptPath))
                    {
                        string script = File.ReadAllText(scriptPath);
                        using (MySqlCommand scriptCommand = new MySqlCommand(script, connection))
                        {
                            scriptCommand.ExecuteNonQuery();
                        }
                    }

                    // Update app.config
                    UpdateConnectionString(databaseName);
                }

                // Optional: Stop MySQL immediately after setup
                // StopMySQL();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database setup failed: {ex.Message}", "Setup Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private static void UpdateConnectionString(string databaseName)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            string fullConnectionString = $"Server={DEFAULT_SERVER};Port={DEFAULT_PORT};" +
                                          $"Database={databaseName};User ID={DEFAULT_USER};" +
                                          $"Password={DEFAULT_PASSWORD}";

            if (config.ConnectionStrings.ConnectionStrings["DefaultConnection"] != null)
            {
                config.ConnectionStrings.ConnectionStrings["DefaultConnection"].ConnectionString = fullConnectionString;
            }
            else
            {
                config.ConnectionStrings.ConnectionStrings.Add(
                    new ConnectionStringSettings("DefaultConnection", fullConnectionString));
            }

            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("connectionStrings");
        }

        private static void StartMySQL()
        {
            string basePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "mysql");
            string myIniPath = Path.Combine(basePath, "my.ini");
            string mysqldPath = Path.Combine(basePath, "bin", "mysqld.exe");

            if (!File.Exists(mysqldPath))
            {
                MessageBox.Show("MySQL server not found.", "Startup Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = mysqldPath,
                Arguments = $"--defaults-file=\"{myIniPath}\"",
                WorkingDirectory = Path.Combine(basePath, "bin"),
                UseShellExecute = false,
                CreateNoWindow = true
            };

            mysqlProcess = Process.Start(psi);
        }

        public static void StopMySQL()
        {
            string mysqladminPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "mysql", "bin", "mysqladmin.exe");

            if (!File.Exists(mysqladminPath))
                return;

            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = mysqladminPath,
                Arguments = "-u root shutdown",
                WorkingDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "mysql", "bin"),
                UseShellExecute = false,
                CreateNoWindow = true
            };

            try
            {
                Process.Start(psi);
            }
            catch
            {
                // Optional: fallback to kill the mysqld process
                mysqlProcess?.Kill();
            }
        }
    }
}
