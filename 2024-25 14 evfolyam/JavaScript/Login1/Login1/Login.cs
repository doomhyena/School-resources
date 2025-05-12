using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login1
{
    public partial class Login : Form
    {
        MySqlConnection csatlakozo = new MySqlConnection("server=localhost;database=csharploginform;port=3306;username=root;password=");
        MySqlCommand parancs;
        MySqlDataReader dr;

        public Login()
        {
            InitializeComponent();
        }

        private void btnBejel_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(tbFNEV.Text) || string.IsNullOrEmpty(tbJSZ.Text))
                {
                    MessageBox.Show("Adj meg egy nevet és egy jelszót is!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                csatlakozo.Open();
                string selectQuery = "SELECT * FROM felhasznalok WHERE FNev = @FNEV AND Jelszo = @JSZ";
                parancs = new MySqlCommand(selectQuery, csatlakozo);
                parancs.Parameters.AddWithValue("@FNEV", tbFNEV.Text);
                parancs.Parameters.AddWithValue("@JSZ", tbJSZ.Text);
                dr = parancs.ExecuteReader();

                if (dr.Read()) //Ha be tudott olvasni adatokat:
                {
                    MessageBox.Show("Sikeres login!", "Siker", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide(); //Elrejtjük ezt a Login ablakot
                    string BejelUser = tbFNEV.Text;
                    Infok infoablak = new Infok(BejelUser);
                    infoablak.Show();
                }
                else
                {//Ha valamelyik adat el lett írva:
                    MessageBox.Show("Helytelen név vagy jelszó!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);//Írja ki a probléma jellegét
            }
            finally
            {//Csatlakozás bezárása (ha még nyitva van):
                if (csatlakozo.State == ConnectionState.Open)
                {
                    csatlakozo.Close();
                }
            }
        }

        private void btnRegRe_Click(object sender, EventArgs e)
        {
            this.Hide();
            Reg regisztral = new Reg();
            regisztral.Show();
        }
    }
}
