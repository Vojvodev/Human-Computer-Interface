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

namespace SellingTickets
{
    public partial class AdminOptions : Form
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["SellingTickets"].ConnectionString;
        MySqlConnection connection = new MySqlConnection(connectionString);
        private MySqlDataAdapter adapter;
        private DataTable dataTable;

        private DataGridViewButtonColumn deleteButtonColumn1 = new DataGridViewButtonColumn();
        private DataGridViewButtonColumn blockButtonColumn1 = new DataGridViewButtonColumn();


        public AdminOptions()
        {
            InitializeComponent();

            // Creating the delete button          
            deleteButtonColumn1.Name = "deleteButton";
            deleteButtonColumn1.HeaderText = "";
            deleteButtonColumn1.Text = "Delete";
            deleteButtonColumn1.UseColumnTextForButtonValue = true;

            // Creating the block button
            blockButtonColumn1.Name = "blockButton";
            blockButtonColumn1.HeaderText = "";
            blockButtonColumn1.Text = "Block/Unblock";
            blockButtonColumn1.UseColumnTextForButtonValue = true;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            LoadData();

            dataGridView1.KeyDown += new KeyEventHandler(AdminOptions_KeyDown);


            // Subscribe to DataError event 
            dataGridView1.DataError += dataGridView1_DataError;
        }



        // ----------- EVENTS ------------------------------

        private void AdminOptions_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                SaveData();
                e.SuppressKeyPress = true; // To prevent the ding sound
            }
        }


        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Session.CurrentUser = null;
            this.Hide();
            new Login().ShowDialog();
            this.Close();
        }


        private void txtBoxBrowseUsers_TextChanged(object sender, EventArgs e)
        {
            // Refill the grid
            LoadUsersFromDb(txtBoxBrowseUsers.Text);
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["deleteButton"].Index && e.RowIndex >= 0)
            {
                try
                {
                    dataTable.Rows[e.RowIndex].Delete();
                    SaveData();
                }
                catch (IndexOutOfRangeException) { MessageBox.Show("Nothing to delete!"); }
            }
            else if (e.ColumnIndex == dataGridView1.Columns["blockButton"].Index && e.RowIndex >= 0)
            {
                try
                {
                    DataRow row = dataTable.Rows[e.RowIndex];
                    if (row != null && row["Blocked"].ToString() == "NO")
                    {
                        row["Blocked"] = "YES";
                        row["is_blocked"] = true;
                    }
                    else if(row != null && row["Blocked"].ToString() == "YES")
                    {
                        row["Blocked"] = "NO";
                        row["is_blocked"] = false;
                    }
                    
                    SaveData();
                }
                catch (IndexOutOfRangeException) { MessageBox.Show("Nothing to block!"); }
            }
        }

        


        // ------------ HELPER FUNCTIONS ------------------


        private void LoadData()
        {
            try
            {
                connection.Open();

                LoadUsersFromDb();
               
                dataGridView1.Columns.Add(deleteButtonColumn1);
                dataGridView1.Columns.Add(blockButtonColumn1);

                dataGridView1.Columns["id"].ReadOnly = true;
                dataGridView1.Columns["Admin"].ReadOnly = true;
                dataGridView1.Columns["Blocked"].ReadOnly = true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { connection.Close(); }
        }

        private void SaveData()
        {
            try
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    if (row.RowState == DataRowState.Modified)
                    {
                        if (row["Blocked"].ToString() == "YES")
                        {
                            row["is_blocked"] = true;
                            row["Blocked"] = true;
                        }
                        else
                        {
                            row["is_blocked"] = false;
                            row["Blocked"] = false;
                        }
                    }
                }

                adapter.Update(dataTable);
                dataGridView1.Columns.Clear();
                LoadData();
                MessageBox.Show("Data saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadUsersFromDb()
        {
            string query1 = "SELECT id, fname AS 'First Name', lname AS 'Last Name', username AS 'Username', password AS 'Password', email, " +
                "CASE WHEN is_admin=1 " +
                "   THEN 'YES' " +
                "   ELSE 'NO' " +
                "END AS 'Admin', " +
                "CASE WHEN is_blocked=1 " +
                "   THEN 'YES' " +
                "   ELSE 'NO' " +
                "END AS 'Blocked', is_blocked " +
                "FROM users ORDER BY fname, lname";

            adapter = new MySqlDataAdapter(query1, connection);
            MySqlCommandBuilder commandBuilder1 = new MySqlCommandBuilder(adapter);
            dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;

            dataGridView1.Columns["is_blocked"].Visible = false;
        }

        private void LoadUsersFromDb(string searchFor)
        {
            string query1 = "SELECT id, fname AS 'First Name', lname AS 'Last Name', username AS 'Username', password AS 'Password', email, " +
                "CASE WHEN is_admin=1 " +
                "   THEN 'YES' " +
                "   ELSE 'NO' " +
                "END AS 'Admin', " +
                "CASE WHEN is_blocked=1 " +
                "   THEN 'YES' " +
                "   ELSE 'NO' " +
                "END AS 'Blocked', is_blocked " +
                "FROM users " +
                "WHERE fname LIKE @searchFor OR lname LIKE @searchFor OR username LIKE @searchFor ORDER BY fname, lname";
            adapter = new MySqlDataAdapter(query1, connection);
            adapter.SelectCommand.Parameters.AddWithValue("@searchFor", "%" + searchFor + "%");
            MySqlCommandBuilder commandBuilder1 = new MySqlCommandBuilder(adapter);
            dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;

            dataGridView1.Columns["is_blocked"].Visible = false;
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
