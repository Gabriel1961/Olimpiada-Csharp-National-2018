using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Olimpiada_Csharp_National_2018
{
    public partial class Logare : Form
    {
        public Logare()
        {
            InitializeComponent();
        }

        private void LoginClick(object sender, EventArgs e)
        {
            var uti = Program.db.Utilizatori.Find((ut) => ut.Email == tbEmail.Text && ut.Parola == tbParola.Text);
            if(uti != null)
            {
                var form = new AlegeJoc(uti);
                form.FormClosed += (s, ev) => this.Close();
                this.Hide();
                form.Show();
            }
            else
            {
                MessageBox.Show("Eroare de autentificare!");
            }
        }

        private void UitatParola(object sender, EventArgs e)
        {
            var uti = Program.db.Utilizatori.Find((ut) => ut.Email == tbEmail.Text);
            if(uti != null)
            {
                var f = new AmUitatParola(uti);
                f.FormClosed += (s, ev) => this.Show();
                this.Hide();
                f.Show();
                tbEmail.Clear();
                tbParola.Clear();
            }
            else
            {
                MessageBox.Show("Email invalid!");
            }
        }
    }
}
