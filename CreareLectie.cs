using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Olimpiada_Csharp_National_2018
{
    public partial class CreareLectie : Form
    {

        Panel GetDefaultPanel()
        {
            var panelDefault = new Panel() { Dock = DockStyle.Fill };
            panelDefault.Paint += PanelDefault_Paint;
            panelDefault.Click += PanelDefault_Click;
            panelDefault.Tag = false;
            panelDefault.Padding = new Padding(3);
            return panelDefault;
        }

        Control GetActivePanel()
        {
            foreach (Control pan in tableLayoutPanel1.Controls)
                if ((bool)pan.Tag)
                    return pan;
            return null;
        }

        TextBox GetTextBox()
        {
            var tb = new TextBox() { Dock = DockStyle.Fill };
            tb.Click += (s, ev) => PanelDefault_Click(tb.Parent, null);
            tb.Multiline = true;
            tb.Font = new Font("verdana", 14);
            return tb;
        }
        Utilizator util;
        public CreareLectie(Utilizator uti)
        {
            this.util = uti;
            InitializeComponent();
            
            
            tableLayoutPanel1.Controls.Add(GetDefaultPanel(),0,0);
            tableLayoutPanel1.Controls.Add(GetDefaultPanel(),0,1);
            tableLayoutPanel1.Controls.Add(GetDefaultPanel(),1,0);
            tableLayoutPanel1.Controls.Add(GetDefaultPanel(),1,1);
        }

        private void PanelDefault_Click(object sender, EventArgs e)
        {
            var ctrl = (Control)sender;
            if((bool)ctrl.Tag==false)
                foreach (var con in tableLayoutPanel1.Controls)
                    ((Control)con).Tag = false;
            ctrl.Tag = !(bool)ctrl.Tag;
            tableLayoutPanel1.Refresh();

        }

        private void PanelDefault_Paint(object sender, PaintEventArgs e)
        {
            var ctrl = (Control)sender;
            if ((bool)ctrl.Tag)
            {
                var bounds = ctrl.ClientRectangle;
                ControlPaint.DrawBorder(e.Graphics, bounds, Color.Red, ButtonBorderStyle.Solid);
            }
        }

        private void stergeControl(object sender, EventArgs e)
        {
            var p = GetActivePanel();
            if (p != null)
            {
                p.Controls.Clear();
            }
        }

        private void adaugaText(object sender, EventArgs e)
        {
            GetActivePanel()?.Controls.Add(GetTextBox());
        }

        private void adaugaPoza(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            ofd.ShowDialog();
            try
            {
                var img = new Bitmap(ofd.FileName);
                var pb = new PictureBox
                {
                    Dock = DockStyle.Fill,
                    Image = img,
                    SizeMode = PictureBoxSizeMode.StretchImage
                };
                pb.Click += (s, ev) => PanelDefault_Click(pb.Parent, null);
                GetActivePanel()?.Controls.Add(pb);
            }
            catch (Exception)
            {

            }
        }

        private void reduceInaltime(object sender, EventArgs e)
        {
            var activePanel = GetActivePanel();
            if (activePanel != null)
            {
                var pos = tableLayoutPanel1.GetRow(activePanel);
                if(tableLayoutPanel1.RowStyles[pos].Height-10>0)
                tableLayoutPanel1.RowStyles[pos].Height -= 10;
            }
            tableLayoutPanel1.Refresh();
        }

        private void cresteInaltime(object sender, EventArgs e)
        {
            var activePanel = GetActivePanel();
            if (activePanel != null)
            {
                var pos = tableLayoutPanel1.GetRow(activePanel);
                tableLayoutPanel1.RowStyles[pos].Height += 10;
            }
            tableLayoutPanel1.Refresh();
        }

        private void cresteLungime(object sender, EventArgs e)
        {
            var activePanel = GetActivePanel();
            if (activePanel != null)
            {
                var pos = tableLayoutPanel1.GetColumn(activePanel);
                tableLayoutPanel1.ColumnStyles[pos].Width += 10;
            }
            tableLayoutPanel1.Refresh();
        }

        private void reduceLungime(object sender, EventArgs e)
        {
            var activePanel = GetActivePanel();
            if (activePanel != null)
            {
                var pos = tableLayoutPanel1.GetColumn(activePanel);
                if(tableLayoutPanel1.ColumnStyles[pos].Width - 10>0)
                tableLayoutPanel1.ColumnStyles[pos].Width -= 10;
            }
            tableLayoutPanel1.Refresh();
        }

        private void salvare(object sender, EventArgs e)
        {
            if (tbTitlu.Text.Length == 0)
            {
                MessageBox.Show("Lectia nu are titlu");
                return;
            }
            foreach(Control ct in tableLayoutPanel1.Controls)
                ct.Tag = false;
            var bmp = new Bitmap(1000, 1000);
            var sz = tableLayoutPanel1.Size;
            tableLayoutPanel1.Size = new Size(1000, 1000);
            tableLayoutPanel1.DrawToBitmap(bmp, new Rectangle(0, 0, 1000, 1000));
            tableLayoutPanel1.Refresh();
            bmp.Save("../../resurse/ContinutLectii/" + tbTitlu.Text + ".bmp");
            tableLayoutPanel1.Size = sz;
            Program.db.Lectii.Add(new Lectie
            {
                IdUtilizator = util.IdUtilizator,
                IdLectie = Program.db.Lectii.Count,
                DataCreare = DateTime.Now,
                NumeImagine = tbTitlu.Text,
                Regiune = tbRegiune.Text,
                TitluLectie = tbTitlu.Text
            });
            MessageBox.Show("Lectie salvata!");
        }

        private void randNou(object sender, EventArgs e)
        {
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            for (int i = 0; i < tableLayoutPanel1.ColumnCount; i++)
                tableLayoutPanel1.Controls.Add(GetDefaultPanel(), i, tableLayoutPanel1.RowCount);
            tableLayoutPanel1.RowCount++;
            tableLayoutPanel1.Refresh();
        }

        private void coloanaNoua(object sender, EventArgs e)
        {
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,50));
            for (int i = 0; i < tableLayoutPanel1.RowCount; i++)
                tableLayoutPanel1.Controls.Add(GetDefaultPanel(), tableLayoutPanel1.ColumnCount, i);
            tableLayoutPanel1.ColumnCount++;
            tableLayoutPanel1.Refresh();
        }

        private void stergeRand(object sender, EventArgs e)
        {
            var activePanel = GetActivePanel();
            if (activePanel != null && tableLayoutPanel1.RowCount != 2)
            {
                var pos = tableLayoutPanel1.GetRow(activePanel);
                List<Control> tbd = new List<Control>();
                foreach (Control ct in tableLayoutPanel1.Controls)
                {
                    int row = tableLayoutPanel1.GetRow(ct);
                    if (row == pos)
                        tbd.Add(ct);
                    if (row > pos)
                        tableLayoutPanel1.SetRow(ct, row - 1);
                }
                foreach (Control ct in tbd)
                    tableLayoutPanel1.Controls.Remove(ct);
                tableLayoutPanel1.RowStyles.RemoveAt(pos);
                tableLayoutPanel1.RowCount--;
            }
            tableLayoutPanel1.Refresh();
        }

        private void stergeColoana(object sender, EventArgs e)
        {
            var activePanel = GetActivePanel();
            if (activePanel != null && tableLayoutPanel1.ColumnCount!=2)
            {
                var pos = tableLayoutPanel1.GetColumn(activePanel);
                List<Control> tbd = new List<Control>();
                foreach (Control ct in tableLayoutPanel1.Controls)
                {
                    int col = tableLayoutPanel1.GetColumn(ct);
                    if (col == pos)
                        tbd.Add(ct);
                    if (col > pos)
                        tableLayoutPanel1.SetColumn(ct, col - 1);
                }
                foreach (Control ct in tbd)
                    tableLayoutPanel1.Controls.Remove(ct);
                tableLayoutPanel1.ColumnStyles.RemoveAt(pos);
                tableLayoutPanel1.ColumnCount--;
            }
            tableLayoutPanel1.Refresh();
        }
    }
}
