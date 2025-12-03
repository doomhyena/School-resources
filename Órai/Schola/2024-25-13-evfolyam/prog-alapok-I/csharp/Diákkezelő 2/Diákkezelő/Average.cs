using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diákkezelő
{
    public partial class Average : Form
    {
        private string teljesNev; 


        public Average(string nev)
        {
            InitializeComponent();
            teljesNev = nev;
            this.Load += new EventHandler(AverageForm_Load); 
        }

        private void AverageForm_Load(object sender, EventArgs e)
        {
            labelNev.Text = $"Üdv, {teljesNev}!";
        }

        private void btnSzamol_Click(object sender, EventArgs e)
        {
            try {
                double matek = Convert.ToDouble(txtMatematika.Text);
                double magyar = Convert.ToDouble(txtMagyar.Text);
                double tori = Convert.ToDouble(txtTori.Text);
                double angol = Convert.ToDouble(txtAngol.Text);
                double info = Convert.ToDouble(txtInfo.Text);

                double atlag = (matek + magyar + tori + angol + info) / 5;
                labelAtlag.Text = $"Átlag: {atlag:F2}";
            } catch {
                MessageBox.Show("Kérlek csak számokat adj meg 1 és 5 között!", "Hibás adat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}