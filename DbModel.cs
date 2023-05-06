using System;
using System.Collections.Generic;

namespace Olimpiada_Csharp_National_2018
{
    public class DbModel
    {
        public List<Utilizator> Utilizatori;
        public List<Lectie> Lectii;
    }

    public class Utilizator
    {
        public int IdUtilizator { get;set; }
        public string Nume { get; set; }
        public string Parola { get; set; }
        public string Email { get; set; }
    }

    public class Lectie
    {
        public int IdLectie { get; set; }
        public int IdUtilizator { get; set; }
        public string TitluLectie { get; set; }
        public string Regiune { get; set; }
        public DateTime DataCreare { get; set; }
        public string NumeImagine { get; set; }
    }
}