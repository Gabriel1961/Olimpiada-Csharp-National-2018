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
    public partial class Diploma : Form
    {
        public Diploma(string numeElev,int punctaj)
        {
            string premiu;
            InitializeComponent();
            if (punctaj < 5)
                premiu = "diploma de participare";
            else if (punctaj < 8)
                premiu = "mentiune";
            else if (punctaj < 9)
                premiu = "premiul III";
            else if (punctaj < 10)
                premiu = "premiul II";
            else
                premiu = "premiul I";
            label2.Text = $"Se acorda elevului {numeElev} {premiu}";
        }
    }
}
