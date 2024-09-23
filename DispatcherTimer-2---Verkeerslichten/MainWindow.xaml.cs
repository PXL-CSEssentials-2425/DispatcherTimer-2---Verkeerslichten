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
using System.Windows.Threading;

namespace DispatcherTimer_2___Verkeerslichten
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer TimerRed;
        DispatcherTimer TimerOrange;
        DispatcherTimer TimerGreen;
        DispatcherTimer TimerInfo;
        int TimerInfoCounter;

        public MainWindow()
        {
            InitializeComponent();

            TimerRed = new DispatcherTimer();
            TimerRed.Interval = new TimeSpan(0, 0, 2);
            TimerRed.Tick += TimerRed_Tick;

            TimerOrange = new DispatcherTimer();
            TimerOrange.Interval = new TimeSpan(0, 0, 2);
            TimerOrange.Tick += TimerOrange_Tick;

            TimerGreen = new DispatcherTimer();
            TimerGreen.Interval = new TimeSpan(0, 0, 4);
            TimerGreen.Tick += TimerGreen_Tick;

            TimerInfo = new DispatcherTimer();
            TimerInfo.Interval = new TimeSpan(0, 0, 1);
            TimerInfo.Tick += TimerInfo_Tick;
        }


        private void TimerRed_Tick(object sender, EventArgs e)
        {
            redImage.Visibility = Visibility.Hidden;
            orangeImage.Visibility = Visibility.Hidden;
            greenImage.Visibility = Visibility.Visible;
            TimerRed.Stop();
            TimerInfoCounter = TimerGreen.Interval.Seconds;
            infoLabel.Content = TimerInfoCounter;
            TimerGreen.Start();
        }

        private void TimerOrange_Tick(object sender, EventArgs e)
        {
            redImage.Visibility = Visibility.Visible;
            orangeImage.Visibility = Visibility.Hidden;
            greenImage.Visibility = Visibility.Hidden;
            TimerOrange.Stop();
            TimerInfoCounter = TimerRed.Interval.Seconds;
            infoLabel.Content = TimerInfoCounter;
            TimerRed.Start();
        }

        private void TimerGreen_Tick(object sender, EventArgs e)
        {
            redImage.Visibility = Visibility.Hidden;
            orangeImage.Visibility = Visibility.Visible;
            greenImage.Visibility = Visibility.Hidden;
            TimerGreen.Stop();
            TimerInfoCounter = TimerOrange.Interval.Seconds;
            infoLabel.Content = TimerInfoCounter;
            TimerOrange.Start();
        }

        private void TimerInfo_Tick(object sender, EventArgs e)
        {
            infoLabel.Content = --TimerInfoCounter;
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            redImage.Visibility = Visibility.Visible;
            orangeImage.Visibility = Visibility.Hidden;
            greenImage.Visibility = Visibility.Hidden;
            TimerInfoCounter = TimerRed.Interval.Seconds;
            infoLabel.Content = TimerInfoCounter;
            TimerInfo.Start();
            TimerRed.Start();
        }
    }
}
