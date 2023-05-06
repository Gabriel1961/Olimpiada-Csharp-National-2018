using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Olimpiada_Csharp_National_2018
{
    internal static class Program
    {
        public static DbModel db;
        static void LoadDb()
        {
            if (File.Exists("../../CentenarDB.xml"))
            {
                var ser = new XmlSerializer(typeof(DbModel));
                var f = File.OpenRead("../../CentenarDB.xml");
                db = (DbModel)ser.Deserialize(f);
                f.Close();
                f.Dispose();
            }
            else
            {
                db = new DbModel();
                db.Lectii = new List<Lectie>();
                db.Utilizatori = new List<Utilizator>();
                string[] lines = File.ReadAllLines("../../resurse/utilizatori.txt");
                foreach(string line in lines)
                {
                    string[] cuv = line.Split('*');
                    var ut = new Utilizator
                    {
                        IdUtilizator = db.Utilizatori.Count + 1,
                        Nume = cuv[0],
                        Parola = cuv[1],
                        Email = cuv[2]
                    };
                    db.Utilizatori.Add(ut);
                }

                lines = File.ReadAllLines("../../resurse/lectii.txt");
                foreach (string line in lines)
                {
                    string[] cuv = line.Split('*');
                    var le = new Lectie
                    {
                        IdLectie = db.Utilizatori.Count + 1,
                        IdUtilizator = int.Parse(cuv[0]),
                        TitluLectie = cuv[1],
                        Regiune = cuv[cuv.Length-3],
                        DataCreare = DateTime.Parse(cuv[cuv.Length-1]),
                        NumeImagine = cuv[cuv.Length-2]
                    };
                    db.Lectii.Add(le);
                }
            }
        }

        static void SaveDb()
        {
            var ser = new XmlSerializer(typeof(DbModel));
            var f = File.OpenWrite("../../CentenarDB.xml");
            ser.Serialize(f, db);
            f.Close();
            f.Dispose();
        }

        [STAThread]
        static void Main()
        {
            LoadDb();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new VizualizareLectii());
            SaveDb();
        }
    }
}
