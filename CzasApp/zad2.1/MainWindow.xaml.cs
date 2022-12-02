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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace zad2._1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //btnClick.Opacity = 0.5;
            //btnClick.Visibility = Visibility.Hidden;
            btnClick.IsEnabled = false;
            MessageBox.Show("Witaj świecie"); 
            //btnClick.Opacity = 1;
            //btnClick.Visibility = Visibility.Visible;


        }

        private void MauseEnter_MouseEnter(object sender, MouseEventArgs e)
        {
            DateTime date = DateTime.Now;
            MauseEnter.Content = date.ToString("T");
        }

        private void MauseEnter_MouseLeave(object sender, MouseEventArgs e)
        {
            MauseEnter.Content = "Czas";
        }

        private void StartON_Click(object sender, RoutedEventArgs e)
        {
            btnClick.IsEnabled=true;
        }
    }
}
