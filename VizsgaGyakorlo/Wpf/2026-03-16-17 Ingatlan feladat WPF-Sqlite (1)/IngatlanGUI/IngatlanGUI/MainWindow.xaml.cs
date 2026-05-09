using System.Configuration;
using System.Data;
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
using Microsoft.Data.Sqlite;

namespace IngatlanGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string connectionString = "Filename=kozvetito.db";
        private SqliteConnection connection;
        private List<Ingatlan> dataList = [];

        public MainWindow()
        {
            InitializeComponent();
            connection = new(connectionString);
            connection.Open();
            showData();
        }

        private void showData()
        {
            dataList = [];
            string queryText = "SELECT * FROM ingatlan";
            SqliteCommand command = new(queryText, connection);
            SqliteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string kozterulet = reader.GetString(1);
                string hazszam = reader.GetString(2);
                bool lakas = reader.GetInt32(3) == 1;
                string falazat = reader.GetString(4);
                Ingatlan newData = new(id,kozterulet, hazszam, lakas, falazat);
                dataList.Add(newData);
            }
            reader.Close();
            resultTable.ItemsSource = dataList;
            List<string> falazatok = dataList.Select(x => x.Falazat).Distinct().OrderBy(x => x).ToList();
            falazatok.Add("összes");
            feladat3Box.ItemsSource = falazatok;
        }

        private void resultTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Ingatlan selected = resultTable.SelectedItem as Ingatlan;
            string queryText = $"""
                SELECT COUNT(*), SUM(hossz*szel)
                FROM ingatlan INNER JOIN helyiseg
                ON ingatlan.id=helyiseg.ingatlanId
                WHERE ingatlan.id={selected.Id}
            """;
            SqliteCommand command = new(queryText, connection);
            SqliteDataReader reader = command.ExecuteReader();
            reader.Read();
            feladat2Label.Content = $"Szobák száma: {reader.GetInt32(0)}";
            if (reader.IsDBNull(1))
                feladat4Label.Content = $"Összterület: nem értelmezhető";
            else
                feladat4Label.Content = $"Összterület: {reader.GetDouble(1):n1}";
            reader.Close();
        }

        private void feladat3Button_Click(object sender, RoutedEventArgs e)
        {
            string selected = feladat3Box.SelectedItem.ToString();
            if (selected != "összes")
            {
                var result = dataList.Where(x => x.Falazat == selected);
                resultTable.ItemsSource = result;
            }
            else
                resultTable.ItemsSource = dataList;
        }

        private void feladat5Button_Click(object sender, RoutedEventArgs e)
        {
            string queryText = """
                SELECT kozterulet
                FROM hirdetes INNER JOIN ingatlan
                ON hirdetes.ingatlanid=ingatlan.id
                WHERE allapot='eladva'
                GROUP BY kozterulet
                HAVING COUNT(*)>=2
                """;
            SqliteCommand command = new(queryText, connection);
            List<string> resultList = [];
            SqliteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                resultList.Add(reader.GetString(0));
            }
            reader.Close();
            legalabb2Lista.ItemsSource = resultList;

        }

        private void feladat6Button_Click(object sender, RoutedEventArgs e)
        {
            string queryText = """
                SELECT SUM(ar)
                FROM hirdetes
                WHERE allapot='eladva'
                """;
            SqliteCommand command = new(queryText, connection);
            SqliteDataReader reader = command.ExecuteReader();
            reader.Read();
            MessageBox.Show($"Összes bevétel: {reader.GetDouble(0) * 1000000} Ft");
            reader.Close();
        }

        private void felaat7Button_Click(object sender, RoutedEventArgs e)
        {
            string queryText = """
                SELECT kozterulet, hazszam, ar
                FROM hirdetes INNER JOIN ingatlan ON hirdetes.ingatlanid = ingatlan.id
                ORDER BY ar DESC
                LIMIT 1
                """;
            SqliteCommand command = new(queryText, connection);
            SqliteDataReader reader = command.ExecuteReader();
            reader.Read();
            MessageBox.Show($"Legdrágább ingatlan: {reader.GetString(0)} {reader.GetString(1)}, {reader.GetDouble(2) * 1000000} Ft");
            reader.Close();
        }
    }
}