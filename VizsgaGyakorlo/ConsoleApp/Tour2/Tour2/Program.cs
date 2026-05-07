namespace Tour2
{
    internal class Program
    {
        public static List<Versenyzo> versenyzok = new List<Versenyzo>();
        static void Main(string[] args)
        {
            ReadFile();
            Feladat1();
            Feladat2();
            Feladat3();
            Feladat4();
            Feladat5();
        }

        public static void ReadFile() {
            string[] files = File.ReadAllLines("tour.csv");
            foreach (var line in files.Skip(1))
            {
                string[] splitted = line.Split(";");
                Versenyzo versenyzo = new Versenyzo(Convert.ToInt32(splitted[0]), TimeSpan.Parse(splitted[1]), splitted[2], splitted[3], splitted[4]);
                versenyzok.Add(versenyzo);
            }
        }

        public static void Feladat1() {

            Console.WriteLine("4.Feladat:");

            var count = versenyzok.Count(v => v.Szakasz == 5);
            Console.WriteLine($"Versenyzők száma az 5. szakaszban: {count} fő");
        }
        public static void Feladat2()
        {

            Console.WriteLine("5.Feladat:");
            var avarage = versenyzok.Where(v=>v.Szakasz == 5).Average(v => v.Masodperc());
            var count = versenyzok.Count(v=>v.Szakasz == 5 && v.Masodperc()> avarage);
            Console.WriteLine($"Átlag feletti versenyzők száma az 5. szakaszban: {count} fő");

        }
        public static void Feladat3()
        {
            Console.WriteLine("6.Feladat:");
            var csoport = versenyzok.OrderBy(v=>v.Csapat).GroupBy(v=>v.Csapat);
            foreach (var item in csoport)
            {
                Console.WriteLine($"{item.Key}: {item.Average(v=>v.Masodperc()):n1}");
            }
        }
        public static void Feladat4()
        {
            Console.WriteLine("7.Feladat:");
            var count = versenyzok.Count(v => v.Kituntetes());
            Console.WriteLine($"Kitüntetett versenyzők száma: {count} fő");
        }
        public static void Feladat5()
        {
            Console.WriteLine("8.Feladat:");
            var best = versenyzok.Where(v => v.Szakasz == 5).OrderBy(v => v.Masodperc()).ToList();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{best[i].Nev}: {best[i].Ido:c}");
            }
        }

        }
}
