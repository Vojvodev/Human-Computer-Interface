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
    public partial class SellTicket : Form
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["SellingTickets"].ConnectionString;
        MySqlConnection connection = new MySqlConnection(connectionString);
        int eventsId;
        int customersId = 1;
        int vip_left = 0;
        int regular_left = 0;


        public SellTicket(int eventsId, int vip_left, int regular_left)
        {
            InitializeComponent();

            this.eventsId = eventsId;

            comboBox1.SelectedIndex = 0;
            this.vip_left = vip_left;
            this.regular_left = regular_left;
        }

        public SellTicket()
        {
            InitializeComponent();

            comboBox1.SelectedIndex = 0;
        }





        // ------------------------- EVENTS --------------------------


        private void btnSell_Click(object sender, EventArgs e)
        {
            if ((comboBox1.Text == "VIP" && vip_left > 0) || (comboBox1.Text == "REGULAR" && regular_left > 0))
            {
                try
                {
                    // Saving customer's data
                    connection.Open();
                    MySqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "INSERT INTO customers (fname, lname) VALUES (@fname, @lname)";
                    cmd.Parameters.AddWithValue("@fname", txtBoxFname.Text);
                    cmd.Parameters.AddWithValue("@lname", txtBoxLname.Text);

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex) { MessageBox.Show("Customer's data already in the database!"); }



                    // Get the customer id from his first name and last name
                    MySqlCommand cmd2 = connection.CreateCommand();
                    cmd2.CommandText = "SELECT id from customers WHERE fname=@fname AND lname=@lname";

                    cmd2.Parameters.AddWithValue("@fname", txtBoxFname.Text);
                    cmd2.Parameters.AddWithValue("@lname", txtBoxLname.Text);

                    MySqlDataReader reader = cmd2.ExecuteReader();
                    while (reader.Read())
                    {
                        customersId = reader.GetInt32("id");
                    }

                    reader.Close();


                    // Saving the ticket
                    MySqlCommand cmd3 = connection.CreateCommand();
                    cmd3.CommandText = "INSERT INTO tickets (type, price, worker_id, customer_id, events_id) " +
                                        " VALUES (@type, @price, @worker_id, @customer_id, @events_id)";

                    cmd3.Parameters.AddWithValue("@type", comboBox1.Text);
                    cmd3.Parameters.AddWithValue("@price", txtBoxPrice.Text);
                    cmd3.Parameters.AddWithValue("@worker_id", Session.CurrentUser.id);
                    cmd3.Parameters.AddWithValue("@customer_id", this.customersId);
                    cmd3.Parameters.AddWithValue("@events_id", this.eventsId);



                    if (cmd3.ExecuteNonQuery() != 0)
                    {
                        MessageBox.Show("Ticket created!");

                        if (comboBox1.Text == "VIP")
                        {
                            decreaseFreeVIPSeats();
                        }
                        else if (comboBox1.Text == "REGULAR")
                        {
                            decreaseFreeRegularSeats();
                        }

                    }
                    else
                    {
                        MessageBox.Show("Could not create ticket!");
                    }

                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally { connection.Close(); }
            }
            else { MessageBox.Show("No more seats available!"); }

        }




        // -------------------- HELPER FUNCTIONS ----------------------

        private void decreaseFreeVIPSeats()
        {
            try
            {
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "UPDATE events SET tickets_available = tickets_available - 1, tickets_vip_available = tickets_vip_available - 1 WHERE id = @events_id";
                cmd.Parameters.AddWithValue("@events_id", this.eventsId);

                if (cmd.ExecuteNonQuery() == 0)
                {
                    MessageBox.Show("Could not decrease ticket number!");
                }
            }
            catch (Exception ex) { MessageBox.Show("Could not decrease ticket number!"); }
            finally { connection.Close(); }
        }


        private void decreaseFreeRegularSeats()
        {
            try
            {
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "UPDATE events SET tickets_available = tickets_available - 1, tickets_regular_available = tickets_regular_available - 1 WHERE id = @events_id";
                cmd.Parameters.AddWithValue("@events_id", this.eventsId);

                if (cmd.ExecuteNonQuery() == 0)
                {
                    MessageBox.Show("Could not decrease ticket number!");
                }
            }
            catch (Exception ex) { MessageBox.Show("Could not decrease ticket number!"); }
            finally { connection.Close(); }
        }


    }


}
