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
    public partial class VizualizareLectii : Form
    {
        public VizualizareLectii()
        {
            InitializeComponent();
            LoadLectii();
            textBox1.ReadOnly = true;
        }

        void LoadLectii()
        {
            listView1.Clear();
            foreach(var l in Program.db.Lectii)
            {
                listView1.Items.Add(l.NumeImagine);
            }
        }

        void LoadLectie(Lectie lec)
        {
            pictureBox1.Image = new Bitmap("../../resurse/ContinutLectii/" + lec.NumeImagine + ".bmp");
            var au = Program.db.Utilizatori[lec.IdUtilizator - 1];
            textBox1.Text = $"Autor lectie: {au.Nume}\r\nEmail: {au.Email}\r\nRegiunea: {lec.Regiune}\r\nData creare: {lec.DataCreare}";
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count == 0)
                return;
            LoadLectie(Program.db.Lectii[listView1.SelectedIndices[0]]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new Logare();
            form.FormClosed += (s, ev) =>
            {
                this.Show();
                LoadLectii();
            };
            this.Hide();
            form.Show();
        }
    }
}
