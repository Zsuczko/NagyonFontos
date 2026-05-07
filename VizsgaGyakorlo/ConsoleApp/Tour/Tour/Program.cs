using System.Net.WebSockets;
using static System.Net.WebRequestMethods;

namespace Tour
{
    internal class Program
    {

        public static List<Versenyzo> versenyzok = new List<Versenyzo>();

        static void Main(string[] args)
        {
            FirstEx();
            SecondEx();
            ThirdEx();
            FourthEx();
            FifthEx();
            SixthEx();
        }

        public static void FirstEx()
        {

            string[] lines = System.IO.File.ReadAllLines("tour.csv");

            foreach (var line in lines.Skip(1))
            {

                var splited = line.Split(";");

                Versenyzo ember = new Versenyzo(Convert.ToInt32(splited[0]), TimeSpan.Parse(splited[1]), splited[2], splited[3], splited[4]);
                versenyzok.Add(ember);
            }
        }

        public static void SecondEx()
        {
            Console.WriteLine("4. Feladat:");
            var five = versenyzok.Where(v => v.Szakasz == 5);
            Console.WriteLine($"Versenyzők száma az 5. szakaszban: {five.Count()}");
        }

        public static void ThirdEx()
        {
            Console.WriteLine("5. Feladat:");

            var avarage = versenyzok.Where(v => v.Szakasz == 5).Average(v => v.Masodperc());
            var lenght = versenyzok.Count(v => v.Masodperc() > avarage && v.Szakasz == 5);
            Console.WriteLine($"Átlag feletti versenyzők száma az 5. szakaszban: {lenght}");
        }
        public static void FourthEx()
        {
            Console.WriteLine("6. Feladat:");
            var csapatok = versenyzok.GroupBy(v => v.Csapat);
            foreach (var csapat in csapatok)
            {
                Console.WriteLine($"{csapat.Key}: {csapat.Average(v => v.Masodperc()):n1}");
            }
        }
        public static void FifthEx()
        {
            Console.WriteLine("7. Feladat:");
            var length = versenyzok.Count(v => v.Kituntetes());
            Console.WriteLine($"Kitüntetett versenyzők: {length}");

        }
        public static void SixthEx()
        {
            Console.WriteLine("8. Feladat:");
            var legjobbak = versenyzok.Where(v=>v.Szakasz == 5).OrderBy(v => v.Masodperc()).ToList();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{legjobbak[i].Nev}, {legjobbak[i].Ido.ToString(@"hh\:mm\:ss")}");
            }
        }
        
    }
}
