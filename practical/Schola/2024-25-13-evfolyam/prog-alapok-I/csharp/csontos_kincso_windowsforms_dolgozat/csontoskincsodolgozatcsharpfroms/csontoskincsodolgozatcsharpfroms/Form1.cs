namespace csontoskincsodolgozatcsharpfroms
{
    public partial class Form1 : Form
    {
        private int felvittSorokSzama = 0;

        public Form1()
        {
            InitializeComponent();
            labelDatum.Text = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss"); // Aktuális dátum
        }

        private void buttonFelvitel_Click(object sender, EventArgs e)
        {
            string tantargy = textBoxTantargy.Text;
            string temakor = textBoxTemakor.Text;
            string maxPontszam = textBoxMaxPontszam.Text;
            string atlag = textBoxAtlag.Text;

            if (string.IsNullOrWhiteSpace(tantargy) || string.IsNullOrWhiteSpace(temakor) || string.IsNullOrWhiteSpace(maxPontszam) || string.IsNullOrWhiteSpace(atlag))
            {
                MessageBox.Show("Minden mezõt ki kell tölteni!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string sor = $"Tantárgy: {tantargy}, Téma: {temakor}, Max Pontszám: {maxPontszam}, Átlag: {atlag}";
            listBoxFelvittAdatok.Items.Add(sor);
            felvittSorokSzama++;
            labelFelvittSorokSzama.Text = $"Felvitt sorok száma: {felvittSorokSzama}";
        }

        private void buttonTorlodes_Click(object sender, EventArgs e)
        {
            listBoxFelvittAdatok.Items.Clear();
            felvittSorokSzama = 0;
            labelFelvittSorokSzama.Text = $"Felvitt sorok száma: {felvittSorokSzama}";
        }

        private void buttonBezaro_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSugo_Click(object sender, EventArgs e)
        {
            Form sugoForm = new SugoForm();
            sugoForm.Show();
        }

        private void listBoxFelvittAdatok_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
