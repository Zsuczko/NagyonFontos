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

namespace LibraryGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private readonly LibraryContext _context = new LibraryContext();
        public MainWindow()
        {
            InitializeComponent();
            ReadDb();
        }

        public void ReadDb() {
            var elemek = _context.Konyvs.Include(x=>x.Szerzo).Select(x => new konyvDTO{ Id = x.Id, Cim = x.Cim, Mufaj = x.Mufaj, SzerzoNeve = x.Szerzo.Nev, KiadasEv = x.KiadasEve}).ToList();
            MyDataGrid.ItemsSource = elemek;
            MyDataGrid.SelectedIndex = 0;
        }

        public class konyvDTO { 
        
            public int Id { get; set; }
            public string Cim { get; set; }
            public string Mufaj { get; set; }
            public string SzerzoNeve { get; set; }
            public int KiadasEv { get; set; }
        }

        private void MyDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (konyvDTO)MyDataGrid.SelectedItem;
            if (item is null) {
                return;
            }
            MyLabel.Content = $"Szerző neve: {item.SzerzoNeve}";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var kolcs = _context.Kolcsonzes.Include(k => k.Konyv).GroupBy(x => x.Konyv.Mufaj);
            List<string> sorok = new List<string>();
            foreach (var item in kolcs)
            {
                sorok.Add($"{item.Key}: {item.Count()}");
            }
            MyListBox.ItemsSource = sorok;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var all = _context.Kolcsonzes.Count(x=>x.Visszahozva == 0);
            var hun = _context.Kolcsonzes.Include(x => x.Konyv).Include(x => x.Konyv.Szerzo).Count(k => k.Visszahozva == 0 && k.Konyv.Szerzo.Nemzetiseg == "HUN");
            MessageBox.Show($"Vissza nem hozott könyvek: {all} db, ebből magyar szerzőtől: {hun} db");
        }
    }
}