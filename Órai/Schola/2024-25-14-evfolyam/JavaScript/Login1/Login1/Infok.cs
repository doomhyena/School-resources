using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;

namespace Login1
{
    public partial class Infok : Form
    {
        private readonly string felhasznalonev;
        private readonly MySqlConnection csatl;
        public Infok(string felhasznalonev)
            //Az ablak kezel egy felhasználónév paramétert, ami alapján kiolvassa az adatbázis releváns sorát.
        {
            InitializeComponent();
            this.felhasznalonev = felhasznalonev;
            csatl = new MySqlConnection("server=localhost;database=csharploginform;port=3306;username=root;password=");
            AdatKiir();//A metódus, ami lebonyolítja az adatok megjelenítését lejjebb.
        }
        private void AdatKiir()
        {
            try
            {
                csatl.Open();
                //Kell egy SQL lekérdezés sablon a felhasználó adatainak kiolvasására:
                string query = "SELECT * FROM felhasznalok WHERE FNev = @FNEV";
                //Előkészítjük az éppen kezelt név behelyettesítését:
                MySqlCommand paranc = new MySqlCommand(query,csatl);
                paranc.Parameters.AddWithValue("@FNEV", felhasznalonev);
                using (MySqlDataReader olvaso = paranc.ExecuteReader())
                {
                    if (olvaso.Read()) //Ha sikerült beolvasnia valamit
                    {//Bevisszük az adatokat a feliratként szolgáló 4 db cimkébe:
                        lVez.Text = olvaso["VNev"].ToString();
                        lKer.Text = olvaso["KNev"].ToString();
                        lFelh.Text = olvaso["FNev"].ToString();
                        lFogl.Text = olvaso["Foglalkozas"].ToString();
                        //Itt a 4 [adat]-ra úgy hivatkoztam, ahogy az adatbázisban szerepelnek.
                    }
                }
            }
            catch (Exception ex)
            {//Ha valami problémába ütközött, akkor dobjon egy hibaüzenetet és záródjon be:
                MessageBox.Show(ex.Message);
                this.Close();
            }
        }

        private void btnKijel_Click(object sender, EventArgs e)
        {//A Kijelentkezés gomb visszavisz a Login formra:
            this.Hide();
            Login bejel = new Login();
            bejel.Show();
        }
    }
}
