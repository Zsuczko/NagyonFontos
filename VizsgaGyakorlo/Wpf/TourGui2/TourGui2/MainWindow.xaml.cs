using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;

namespace TourGui2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly TourContext _context = new TourContext();
        public MainWindow()
        {
            InitializeComponent();
            Init();
        }

        public void Init() {

            var sor = _context.Versenyzos.Include(x => x.Csapat).Select(v => new VersenyzoSorDTO{ Id = v.Id, Nev = v.Nev, CsapatNev = v.Csapat.CsapatNev, Nemzetiseg = v.Nemzetiseg }).ToList();
            MyDataGrid.ItemsSource = sor;
        }

        public class VersenyzoSorDTO { 
        
            public int Id { get; set; }
            public string Nev { get; set; }
            public string CsapatNev { get; set; }
            public string Nemzetiseg { get; set; }
        }

        private void MyDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var sor = (VersenyzoSorDTO)MyDataGrid.SelectedItem;
            var elem = _context.Eredmenies.FirstOrDefault(v => v.VersenyzoId == sor.Id && v.Szakasz == 5);
            var iras = "";
            if (elem is null)
                iras = "Nincs ilyen adat";
            else
                iras = elem.Ido.ToString();
            MyLabel.Content = $"5. szakasz eredménye: {iras}";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var sorok = _context.Versenyzos.Include(v => v.Csapat).GroupBy(v => v.Csapat.CsapatNev);
            var list = new List<string>();
            foreach (var item in sorok)
            {
                list.Add($"{item.Key}: {item.Count()} fő");
            }
            MyListBox.ItemsSource = list;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var count = _context.Versenyzos.Count(v => v.Nemzetiseg == "HUN");
            MessageBox.Show($"Magyar versenyzők száma: {count} fő");
        }
    }
}