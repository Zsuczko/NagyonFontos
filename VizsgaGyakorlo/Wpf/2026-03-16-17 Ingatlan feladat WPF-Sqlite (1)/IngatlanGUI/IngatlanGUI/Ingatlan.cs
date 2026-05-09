using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngatlanGUI
{
    internal class Ingatlan
    {
        public Ingatlan(int id, string kozterulet, string hazszam, bool lakas, string falazat)
        {
            Id = id;
            Kozterulet = kozterulet;
            Hazszam = hazszam;
            Lakas = lakas;
            Falazat = falazat;
        }

        public int Id {  get; set; }
        public string Kozterulet {  get; set; }
        public string Hazszam {  get; set; }
        public bool Lakas {  get; set; }
        public string Falazat {  get; set; }

    }
}
