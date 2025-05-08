using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.IO;
using System.Windows.Forms;

namespace sims
{
    internal class DatabaseSetup
    {
        private const string DEFAULT_SERVER = "localhost";
        private const string DEFAULT_PORT = "3306";
        private const string DEFAULT_USER = "root";
        private const string DEFAULT_PASSWORD = "";

        public static bool SetupDatabase(string databaseName, string scriptPath)
        {
            try
            {
                // Create connection string for MySQL
                string connectionString = $"Server={DEFAULT_SERVER};Port={DEFAULT_PORT};" +
                                        $"User ID={DEFAULT_USER};Password={DEFAULT_PASSWORD}";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Create database if it doesn't exist
                    string createDbQuery = $"CREATE DATABASE IF NOT EXISTS {databaseName}";
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

                    // Update app.config with the new connection string
                    UpdateConnectionString(databaseName);

                    return true;
                }
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
                config.ConnectionStrings.ConnectionStrings["DefaultConnection"].ConnectionString =
                    fullConnectionString;
            }
            else
            {
                config.ConnectionStrings.ConnectionStrings.Add(
                    new ConnectionStringSettings("DefaultConnection", fullConnectionString));
            }

            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("connectionStrings");
        }
    }
}
