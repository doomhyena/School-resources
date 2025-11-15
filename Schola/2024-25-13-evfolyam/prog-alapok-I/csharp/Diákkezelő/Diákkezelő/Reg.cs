using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Diákkezelő
{
    public partial class Reg : Form
    {
        public Reg()
        {
            InitializeComponent();
        }

        private void regbtn_Click(object sender, EventArgs e)
        {
            try
            {
                var conn = Program.DbConnection;
                if (conn.State != System.Data.ConnectionState.Open)
                    conn.Open();

                string query = "INSERT INTO users (firstname, lastname, email, entercode, password) VALUES (@fn, @ln, @em, @code, @pw)";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@fn", firstname.Text);
                    cmd.Parameters.AddWithValue("@ln", lastname.Text);
                    cmd.Parameters.AddWithValue("@em", email.Text);
                    cmd.Parameters.AddWithValue("@code", entercode.Text);
                    cmd.Parameters.AddWithValue("@pw", password.Text);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Sikeres regisztráció!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba: " + ex.Message);
            }
        }


        private void loginbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var loginForm = new Login();
            loginForm.ShowDialog();
            this.Show();
        }
    }
}
