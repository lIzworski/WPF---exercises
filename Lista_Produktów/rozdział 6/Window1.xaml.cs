using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using System.ComponentModel;

namespace rozdział_6
{
    /// <summary>
    /// Logika interakcji dla klasy Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private bool czyNowyProdukt = true;
        private Produkt nowyProdukt; 
        private MainWindow mainWindow = null;
        public Window1()
        {
            InitializeComponent();
        }

        public Window1(MainWindow mainWin, bool czyNowe = false )
        {
            InitializeComponent();
            mainWindow = mainWin;
            czyNowyProdukt = czyNowe;
            PrzygotujWiazanie();
           
        }
        private void PrzygotujWiazanie()
        {
            if(czyNowyProdukt == false)
            {
                Produkt produktZListy = mainWindow.lstProdukty.SelectedItem as Produkt;
                if(produktZListy != null)
                {
                    gridProdukt.DataContext = produktZListy;
                }
            }
            else
            {
                nowyProdukt = new Produkt("AA-00", "", 0, "");
                gridProdukt.DataContext = nowyProdukt ;
            }
        }

        private void btnPotwierdz_Click(object sender, RoutedEventArgs e)
        {
            if(czyNowyProdukt == false)
            {
                this.Close();
            }
            else if(czyNowyProdukt == true)
            {
                mainWindow.ListaProduktow.Add(nowyProdukt);
                this.Close();
            }
            
        }
    }
}
