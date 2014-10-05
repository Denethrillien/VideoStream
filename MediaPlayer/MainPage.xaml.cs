using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace MediaPlayer
{
    public partial class MainPage : UserControl
    {
        DispatcherTimer _timer = new DispatcherTimer();
        int counter = 0;
        int _interval_time = 2;              

        public MainPage()
        {
            InitializeComponent();
            currentMedia.Content = "Dummy Title";
        }

        private void MediaElement_MediaOpened(object sender, RoutedEventArgs e)
        {
        }

        private void volSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void progSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void ScreenBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void VolBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PlayBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        //Hidecontrols
        private void hideControls(object sender, MouseEventArgs e)
        {
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += (s, t) =>
            {
                counter++;

                if (counter >= _interval_time)
                {
                    _timer.Stop();

                    controls.Visibility = System.Windows.Visibility.Collapsed;
                    volSlider.Visibility = System.Windows.Visibility.Collapsed;
                    currentMedia.Visibility = System.Windows.Visibility.Collapsed;
                    bottomBar.Visibility = System.Windows.Visibility.Visible;
                }

            };
            _timer.Start();
        }

        //Showcontrols
        private void showControls(object sender, MouseEventArgs e)
        {
            controls.Visibility = System.Windows.Visibility.Visible;
            currentMedia.Visibility = System.Windows.Visibility.Visible;
            bottomBar.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void showVol(object sender, MouseEventArgs e)
        {
            volSlider.Visibility = System.Windows.Visibility.Visible;
        }

        private void hideVol(object sender, MouseEventArgs e)
        {
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += (s, t) =>
            {
                counter++;

                if (counter >= _interval_time)
                {
                    _timer.Stop();

                    volSlider.Visibility = System.Windows.Visibility.Collapsed;
                }

            };
            _timer.Start();
        }

    }
}
