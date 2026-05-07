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
using TourGui.Models;

namespace TourGui
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
            LoadData();
           
        }
        private void LoadData()
        {
            var tours = _context.Versenyzos.Include(x=>x.Csapat).Select(x=> new VersenyzoDTO{ Id = x.Id,Nev =  x.Nev,CsapatNev= x.Csapat.CsapatNev,Nemzetiseg = x.Nemzetiseg}).ToList();
            MyDataGrid.ItemsSource = tours;
        }

        private void MyDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (MyDataGrid.SelectedItem == null) return;

                var selected = (VersenyzoDTO)MyDataGrid.SelectedItem;
                var versenyzo = _context.Versenyzos.Include(x => x.Eredmenies).FirstOrDefault(x => x.Id == selected.Id);
                var eredmeny = versenyzo.Eredmenies.FirstOrDefault(x => x.Szakasz == 5);
                if (eredmeny is null) { 
                FirstLabel.Content = "5. Szakasz eredménye: Nincs az 5. szakaszban";

                }
                else
                {

                FirstLabel.Content = "5. Szakasz eredménye: " + eredmeny.Ido;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

           

        }
        public class VersenyzoDTO { 
            public int Id { get; set; }
            public string Nev { get; set; }
            public string CsapatNev { get; set; }
            public string Nemzetiseg { get; set; }
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            var csapatok = _context.Versenyzos.Include(x=>x.Csapat).GroupBy(x=>x.Csapat.CsapatNev).Select(g => $"{g.Key} : {g.Count()} Fő").ToList();

            MyListBox.ItemsSource = csapatok;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var hun = _context.Versenyzos.Count(v => v.Nemzetiseg == "HUN");
            MessageBox.Show($"Magyar versenyzők száma: {hun}");
        }
    }
}