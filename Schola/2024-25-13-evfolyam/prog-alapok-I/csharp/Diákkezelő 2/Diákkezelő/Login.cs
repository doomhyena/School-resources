using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Diákkezelő
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void loginbtn_Click(object sender, EventArgs e)
        {
            try {
                var conn = Program.DbConnection;
                if (conn.State != System.Data.ConnectionState.Open)
                    conn.Open();

                string query = "SELECT firstname, lastname FROM users WHERE entercode = @code AND password = @pw";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@code", entercode.Text);
                    cmd.Parameters.AddWithValue("@pw", password.Text);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read()) {
                            string firstname = reader["firstname"].ToString();
                            string lastname = reader["lastname"].ToString();
                            string teljesNev = firstname + " " + lastname;

                            MessageBox.Show("Sikeres bejelentkezés!");

                            this.Hide();
                            var avgForm = new Average(teljesNev);
                            avgForm.ShowDialog();
                            this.Show();
                        } else {
                            MessageBox.Show("Hibás kód vagy jelszó!");
                        }
                    }
                }
            } catch (Exception ex) {
                MessageBox.Show("Hiba: " + ex.Message);
            }
        }

        private void regbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var regForm = new Reg();
            regForm.ShowDialog();
            this.Show();
        }
    }
}
