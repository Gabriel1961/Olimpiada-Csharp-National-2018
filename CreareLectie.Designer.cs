namespace Olimpiada_Csharp_National_2018
{
    partial class CreareLectie
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbRegiune = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbTitlu = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbRegiune
            // 
            this.tbRegiune.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.tbRegiune.Location = new System.Drawing.Point(151, 81);
            this.tbRegiune.Name = "tbRegiune";
            this.tbRegiune.Size = new System.Drawing.Size(206, 26);
            this.tbRegiune.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label1.Location = new System.Drawing.Point(12, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Regiune Lectie";
            // 
            // tbTitlu
            // 
            this.tbTitlu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.tbTitlu.Location = new System.Drawing.Point(151, 37);
            this.tbTitlu.Name = "tbTitlu";
            this.tbTitlu.Size = new System.Drawing.Size(206, 26);
            this.tbTitlu.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Titlu lectie";
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.button1.Location = new System.Drawing.Point(97, 718);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(171, 40);
            this.button1.TabIndex = 12;
            this.button1.Text = "Salvare Lectie";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.salvare);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(377, 40);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(809, 718);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.button2.Location = new System.Drawing.Point(16, 162);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(145, 40);
            this.button2.TabIndex = 14;
            this.button2.Text = "Rand nou";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.randNou);
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.button3.Location = new System.Drawing.Point(197, 162);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(160, 40);
            this.button3.TabIndex = 15;
            this.button3.Text = "Sterge rand";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.stergeRand);
            // 
            // button4
            // 
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.button4.Location = new System.Drawing.Point(16, 229);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(145, 40);
            this.button4.TabIndex = 16;
            this.button4.Text = "Coloana noua";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.coloanaNoua);
            // 
            // button5
            // 
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.button5.Location = new System.Drawing.Point(195, 229);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(162, 40);
            this.button5.TabIndex = 17;
            this.button5.Text = "Sterge coloana";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.stergeColoana);
            // 
            // button6
            // 
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.button6.Location = new System.Drawing.Point(197, 427);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(122, 61);
            this.button6.TabIndex = 21;
            this.button6.Text = "Creste lungime";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.cresteLungime);
            // 
            // button7
            // 
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.button7.Location = new System.Drawing.Point(44, 427);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(117, 61);
            this.button7.TabIndex = 20;
            this.button7.Text = "Reduce lungime";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.reduceLungime);
            // 
            // button8
            // 
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.button8.Location = new System.Drawing.Point(197, 339);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(122, 61);
            this.button8.TabIndex = 19;
            this.button8.Text = "Creste inaltime";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.cresteInaltime);
            // 
            // button9
            // 
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.button9.Location = new System.Drawing.Point(44, 339);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(117, 61);
            this.button9.TabIndex = 18;
            this.button9.Text = "Reduce inaltime";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.reduceInaltime);
            // 
            // button10
            // 
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.button10.Location = new System.Drawing.Point(44, 615);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(117, 61);
            this.button10.TabIndex = 22;
            this.button10.Text = "Text";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.adaugaText);
            // 
            // button11
            // 
            this.button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.button11.Location = new System.Drawing.Point(197, 615);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(122, 61);
            this.button11.TabIndex = 23;
            this.button11.Text = "Poza";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.adaugaPoza);
            // 
            // button12
            // 
            this.button12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.button12.Location = new System.Drawing.Point(124, 523);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(117, 61);
            this.button12.TabIndex = 24;
            this.button12.Text = "Sterge Control";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.stergeControl);
            // 
            // CreareLectie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1198, 770);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbRegiune);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbTitlu);
            this.Controls.Add(this.label2);
            this.Name = "CreareLectie";
            this.Text = "CreareLectie";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbRegiune;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbTitlu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
    }
}