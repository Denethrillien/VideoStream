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

namespace MediaPlayer
{
    public partial class MainPage : UserControl
    {
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
        private void Controls_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        //Showcontrols
        private void Rectangle_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void showVol(object sender, MouseEventArgs e)
        {

        }

        private void hideVol(object sender, MouseEventArgs e)
        {

        }
    }
}
