using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace rozdział_6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        internal ObservableCollection<Produkt> ListaProduktow = null;
        public MainWindow()
        {
            InitializeComponent();
            PrzygotujWiazanie();
        }

        private void PrzygotujWiazanie()
        {
            ListaProduktow = new ObservableCollection<Produkt>();
            ListaProduktow.Add(new Produkt("01-11", "Ołówek", 8, "Katowice 3"));
            ListaProduktow.Add(new Produkt("PW-20", "Pióro wieczne", 75, "Katowice 4"));
            ListaProduktow.Add(new Produkt("Dz-10", "Długopis żelowy", 1121, "Katowice 1"));
            ListaProduktow.Add(new Produkt("Dz-12", "Długopis kulkowy", 280, "Katowice 2"));
            lstProdukty.ItemsSource = ListaProduktow;
            CollectionView widok = (CollectionView)CollectionViewSource.GetDefaultView(lstProdukty.ItemsSource);
            widok.SortDescriptions.Add(new SortDescription("Magazyn", ListSortDirection.Ascending));
            widok.SortDescriptions.Add(new SortDescription("Nazwa", ListSortDirection.Ascending));
            widok.Filter = FiltrUzytkownika;
        }

        private void txtFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(lstProdukty.ItemsSource).Refresh();
        }

        private bool FiltrUzytkownika(Object item)
        {
            if (String.IsNullOrEmpty(txtFilter.Text))
            {
                return true;
            }
            else
            {
                return ((item as Produkt).Nazwa.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
            }
        }

        private void lstProdukty_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Window1 okno1 = new Window1(this);
            okno1.ShowDialog();
        }

        private void Button_Usun(object sender, RoutedEventArgs e)
        {
            Produkt produktZListy = lstProdukty.SelectedItem as Produkt;
            MessageBoxResult odpowiedz = MessageBox.Show("Czy wykasować produkt: " + produktZListy.ToString() + "?", "Pytanie", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(odpowiedz == MessageBoxResult.Yes)
            {
                ListaProduktow.Remove(produktZListy);
            }
        }

        private void Button_Dodaj(object sender, RoutedEventArgs e)
        {
            Window1 okno1 = new Window1(this, true);
            okno1.ShowDialog();
        }
    }
}
