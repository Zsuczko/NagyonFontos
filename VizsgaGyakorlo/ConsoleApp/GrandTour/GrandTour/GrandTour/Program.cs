namespace GrandTour
{
    internal class Program
    {
        public static List<Versenyzo> versenyzok = new List<Versenyzo>();
        static void Main(string[] args)
        {
            ReadFile();
            Feladat4();
            Feladat5();
            Feladat6();
            Feladat7();
            Feladat8();
        }

        static public void ReadFile()
        {
            string[] lines = File.ReadAllLines("stage.csv");
            foreach (var item in lines.Skip(1))
            {
                var splitted = item.Split(";");
                var uj = new Versenyzo(Convert.ToInt32(splitted[0]), TimeSpan.Parse(splitted[1]), splitted[2], splitted[3], splitted[4]);
                versenyzok.Add(uj);
            }
        }

        static public void Feladat4() {
            Console.WriteLine("4.Feladat: ");
            var count = versenyzok.Count(x => x.Szakasz == 3);
            Console.WriteLine($"Versenyzők száma a 3.szakaszban: {count} fő");
        }

        static public void Feladat5()
        {
            Console.WriteLine("5.Feladat: ");
            var average = versenyzok.Where(x => x.Szakasz == 3).Average(v => v.Masodperc());
            var count = versenyzok.Count(v => v.Masodperc() < average);
            Console.WriteLine($"Átlag alatt: {count} fő");
        }
        static public void Feladat6()
        {
            Console.WriteLine("6.Feladat: ");
            var group = versenyzok.GroupBy(v => v.Nemzetiseg).OrderBy(v=>v.Key);
            foreach (var item in group)
            {
                var average = item.Average(v => v.Masodperc());
                Console.WriteLine($"{item.Key}: {average:n1}");

            }
        }
        static public void Feladat7()
        {
            Console.WriteLine("7.Feladat: ");
            Console.WriteLine($"Különdíjas versenyzők száma: {versenyzok.Count(v=>v.Kulondij())} fő");
        }
        static public void Feladat8()
        {
            Console.WriteLine("8.Feladat: ");
            var best = versenyzok.Where(v => v.Szakasz == 3).OrderBy(v=>v.Masodperc()).ToList();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"{best[i].Nev}: {best[i].Ido.ToString("c")}");
            }
        }

    }
}
