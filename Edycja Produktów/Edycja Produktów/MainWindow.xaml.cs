using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Edycja_Produktów
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Produkt> ListaProduktow = null;
        private string Sciezka { get { return Sciezka; }  set { value = @"C:\Users\Lucjan\source\repos\WPF Ksiazka\Edycja Produktów\Edycja Produktów\Zdjecia\"; } }
        public MainWindow()
        {
            InitializeComponent();
            PrzygotujWiazanie();
        }

        private void PrzygotujWiazanie()
        {
            ListaProduktow = new ObservableCollection<Produkt>();
            ListaProduktow.Add(new Produkt("o1-11", "Ołówek", 8,"Katowice 1", new Uri (@"C:\Users\Lucjan\source\repos\WPF Ksiazka\Edycja Produktów\Edycja Produktów\Zdjecia\Olowek.png")));
            ListaProduktow.Add(new Produkt("PW-20", "Długopis żelowy", 8,"Katowice 2" , new Uri(@"C:\Users\Lucjan\source\repos\WPF Ksiazka\Edycja Produktów\Edycja Produktów\Zdjecia\DlugopisZelowy.jfif")));
            ListaProduktow.Add(new Produkt("DZ-10", "Długopic Kulkowy", 8,"Katowice 1" , new Uri(@"C:\Users\Lucjan\source\repos\WPF Ksiazka\Edycja Produktów\Edycja Produktów\Zdjecia\dlugopisKulkowy.jfif")));
            ListaProduktow.Add(new Produkt("DZ-12", "Pióro Wieczne", 8,"Katowice 2" , new Uri(@"C:\Users\Lucjan\source\repos\WPF Ksiazka\Edycja Produktów\Edycja Produktów\Zdjecia\PioroWieczne.png")));

            gridProdukty.ItemsSource = ListaProduktow;

            ObservableCollection<string> ListaMagazynow = new ObservableCollection<string>() { "Katowice 1", "Katowice 2", "Gliwice 1", "Gliwice 5" };
            nazwaMagazynu.ItemsSource = ListaMagazynow;
        }
    }
}
