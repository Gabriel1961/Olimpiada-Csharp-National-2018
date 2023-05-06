using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Olimpiada_Csharp_National_2018
{
    public partial class AmUitatParola : Form
    {
        Dictionary<PictureBox, bool> boxes = new Dictionary<PictureBox, bool>();

        Dictionary<Image, bool> GetRandomImages()
        {
            (Image, bool)[] images = new (Image, bool)[20];
            string[] om = File.ReadAllLines("../../resurse/oameni.txt");
            foreach (string o in om)
                images[int.Parse(o.Substring(0, o.IndexOf('.')))-1].Item2 = true; 
            
            for (int i = 0; i < 20; i++)
                images[i].Item1 = new Bitmap("../../resurse/Captcha/" + (i + 1) + ".jpg");


            Random rnd = new Random();
            return images.OrderBy((v) => rnd.Next()).Take(6).ToDictionary((e) => e.Item1, (e) => e.Item2);
        }

        Dictionary<Image, bool> imgs;

        void LoadImages()
        {
            imgs = GetRandomImages();

            var ims = imgs.ToList();

            int i = 0;
            foreach (var b in boxes)
            {
                b.Key.Image = ims[i].Key;
                i++;
            }
        }

        Utilizator util;
        public AmUitatParola(Utilizator util)
        {
            this.util = util;
            InitializeComponent();

            boxes.Add(pictureBox1, false);
            boxes.Add(pictureBox2, false);
            boxes.Add(pictureBox3, false);
            boxes.Add(pictureBox4, false);
            boxes.Add(pictureBox5, false);
            boxes.Add(pictureBox6, false);

            foreach (var b in boxes)
            {
                b.Key.Paint += Item1_Paint;
                b.Key.Click += Key_Click;
            }

            LoadImages();
        }

        private void Key_Click(object sender, EventArgs e)
        {
            var pb = (PictureBox)sender;
            boxes[pb] = !boxes[pb];
            pb.Refresh();

        }

        private void Item1_Paint(object sender, PaintEventArgs e)
        {
            var pb = (PictureBox)sender;
            if (boxes[pb])
            {
                ControlPaint.DrawBorder(e.Graphics, pb.ClientRectangle, Color.Blue, ButtonBorderStyle.Solid);
            }
        }

        private void SalvareClick(object sender, EventArgs e)
        {
            int ok = 1;
            foreach (var b in boxes)
            {
                if (imgs[b.Key.Image] != b.Value)
                {
                    ok = 0;
                }
            }

            if(ok == 0 || tbParola.Text != tbConfirm.Text)
            {
                MessageBox.Show("Eroare de autentificare!");
                tbParola.Clear();
                tbConfirm.Clear();
                LoadImages();
                return;
            }

            util.Parola = tbParola.Text; 

            this.Close();
        }

        private void AnulareClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
