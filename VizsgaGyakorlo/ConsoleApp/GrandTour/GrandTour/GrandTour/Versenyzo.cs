using System;
using System.Collections.Generic;
using System.Text;

namespace GrandTour
{
    internal class Versenyzo
    {
        public int Szakasz { get; set; }
        public TimeSpan Ido { get; set; }
        public string Nev{ get; set; }
        public string Nemzetiseg { get; set; }
        public string Csapat { get; set; }

        public Versenyzo(int szakasz, TimeSpan ido, string nev, string nemzetiseg, string csapat) {
            Szakasz = szakasz;
            Ido = ido;
            Nev = nev;
            Nemzetiseg = nemzetiseg;
            Csapat = csapat;
        }

        public double Masodperc() {
            return Ido.TotalSeconds;
        }
        public bool Kulondij() {
            return Nemzetiseg == "FRA" && Ido.Hours < 4;
        }

    }
}
