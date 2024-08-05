using MySql.Data.MySqlClient;
using System.Configuration;

namespace SellingTickets
{
    public partial class Login : Form
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["SellingTickets"].ConnectionString;
        MySqlConnection conn = new MySqlConnection(connectionString);



        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM users WHERE username = @un AND password = @pd";
                cmd.Parameters.AddWithValue("@un", username.Text);
                cmd.Parameters.AddWithValue("@pd", password.Text);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    User user = new User
                    {
                        id = reader.GetInt32("id"),
                        username = reader.GetString("username"),
                        password = reader.GetString("password"),
                        fname = reader.GetString("fname"),
                        lname = reader.GetString("lname"),
                        phone = reader.GetString("phone"),
                        email = reader.GetString("email"),
                        location = reader.GetString("location"),
                        isAdmin = reader.GetBoolean("is_admin"),
                        isBlocked = reader.GetBoolean("is_blocked")
                    };
                    reader.Close();
                    Session.CurrentUser = user;

                    if (!user.isBlocked)
                    {
                        this.Hide();
                        new UserView().ShowDialog();
                        this.Close();
                    }
                    else throw new Exception("The user is blocked! \nContact administration for more details!");
                }
                else throw new Exception("Wrong username/password!");

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conn.Close(); }
        }


        private void btnAdminLogin_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM users WHERE username = @un AND password = @pd";
                cmd.Parameters.AddWithValue("@un", username.Text);
                cmd.Parameters.AddWithValue("@pd", password.Text);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    User user = new User
                    {
                        id = reader.GetInt32("id"),
                        username = reader.GetString("username"),
                        password = reader.GetString("password"),
                        fname = reader.GetString("fname"),
                        lname = reader.GetString("lname"),
                        phone = reader.GetString("phone"),
                        email = reader.GetString("email"),
                        location = reader.GetString("location"),
                        isAdmin = reader.GetBoolean("is_admin"),
                        isBlocked = reader.GetBoolean("is_blocked")
                    };
                    reader.Close();
                    Session.CurrentUser = user;


                    if (!user.isBlocked)
                    {
                        if (user.isAdmin)
                        {
                            this.Hide();
                            new AdminOptions().ShowDialog();
                            this.Close();
                        }
                        else throw new Exception("User is not an admin!");
                    }
                    else throw new Exception("The user is blocked! \nContact administration for more details!");
                }
                else throw new Exception("Wrong username/password!");


            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conn.Close(); }
        }
    }
}