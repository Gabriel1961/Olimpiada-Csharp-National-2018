using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Olimpiada_Csharp_National_2018
{
    public partial class AlegeJoc : Form
    {
        Utilizator uti;
        public AlegeJoc(Utilizator uti)
        {
            InitializeComponent();
            this.uti = uti;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new CreareLectie(uti);
            form.Show();
            this.Hide();
            form.FormClosed += (s, ev) => this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form = new GhicesteRegiunea(uti);
            form.Show();
            this.Hide();
            form.FormClosed += (s, ev) => this.Close();
        }
    }
}
