using FontAwesome.Sharp;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sims.Admin_Side.Database
{
    public partial class Database_Backup : Form
    {
        public Database_Backup()
        {
            InitializeComponent();
        }

        private void backUpBtn_Click(object sender, EventArgs e)
        {
            dbModule db = new dbModule();
            MySqlConnection conn = db.GetConnection();
            MySqlCommand cmd = db.GetCommand();

            try
            {
                // Create SaveFileDialog instance
                SaveFileDialog backup = new SaveFileDialog
                {
                    InitialDirectory = @"C:\",
                    Title = "Database Backup",
                    CheckFileExists = false,
                    CheckPathExists = false,
                    DefaultExt = "sql",
                    Filter = "SQL files (*.sql)|*.sql|All files (*.*)|*.*",
                    RestoreDirectory = true
                };

                // Show the Save File Dialog
                if (backup.ShowDialog() == DialogResult.OK)
                {
                    // Open database connection from your module
                    conn.Open();

                    if (conn.State != ConnectionState.Open)
                    {
                        MessageBox.Show("Database connection is not open.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Assign connection to the command from dbModule
                    cmd.Connection = conn;

                    // Perform database backup
                    MySqlBackup mb = new MySqlBackup(cmd);
                    mb.ExportToFile(backup.FileName);

                    MessageBox.Show("Database backup successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during backup: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Always clean up
                if (conn.State == ConnectionState.Open)
                    conn.Close();

                cmd.Dispose();
                conn.Dispose();
            }


        }

        private void restoreBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Open File Dialog to Select Backup File
                OpenFileDialog restore = new OpenFileDialog
                {
                    InitialDirectory = @"C:\",
                    Title = "Restore Database",
                    CheckFileExists = true,
                    CheckPathExists = true,
                    DefaultExt = "sql",
                    Filter = "SQL files (*.sql)|*.sql|All files (*.*)|*.*",
                    RestoreDirectory = true
                };

                if (restore.ShowDialog() == DialogResult.OK)
                {
                    // Confirm before restoring
                    DialogResult result = MessageBox.Show(
                        "Are you sure you want to restore the database? This will overwrite existing data.",
                        "Confirm Restore",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (result == DialogResult.No) return;

                    MySqlConnection con = new MySqlConnection("server=localhost;username=root;password=;database=gymxfit_database;charset=utf8");

                    // Use MySqlCommand with the open connection
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = con;
                    con.Open();

                    // Create MySqlBackup object and restore from file
                    MySqlBackup mb = new MySqlBackup(cmd);
                    mb.ImportFromFile(restore.FileName);

                    // Close the connection after restore
                    con.Close();

                    MessageBox.Show("Database restored successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during restore: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
