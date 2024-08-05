using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SellingTickets
{
    public partial class UserView : Form
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["SellingTickets"].ConnectionString;
        MySqlConnection connection = new MySqlConnection(connectionString);
        private MySqlDataAdapter adapter1;
        public DataTable dataTable1;

        private MySqlDataAdapter adapter2;
        private DataTable dataTable2;

        private MySqlDataAdapter adapter3;
        private DataTable dataTable3;

        private DataGridViewButtonColumn deleteButtonColumn1 = new DataGridViewButtonColumn();
        private DataGridViewButtonColumn deleteButtonColumn2 = new DataGridViewButtonColumn();
        private DataGridViewButtonColumn deleteButtonColumn3 = new DataGridViewButtonColumn();
        private DataGridViewButtonColumn sellTicketButtonColumn = new DataGridViewButtonColumn();


        public UserView()
        {
            InitializeComponent();

            // Creating the delete button
            deleteButtonColumn1.Name = "deleteButton";
            deleteButtonColumn1.HeaderText = "";
            deleteButtonColumn1.Text = "Delete";
            deleteButtonColumn1.UseColumnTextForButtonValue = true;

            deleteButtonColumn2.Name = "deleteButton";
            deleteButtonColumn2.HeaderText = "";
            deleteButtonColumn2.Text = "Delete";
            deleteButtonColumn2.UseColumnTextForButtonValue = true;

            deleteButtonColumn3.Name = "deleteButton";
            deleteButtonColumn3.HeaderText = "";
            deleteButtonColumn3.Text = "Delete";
            deleteButtonColumn3.UseColumnTextForButtonValue = true;

            sellTicketButtonColumn.Name = "sellTicketButton";
            sellTicketButtonColumn.HeaderText = "";
            sellTicketButtonColumn.Text = "Sell Ticket";
            sellTicketButtonColumn.UseColumnTextForButtonValue = true;


            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            LoadData();

            // Subscribe to KeyDown event
            dataGridView1.KeyDown += new KeyEventHandler(UserView_KeyDown);
            dataGridView2.KeyDown += new KeyEventHandler(UserView_KeyDown);
            dataGridView3.KeyDown += new KeyEventHandler(UserView_KeyDown);

            dataGridView1.Columns["id"].ReadOnly = true;
            dataGridView2.Columns["id"].ReadOnly = true;
            dataGridView3.Columns["id"].ReadOnly = true;


            // Subscribe to DataError event 
            dataGridView1.DataError += dataGridView1_DataError;

        }




        // ----------- EVENTS ------------------------------


        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Session.CurrentUser = null;
            this.Hide();
            new Login().ShowDialog();
            this.Close();
        }

        //  CTRL+S anywhere = save everything
        private void UserView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                SaveData();
                e.SuppressKeyPress = true; // To prevent the ding sound
            }
        }

        private void UserView_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["deleteButton"].Index && e.RowIndex >= 0)
            {
                try
                {
                    if (tabControl1.SelectedIndex == 0)
                    {
                        dataTable1.Rows[e.RowIndex].Delete();
                    }
                    else if (tabControl1.SelectedIndex == 1)
                    {
                        dataTable2.Rows[e.RowIndex].Delete();
                    }
                    else if (tabControl1.SelectedIndex == 2)
                    {
                        dataTable3.Rows[e.RowIndex].Delete();
                    }

                    SaveData();
                }
                catch (IndexOutOfRangeException) { MessageBox.Show("Nothing to delete!"); }
            }
            else if (e.ColumnIndex == dataGridView1.Columns["sellTicketButton"].Index && e.RowIndex >= 0)
            {
                int eventId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id"].Value);
                int vip_left = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["VIP LEFT"].Value);
                int regular_left = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["REGULAR LEFT"].Value);

                if (vip_left > 0 || regular_left > 0)
                {
                    try
                    {
                        new SellTicket(eventId, vip_left, regular_left).ShowDialog();
                    }
                    catch (IndexOutOfRangeException) { MessageBox.Show("Could not sell ticket!"); }
                }
                else { MessageBox.Show("No more seats available!"); }

            }

        }

        private void txtBoxBrowseEvents_TextChanged(object sender, EventArgs e)
        {
            // Refill the grid   
            loadEventsFromDb(txtBoxBrowseEvents.Text);
        }

        private void txtBoxBrowsePerformers_TextChanged(object sender, EventArgs e)
        {
            loadPerformersFromDb(txtBoxBrowsePerformers.Text);
        }

        private void txtBoxBrowseCategories_TextChanged(object sender, EventArgs e)
        {
            loadCategoriesFromDb(txtBoxBrowseCategories.Text);
        }



        // ------------ HELPER FUNCTIONS ------------------


        private void LoadData()
        {
            try
            {
                connection.Open();

                loadEventsFromDb();
                loadPerformersFromDb();
                loadCategoriesFromDb();


                dataGridView1.Columns.Add(deleteButtonColumn1);
                dataGridView2.Columns.Add(deleteButtonColumn2);
                dataGridView3.Columns.Add(deleteButtonColumn3);

                dataGridView1.Columns.Add(sellTicketButtonColumn);

                dataGridView1.CellContentClick += new DataGridViewCellEventHandler(UserView_CellContentClick);
                dataGridView2.CellContentClick += new DataGridViewCellEventHandler(UserView_CellContentClick);
                dataGridView3.CellContentClick += new DataGridViewCellEventHandler(UserView_CellContentClick);

            }
            catch (Exception ex) { }
            finally { connection.Close(); }

        }

        private void SaveData()
        {
            try
            {
                adapter1.Update(dataTable1);
                adapter2.Update(dataTable2);
                adapter3.Update(dataTable3);
                LoadData();
                MessageBox.Show("Data saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving data: ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void loadEventsFromDb()
        {
            string query1 = "SELECT id, name AS 'Event', tickets_total AS 'Tickets Total', " +
                    "tickets_regular_available AS 'Regular Left', tickets_vip_available AS 'VIP Left', time AS 'Time' FROM events ORDER BY name";
            adapter1 = new MySqlDataAdapter(query1, connection);
            MySqlCommandBuilder commandBuilder1 = new MySqlCommandBuilder(adapter1);
            dataTable1 = new DataTable();
            adapter1.Fill(dataTable1);
            dataGridView1.DataSource = dataTable1;
        }

        private void loadEventsFromDb(string searchFor)
        {
            string query1 = "SELECT id, name AS 'Event', tickets_total AS 'Tickets Total', " +
                    "tickets_regular_available AS 'Regular Left', tickets_vip_available AS 'VIP Left', time AS 'Time' FROM events " +
                    "WHERE name LIKE @searchFor ORDER BY name";
            adapter1 = new MySqlDataAdapter(query1, connection);
            adapter1.SelectCommand.Parameters.AddWithValue("@searchFor", "%" + searchFor + "%");
            MySqlCommandBuilder commandBuilder1 = new MySqlCommandBuilder(adapter1);
            dataTable1 = new DataTable();
            adapter1.Fill(dataTable1);
            dataGridView1.DataSource = dataTable1;
        }


        private void loadPerformersFromDb()
        {
            string query2 = "SELECT id, fname AS 'First Name', lname AS 'Last Name', pseudonym AS 'Artistic Name' " +
                    "FROM performers ORDER BY pseudonym";
            adapter2 = new MySqlDataAdapter(query2, connection);
            MySqlCommandBuilder commandBuilder2 = new MySqlCommandBuilder(adapter2);
            dataTable2 = new DataTable();
            adapter2.Fill(dataTable2);
            dataGridView2.DataSource = dataTable2;
        }

        private void loadPerformersFromDb(string searchFor)
        {
            string query2 = "SELECT id, fname AS 'First Name', lname AS 'Last Name', pseudonym AS 'Artistic Name' FROM performers " +
                    "WHERE pseudonym LIKE @searchFor OR fname LIKE @searchFor OR lname LIKE @searchFor ORDER BY pseudonym";
            adapter2 = new MySqlDataAdapter(query2, connection);
            adapter2.SelectCommand.Parameters.AddWithValue("@searchFor", "%" + searchFor + "%");
            MySqlCommandBuilder commandBuilder2 = new MySqlCommandBuilder(adapter2);
            dataTable2 = new DataTable();
            adapter2.Fill(dataTable2);
            dataGridView2.DataSource = dataTable2;
        }


        private void loadCategoriesFromDb()
        {
            string query3 = "SELECT id, name AS 'Category Name' FROM event_categories ORDER BY name";
            adapter3 = new MySqlDataAdapter(query3, connection);
            MySqlCommandBuilder commandBuilder3 = new MySqlCommandBuilder(adapter3);
            dataTable3 = new DataTable();
            adapter3.Fill(dataTable3);
            dataGridView3.DataSource = dataTable3;
        }

        private void loadCategoriesFromDb(string searchFor)
        {
            string query3 = "SELECT id, name AS 'Category Name' FROM event_categories " +
                    "WHERE name LIKE @searchFor ORDER BY name";
            adapter3 = new MySqlDataAdapter(query3, connection);
            adapter3.SelectCommand.Parameters.AddWithValue("@searchFor", "%" + searchFor + "%");
            MySqlCommandBuilder commandBuilder3 = new MySqlCommandBuilder(adapter3);
            dataTable3 = new DataTable();
            adapter3.Fill(dataTable3);
            dataGridView3.DataSource = dataTable3;
        }



        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // Check if the error is a format exception
            if (e.Exception is FormatException)
            {
                MessageBox.Show("Invalid format. Please enter a valid value.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                
                 e.ThrowException = false;
            }
            else

            {
                // Handle other types of errors if necessary
                MessageBox.Show("An error occurred: " + e.Exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.ThrowException = false; // Prevent the exception from being thrown again
            }
        }

    }

}
