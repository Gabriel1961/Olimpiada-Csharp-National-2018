using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Olimpiada_Csharp_National_2018
{
    public partial class GhicesteRegiunea : Form
    {
        List<Point> harta = new List<Point>();
        List<List<Point>> regiuni = new List<List<Point>>();
        List<Point> caps = new List<Point>();
        List<int> order = new List<int>();
        List<string> numeReg = new List<string>();
        List<string> capNames = new List<string>();
        private int _Punctaj;
        public int Punctaj
        {
            get => _Punctaj;
            set
            {
                _Punctaj = value;
                labNota.Text = "Nota = " + _Punctaj;
            }
        }

        Utilizator uti;

        public GhicesteRegiunea(Utilizator uti)
        {
            this.uti = uti;
            InitializeComponent();
            float mapScaleFac = 1.4f;
            string[] lines = File.ReadAllLines("../../resurse/Harti/RomaniaMare.txt");
            foreach(string line in lines)
            {
                string[] cuv = line.Split('*');
                int x = int.Parse(cuv[0]);
                int y = int.Parse(cuv[1]);
                harta.Add(new Point((int)(x*mapScaleFac), (int)(y *mapScaleFac)));
            }

            var files = Directory.GetFiles("../../resurse/Harti");
            foreach(var file in files)
            {
                if (file.EndsWith("RomaniaMare.txt"))
                    continue;
                regiuni.Add(new List<Point>());
                var lns = File.ReadAllLines(file);
                var c = lns[0].Split('*');
                caps.Add(new Point((int)(int.Parse(c[0])*mapScaleFac), (int)(int.Parse(c[1])*mapScaleFac)));
                for(int i = 1; i < lns.Length; i++)
                {
                    var cuv = lns[i].Split('*');
                    int x = (int)(int.Parse(cuv[0])*mapScaleFac);
                    int y = (int)(int.Parse(cuv[1])*mapScaleFac);
                    regiuni[regiuni.Count - 1].Add(new Point(x, y));
                }
                var regName = new FileInfo(file).Name;
                numeReg.Add(regName.Substring(0, regName.Length - 4));
                capNames.Add(c[2]);
            }
            panel1.Paint += Panel1_Paint;
            Random random = new Random(DateTime.Now.Millisecond);

            for (int i = 0; i < regiuni.Count; i++)
                order.Add(i);
            order = order.OrderBy((r)=>random.Next()).ToList();
        }

        List<TextBox> tbs = new List<TextBox>();
        int curIntrebare = -1;
        void LoadLabel(int idx)
        {
            tbs.Clear();
            var reg = regiuni[idx];
            Point cen = new Point(0,0);
            foreach(var p in reg)
            {
                cen.X += p.X;
                cen.Y += p.Y;
            }
            cen.X /= reg.Count;
            cen.Y /= reg.Count;

            var tb = new TextBox { Parent=panel1, Top = cen.Y-10, Left = cen.X-35, MinimumSize = new Size(70,20) };
            tbs.Add(tb);
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            var p = new PathGradientBrush(harta.ToArray());
            var bl = new ColorBlend();
            bl.Positions = new float[] { 0, 0.5f, 1 };
            bl.Colors = new Color[] { Color.Red, Color.Yellow, Color.Blue };
            p.InterpolationColors = bl;
            e.Graphics.FillPolygon(p,harta.ToArray());
            e.Graphics.DrawPolygon(new Pen(Color.Green,10),harta.ToArray());
            foreach(var reg in regiuni)
            {
                e.Graphics.DrawPolygon(new Pen(Color.White, 5), reg.ToArray());
            }
        }

        private void raspunde(object sender, EventArgs e)
        {
            if (curIntrebare >= order.Count || curIntrebare==-1)
                return;
            var tb = tbs[tbs.Count - 1];
            string rasp = tb.Text;
            if (numeReg[order[curIntrebare]] == rasp)
            {
                Punctaj++;
            }
            else
            {
                tb.Font = new Font(tb.Font, FontStyle.Strikeout);
                tb.ReadOnly = true;
                new TextBox { Parent = panel1, Top = tb.Top + 20, Left = tb.Left,Text = numeReg[order[curIntrebare]],ReadOnly=true};
            }
            curIntrebare++;
            if (curIntrebare >= order.Count)
                return;
            LoadLabel(order[curIntrebare]);
        }

        private void startJoc(object sender, EventArgs e)
        {
            Punctaj = 0;
            curIntrebare = 0;
            LoadLabel(order[curIntrebare]);
        }

        private void genDiploma(object sender, EventArgs e)
        {
            var f = new Diploma(uti.Nume, Punctaj);
            f.ShowDialog();
        }

        Point ClosestPoint(Point p, bool[] vis)
        {
            Point pmin = new Point(0,0);
            float mnd = float.PositiveInfinity;
            int idx = -1;
            for (int i = 0; i < caps.Count; i++)
            {
                if (vis[i] || caps[i] == p)
                    continue;
                int x = p.X - caps[i].X;
                int y = p.Y- caps[i].Y;
                float d = (float)Math.Sqrt(x * x + y * y);
                if(d < mnd)
                {
                    idx = i;
                    mnd = d;
                    pmin = caps[i];
                }
            }
            vis[idx] = true;
            return pmin;
        }

        private async void genTraseu(object sender, EventArgs e)
        {
            poliLines.Clear();
            button4.Enabled = false;
            panel1.Controls.Clear();
            panel1.Paint += Panel1_Paint1;


            bool[] vis = new bool[caps.Count];
            int idx = capNames.IndexOf("Bucuresti");
            poliLines.Add(caps[idx]);
            poliLines.Add(caps[idx]);
            vis[idx] = true;
            Point lastP = caps[idx];

            panel1.Refresh();

            while (poliLines.Count != caps.Count+1)
            {
                await Task.Delay(2000);
                lastP = ClosestPoint(lastP,vis);
                poliLines.Add(lastP);
                panel1.Refresh();
            }

            await Task.Delay(2000);
            poliLines.Add(caps[idx]);
            panel1.Refresh();

            button4.Enabled = true;
            panel1.Paint -= Panel1_Paint1;
        }

        List<Point> poliLines = new List<Point>();

        private void Panel1_Paint1(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLines(new Pen(Brushes.Green, 3), poliLines.ToArray());
            
            for(int i=0;i<caps.Count;i++)
            {
                e.Graphics.DrawEllipse(Pens.Black, new RectangleF(caps[i].X - 2, caps[i].Y - 2, 8, 8));
                e.Graphics.DrawString(capNames[i],new Font("verdana",12),Brushes.Black,new PointF(caps[i].X+4, caps[i].Y-8));
            }
        }
    }
}
