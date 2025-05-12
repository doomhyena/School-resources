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
using MySqlConnector;//Adatbázisos modul
/*
Ha nem jó a connector, akkor: Tools --> NuGet Package Manager --> Konzol
Ott futtatni ezt: NuGet\Install-Package MySqlConnector -Version 2.4.0
*/

//A projekthez tartozó phpMyAdmin adatbázis: ID (auto inkrementált), VNev, KNev, FNev, Foglalkozas, Jelszo.

namespace Login1
{
    public partial class Reg : Form
    {
        //Megadom az adatbázis elérését, amit a xampp segítségével hoztam létre:
        MySqlConnection csatlakozo = new MySqlConnection("server=localhost;database=csharploginform;port=3306;username=root;password=");
        //localhost, mert a xampp-ról fut; ott az adatbázist csharploginform-nak neveztem el; port alapból 4406 lesz, a password pedig üres
        public Reg()
        {
            InitializeComponent();
        }

        private void btnReg_Click(object sender, EventArgs e)
        {//Regisztrációs gomb működése:
            try //Az egészet try-catch szegmensbe foglalom, hogy probléma esetén ne fagyjon ki a program
            {
                //Ha az egyik mezőt nem tültötte ki a felhasználó, akkor rászólunk:
                if (string.IsNullOrEmpty(tbVez.Text) || string.IsNullOrEmpty(tbKer.Text) || string.IsNullOrEmpty(tbFelh.Text) || string.IsNullOrEmpty(tbFogl.Text) || string.IsNullOrEmpty(tbJsz.Text))
                {
                    MessageBox.Show("Tölts ki minden mezőt!");
                    return;
                }
                csatlakozo.Open();//Megnyitom az adatbázis csatlakozást
                //Ellenőrzöm, hogy van-e ilyen nevű felhasználó az adatbázisban:
                MySqlCommand parancssablon = new MySqlCommand("SELECT * FROM felhasznalok WHERE FNev = @fnev", csatlakozo);
                //(fontos, hogy itt úgy hivatkozzunk az értékekre, ahogy azok a mögöttes adatbázisban is szerepelnek)
                parancssablon.Parameters.AddWithValue("@fnev", tbFelh.Text);//így hivatkozom be a sablonba a konkrét felhasználónevet
                bool fh_letezik = false;
                //Ha már létezik (a keresés kiad legalább 1 sornyi találatot), akkor azt jelzem egy üzenettel:
                using (var dr1 = parancssablon.ExecuteReader())
                    if (fh_letezik = dr1.HasRows) MessageBox.Show("Foglalt név!");

                if (!fh_letezik)//Ha fh_letezik értéke hamis
                {
                    //Összerakom a behelyező sql parancs sablonját:
                    string insertsablon = "INSERT INTO csharploginform.felhasznalok(`ID`, `VNev`, `KNev`, `FNev`, `Foglalkozas`, `Jelszo`) VALUES(NULL,@vnev, @knev, @fnev, @fogl, @jsz)";
                    MySqlCommand abSeged = new MySqlCommand(insertsablon, csatlakozo);
                    //Megadom, hogy honnan olvassa be a felvinni kívánt adatokat:
                    abSeged.Parameters.AddWithValue("@vnev", tbVez.Text);
                    abSeged.Parameters.AddWithValue("@knev", tbKer.Text);
                    abSeged.Parameters.AddWithValue("@fnev", tbFelh.Text);
                    abSeged.Parameters.AddWithValue("@fogl", tbFogl.Text);
                    abSeged.Parameters.AddWithValue("@jsz", tbJsz.Text);


                    abSeged.CommandTimeout = 60;
                    abSeged.ExecuteNonQuery();
                    MessageBox.Show("Sikeres regisztráció", "Siker", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    //Nyitok egy információs ablakot az aktuális felhasználó adataival:
                    string aktualisFH = tbFelh.Text;
                    Infok infoablak1 = new Infok(aktualisFH);
                    infoablak1.Show(); ;
                }
            }
            catch (Exception ex)//Ha nem tudta elvégezni a fenti műveleteket:
            {
                MessageBox.Show("Hiba történt" + ex.Message, "Error");
            }
            finally//Végül be kell zárni az adatbázis csatlakozást:
            {
                csatlakozo.Close();
            }
        }

        private void btnAt_Click(object sender, EventArgs e)
        {//A bejelentkező ablakra átirányító gomb működése:
            this.Hide();//Elrejtem ezt a regisztrációs ablakot
            Login loginablak1 = new Login(); //Nyitok egy új példánxt a Login ablakhoz
            loginablak1.Show();//Meg is kell jeleníteni azt
        }
    }
}
