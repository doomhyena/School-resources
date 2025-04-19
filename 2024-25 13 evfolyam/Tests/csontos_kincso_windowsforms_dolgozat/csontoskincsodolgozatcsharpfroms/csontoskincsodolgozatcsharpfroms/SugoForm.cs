using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csontoskincsodolgozatcsharpfroms
{
    public partial class SugoForm : Form
    {
        public SugoForm()
        {
            InitializeComponent();
        }
        private void buttonVissza_Click(object sender, EventArgs e)
        {
            this.Close(); // Bezárja a súgó ablakot
        }
    }
}
