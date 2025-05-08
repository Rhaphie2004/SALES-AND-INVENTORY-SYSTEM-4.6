using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Controls;
using System.Windows.Forms;

namespace sims.Admin_Side.Products
{
    public partial class Sales_History_Form : Form
    {
        public Sales_History_Form()
        {
            InitializeComponent();
        }

        private void Sales_History_Form_Load(object sender, EventArgs e)
        {
            //fromDatePicker.Value = DateTime.Now;
            //toDatePicker.Value = DateTime.Now;
            MonthlySalesHistoryPreview("productsaleshistory_coffee", fromDatePicker.Value, toDatePicker.Value);
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private string selectedTableName = "";
        public void MonthlySalesHistoryPreview(string tableName, DateTime fromDate, DateTime toDate)
        {
            dbModule db = new dbModule();

            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string query = $"SELECT * FROM {tableName} WHERE Sale_Date >= @fromDate AND Sale_Date <= @toDate";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@fromDate", fromDate.Date);
                    cmd.Parameters.AddWithValue("@toDate", toDate.Date);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("No records found for the selected date range.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    salesHistoryDgv.DataSource = dt;
                }

                // Update the title label
                chartTitleLabel.Text = $"{tableName}";
                chartTitleLabel.Font = new Font("Poppins", 12);
                chartTitleLabel.TextAlign = ContentAlignment.MiddleCenter;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading sales history: " + ex.Message);
            }
        }

        private void CoffeeMonthlyChart_Click(object sender, EventArgs e)
        {
            selectedTableName = "productsaleshistory_coffee";
            MonthlySalesHistoryPreview(selectedTableName, fromDatePicker.Value, toDatePicker.Value);
        }

        private void NonCoffeeMonthlyChart_Click(object sender, EventArgs e)
        {
            selectedTableName = "productsaleshistory_noncoffee";
            MonthlySalesHistoryPreview(selectedTableName, fromDatePicker.Value, toDatePicker.Value);
        }

        private void HotCoffeeMonthlyChart_Click(object sender, EventArgs e)
        {
            selectedTableName = "productsaleshistory_hotcoffee";
            MonthlySalesHistoryPreview(selectedTableName, fromDatePicker.Value, toDatePicker.Value);
        }

        private void pastriesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            selectedTableName = "productsaleshistory_pastries";
            MonthlySalesHistoryPreview(selectedTableName, fromDatePicker.Value, toDatePicker.Value);
        }
    }
}
