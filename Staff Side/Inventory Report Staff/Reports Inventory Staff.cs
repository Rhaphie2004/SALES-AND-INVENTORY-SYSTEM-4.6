using MySql.Data.MySqlClient;
using sims.Admin_Side.Stocks;
using sims.Staff_Side.Stocks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sims.Staff_Side.Inventory_Report_Staff
{
    public partial class Reports_Inventory_Staff : Form
    {
        private Manage_Stocks_Staff dashboard;

        public Reports_Inventory_Staff(Manage_Stocks_Staff dashboard)
        {
            InitializeComponent();
            this.dashboard = dashboard;
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Reports_Inventory_Staff_Load(object sender, EventArgs e)
        {
            PopulateStocks();
        }

        public void PopulateStocks()
        {
            // Confirm the user's action to generate the report for the selected items
            DialogResult result = MessageBox.Show("Are you sure you want to generate a report for the selected items?",
                                                  "Generate Report", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    // Ensure that at least one row is selected
                    if (dashboard.ItemsStockDgv.SelectedCells.Count > 0)
                    {
                        List<string> selectedStockIDs = new List<string>();

                        // Loop through selected rows
                        foreach (DataGridViewRow row in dashboard.ItemsStockDgv.SelectedRows)
                        {
                            string stockID = row.Cells["Stock_ID"]?.Value?.ToString();
                            if (string.IsNullOrEmpty(stockID))
                            {
                                MessageBox.Show("One or more selected rows have an invalid Stock_ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            selectedStockIDs.Add(stockID);
                        }

                        if (selectedStockIDs.Count > 0)
                        {
                            // Initialize database connection and fetch the selected stock details
                            dbModule db = new dbModule();
                            DataTable dt = new DataTable();

                            using (MySqlConnection conn = db.GetConnection())
                            {
                                conn.Open();

                                // Prepare a query with multiple stock IDs
                                string stockIds = string.Join(",", selectedStockIDs.Select(id => $"'{id}'"));
                                Console.WriteLine("Generated Stock IDs: " + stockIds);  // Debugging output

                                string query = $"SELECT * FROM stocks WHERE Stock_ID IN ({stockIds})";
                                using (MySqlCommand command = new MySqlCommand(query, conn))
                                {
                                    // Use MySqlDataAdapter to fill the DataTable
                                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                                    {
                                        adapter.Fill(dt);
                                    }
                                }
                            }

                            // Check if data exists for the selected Stock_IDs
                            if (dt.Rows.Count > 0)
                            {
                                sims.Stocks_Report stocksReport = new sims.Stocks_Report();
                                stocksReport.SetDataSource(dt);

                                crystalReportViewer1.ReportSource = stocksReport;
                                crystalReportViewer1.Refresh();
                            }
                            else
                            {
                                MessageBox.Show("No data found for the selected items.", "Information",
                                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("No valid Stock_ID(s) selected. Unable to generate the report.",
                                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please select at least one row to generate a report.",
                                        "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
