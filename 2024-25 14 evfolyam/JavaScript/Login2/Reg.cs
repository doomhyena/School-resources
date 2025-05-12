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
    public partial class Reg : Form
    {
        SqlCommand cmd;
        SqlConnection cn;
        SqlDataReader dr;
        public Reg()
        {
            InitializeComponent();
        }

        private void Reg_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\kiss.adam\source\repos\Login2\Ab.mdf;Integrated Security=True");
            cn.Open();
        }

        private void btnLoginra_Click(object sender, EventArgs e)
        {
            this.Hide();
            Bejel login = new Bejel();
            login.ShowDialog();
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            if (tbMeger.Text != string.Empty || tbJSZ.Text != string.Empty || tbFN.Text != string.Empty)
            {
                if (tbJSZ.Text == tbMeger.Text)
                {
                    cmd = new SqlCommand("select * from felhasznalok where fnev='" + tbFN.Text + "'", cn);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        dr.Close();
                        MessageBox.Show("Már van ilyen felhasználó!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        dr.Close();
                        cmd = new SqlCommand("insert into felhasznalok values(@fnev,@jelszo)", cn);
                        cmd.Parameters.AddWithValue("fnev", tbFN.Text);
                        cmd.Parameters.AddWithValue("jelszo", tbJSZ.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Felhasználó létrehozva.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("A két jelszónak egyeznie kell.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Minden mezőt tölts ki!.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
