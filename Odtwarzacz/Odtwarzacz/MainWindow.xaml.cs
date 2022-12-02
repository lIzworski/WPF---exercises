using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Odtwarzacz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MediaPlayer mediaPlayer =  new MediaPlayer();
        private DispatcherTimer timer;
        private bool czySuwakJestPrzesuwany = false;
        public MainWindow()
        {
            InitializeComponent();

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += new EventHandler(timerTick);
        }

        void timerTick(object sender, EventArgs e)
        {
            if(mediaPlayer.Source != null && mediaPlayer.NaturalDuration.HasTimeSpan && !czySuwakJestPrzesuwany)
            {
                txtCzas.Text = mediaPlayer.Position.ToString(@"mm\:ss");
                TimeSpan ts = mediaPlayer.NaturalDuration.TimeSpan;
                pgGra.Maximum = 100;
                pgGra.Value = ((double)mediaPlayer.Position.TotalMilliseconds / ts.TotalMilliseconds) * 100;

                slGra.Maximum = mediaPlayer.NaturalDuration.TimeSpan.TotalMilliseconds;
                slGra.Value = mediaPlayer.Position.TotalMilliseconds;
            }
        }
        private void btnWybierz_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "MP3 files (*.mp3)|*.mp3|All filles (*.*)|*.*";
            if(dialog.ShowDialog() == true)
            {
                mediaPlayer.Open(new Uri(dialog.FileName));
                txtUtwor.Text = String.Format($"Utwór: {dialog.FileName}");
                btnPlay.IsEnabled = true;
                btnPause.IsEnabled = true;
                btnStop.IsEnabled = true;
                timer.Start();
            }
        }
        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Play();
        }
        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Pause();
        }
        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Stop();
        }
        private void radio_Checked(object sender, RoutedEventArgs e)
        {
            var radio = sender as RadioButton;
            string kolor = (radio.Content.ToString() == "Niebieski") ? "LightSkyBlue" : "LightGreen"; 
            pgGra.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromInvariantString(kolor);
        }
        private void slGra_DragStarted(object sender, DragStartedEventArgs e)
        {
            czySuwakJestPrzesuwany = true;
        }
        private void slGra_DragCompleted(object sender, DragCompletedEventArgs e)
        {
            czySuwakJestPrzesuwany = false;
            mediaPlayer.Position = TimeSpan.FromMilliseconds(slGra.Value);
        }
    }

}
