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
        DispatcherTimer _timerRed;
        DispatcherTimer _timerOrange;
        DispatcherTimer _timerGreen;
        DispatcherTimer _timerInfo;
        int _timerInfoCounter;

        public MainWindow()
        {
            InitializeComponent();

            _timerRed = new DispatcherTimer();
            _timerRed.Interval = new TimeSpan(0, 0, 2);
            _timerRed.Tick += TimerRed_Tick;

            _timerOrange = new DispatcherTimer();
            _timerOrange.Interval = new TimeSpan(0, 0, 2);
            _timerOrange.Tick += TimerOrange_Tick;

            _timerGreen = new DispatcherTimer();
            _timerGreen.Interval = new TimeSpan(0, 0, 4);
            _timerGreen.Tick += TimerGreen_Tick;

            _timerInfo = new DispatcherTimer();
            _timerInfo.Interval = new TimeSpan(0, 0, 1);
            _timerInfo.Tick += TimerInfo_Tick;
        }


        private void TimerRed_Tick(object sender, EventArgs e)
        {
            redImage.Visibility = Visibility.Hidden;
            orangeImage.Visibility = Visibility.Hidden;
            greenImage.Visibility = Visibility.Visible;
            _timerRed.Stop();
            _timerInfoCounter = _timerGreen.Interval.Seconds;
            infoLabel.Content = _timerInfoCounter;
            _timerGreen.Start();
        }

        private void TimerOrange_Tick(object sender, EventArgs e)
        {
            redImage.Visibility = Visibility.Visible;
            orangeImage.Visibility = Visibility.Hidden;
            greenImage.Visibility = Visibility.Hidden;
            _timerOrange.Stop();
            _timerInfoCounter = _timerRed.Interval.Seconds;
            infoLabel.Content = _timerInfoCounter;
            _timerRed.Start();
        }

        private void TimerGreen_Tick(object sender, EventArgs e)
        {
            redImage.Visibility = Visibility.Hidden;
            orangeImage.Visibility = Visibility.Visible;
            greenImage.Visibility = Visibility.Hidden;
            _timerGreen.Stop();
            _timerInfoCounter = _timerOrange.Interval.Seconds;
            infoLabel.Content = _timerInfoCounter;
            _timerOrange.Start();
        }

        private void TimerInfo_Tick(object sender, EventArgs e)
        {
            infoLabel.Content = --_timerInfoCounter;
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            redImage.Visibility = Visibility.Visible;
            orangeImage.Visibility = Visibility.Hidden;
            greenImage.Visibility = Visibility.Hidden;
            _timerInfoCounter = _timerRed.Interval.Seconds;
            infoLabel.Content = _timerInfoCounter;
            _timerInfo.Start();
            _timerRed.Start();
        }
    }
}
