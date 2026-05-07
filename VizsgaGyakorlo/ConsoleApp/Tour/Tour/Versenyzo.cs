using System;
using System.Collections.Generic;
using System.Text;

namespace Tour
{
    internal class Versenyzo
    {
        public int Szakasz { get; set; }
        public TimeSpan Ido { get; set; }
        public string Nev { get; set; }
        public string Nemzetiseg { get; set; }
        public string Csapat { get; set; }

        public Versenyzo(int szakasz, TimeSpan ido, string nev, string nemzetiseg, string csapat) {
            Szakasz = szakasz;
            Ido = ido;
            Nev = nev;
            Nemzetiseg = nemzetiseg;
            Csapat = csapat;
        }

        public int Masodperc() {

            //var seconds = Ido.Hours * 3600 + Ido.Minutes * 60 + Ido.Seconds;

            return (int)Ido.TotalSeconds;
        }

        public bool Kituntetes() {

            bool eredmeny = false;
            if (Nemzetiseg == "USA") {
                if (Ido.Hours < 3) {
                    eredmeny = true;
                }
            }

            return eredmeny;
        }
    }
}
