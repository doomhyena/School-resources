using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login2
{
    public partial class Bejel : Form
    {
        SqlCommand cmd;
        SqlConnection cn;
        SqlDataReader dr;
        public Bejel()
        {
            InitializeComponent();
        }

        private void Bejel_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\kiss.adam\source\repos\Login2\Ab.mdf;Integrated Security=True");
            cn.Open();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (tbJelszo.Text != string.Empty || tbFnev.Text != string.Empty)
            {

                cmd = new SqlCommand("select * from felhasznalok where fnev='" + tbFnev.Text + "' and jelszo='" + tbJelszo.Text + "'", cn);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    dr.Close();
                    this.Hide();
                    Info home = new Info();
                    home.ShowDialog();
                }
                else
                {
                    dr.Close();
                    MessageBox.Show("Nincs ilyen fiók.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Tölts ki minden mezőt.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void btnRegre_Click(object sender, EventArgs e)
        {
            this.Hide();
            Reg registration = new Reg();
            registration.ShowDialog();
        }
    }
}
