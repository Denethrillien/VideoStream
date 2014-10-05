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
    /// <summary>
    /// <c>MainPage</c> represents the Silverlight media player assembly.
    /// </summary>
    public partial class MainPage : UserControl
    {
        //Flags
        private bool isPlaying = false;

        //Media variables
        private double duration;
        private double volume;
        private String source = "";

        //Hide controls delay timer
        DispatcherTimer _timer = new DispatcherTimer();
        int counter = 0;
        int _interval_time = 2;

        /// <summary>
        /// Initializes a new instaneof the <c>MinPage</c> type.
        /// </summary>
        /// <param name="path"><c>String</c> Relative path to the media file.</param>
        /// <param name="title"><c>String</c> Media title.</param>
        public MainPage(String path, String title)
        {
            InitializeComponent();
            volSlider.Maximum = 1;
            volSlider.Value = 0.4;
            progSlider.AddHandler(MouseLeftButtonDownEvent, new MouseButtonEventHandler(progSlider_MouseLeftButtonDown), true);
            this.source = path;
            mediaPlayer.Source = new Uri(path, UriKind.Relative);
            currentMedia.Content = title;
        }

        /// <summary>
        /// Silverlight Mediaelement Media Opened handler. Sets Progress Bar and Slider maximums to media file duration in millisecs.
        /// </summary>
        /// <param name="sender">mediaPlayer</param>
        /// <param name="e">Contains state information and event data associated with a routed event.</param>
        private void mediaPlayer_MediaOpened(object sender, RoutedEventArgs e)
        {
            duration = mediaPlayer.NaturalDuration.TimeSpan.TotalMilliseconds;
            progBar.Maximum = duration;
            bottomBar.Maximum = duration;
            progSlider.Maximum = duration;
        }

        /// <summary>
        /// Volume slider value change handler. Adjusts the media volume based on the slider value.
        /// </summary>
        /// <param name="sender">volSlder</param>
        /// <param name="e">Contains state information and event data associated with a routed property chnge.</param>
        private void volSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //Change volume, remember current value for demute.
            mediaPlayer.Volume = volSlider.Value;
            if (volSlider.Value == 0)
            {
                volBtn.Content = "\uD83D\uDD07";
            }
            else if (volSlider.Value < 0.5)
            {
                volBtn.Content = "\uD83D\uDD09";
            }
            else volBtn.Content = "\uD83D\uDD0A";
        }

        /// <summary>
        /// Volume button click handler. Toggles media muting.
        /// </summary>
        /// <param name="sender">volBtn</param>
        /// <param name="e">Contains state information and event data associated with a routed event.</param>
        private void volBtn_Click(object sender, RoutedEventArgs e)
        {
            //Demute.
            if (mediaPlayer.IsMuted)
            {
                volBtn.Content = "\uD83D\uDD0A";
                mediaPlayer.IsMuted = false;
                volSlider.Value = volume;
                mediaPlayer.Volume = volume;
            }
            //Mute.
            else
            {
                volume = volSlider.Value;
                volSlider.Value = 0;
                volBtn.Content = "\uD83D\uDD07";
                mediaPlayer.IsMuted = true;

            }
        }

        /// <summary>
        /// Fullscreen button click handler. Toggles fullscreen.
        /// </summary>
        /// <param name="sender">screenBtn</param>
        /// <param name="e">Contains state information and event data associated with a routed event.</param>
        private void screenBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Host.Content.IsFullScreen = !Application.Current.Host.Content.IsFullScreen;
        }

        /// <summary>
        /// Play button click handler. Toggles Play/Pause
        /// </summary>
        /// <param name="sender">playBtn</param>
        /// <param name="e">Contains state information and event data associated with a routed event.</param>
        private void playBtn_Click(object sender, RoutedEventArgs e)
        {
            //Pause
            if (isPlaying)
            {
                mediaPlayer.Pause();
                playBtn.Content = "\u25B7";
                isPlaying = !isPlaying;
            }
            //Play
            else
            {
                mediaPlayer.Play();
                playBtn.Content = "\u2759" + "" + "\u2759";
                isPlaying = !isPlaying;
            }
        }

        /// <summary>
        /// Hides user controls. Delayed by timer. Invoked by mous exiting the controls canvas.
        /// </summary>
        /// <param name="sender">controls</param>
        /// <param name="e">Contains state information and event data associated with a mouse event.</param>
        private void hideControls(object sender, MouseEventArgs e)
        {
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += (s, t) =>
            {
                this.counter++;

                if (counter >= _interval_time)
                {
                    _timer.Stop();
                    this.counter = 0;
                    controls.Visibility = System.Windows.Visibility.Collapsed;
                    volSlider.Visibility = System.Windows.Visibility.Collapsed;
                    currentMedia.Visibility = System.Windows.Visibility.Collapsed;
                    bottomBar.Visibility = System.Windows.Visibility.Visible;
                }

            };
            _timer.Start();
        }

        /// <summary>
        /// Shows user controls. Invoked by mouse entering the placeholder <c>Rectangle</c>.
        /// </summary>
        /// <param name="sender"><c>Regtangle</c></param>
        /// <param name="e">Contains state information and event data associated with a mouse event.</param>
        private void showControls(object sender, MouseEventArgs e)
        {
            controls.Visibility = System.Windows.Visibility.Visible;
            currentMedia.Visibility = System.Windows.Visibility.Visible;
            bottomBar.Visibility = System.Windows.Visibility.Collapsed;
        }

        /// <summary>
        /// Shows volume controls. Invoked by mouse entering <c>volBtn</c>.
        /// </summary>
        /// <param name="sender">volBtn</param>
        /// <param name="e">Contains state information and event data associated with a mouse event.</param>
        private void showVol(object sender, MouseEventArgs e)
        {
            volSlider.Visibility = System.Windows.Visibility.Visible;
        }

        /// <summary>
        /// Hides volume controls. Invoked by mouse exiting <c>volBtn</c>.
        /// </summary>
        /// <param name="sender">volBtn</param>
        /// <param name="e">Contains state information and event data associated with a mouse event.</param>
        private void hideVol(object sender, MouseEventArgs e)
        {
            volSlider.Visibility = System.Windows.Visibility.Collapsed;
        }

        /// <summary>
        /// Progress slider left mouse button down handler. Sets the slider position based on mouse button click (supports dragging).
        /// </summary>
        /// <param name="sender">progSlider</param>
        /// <param name="e">Contains state information and event data associated with a mouse button event.</param>
        private void progSlider_MouseLeftButtonDown(Object sender, MouseButtonEventArgs e)
        {
            Point p = new Point();
            p = e.GetPosition(progSlider);
            double newPos = p.X * progSlider.Maximum / progSlider.Width;
            progSlider.Value = newPos;
        }

        /// <summary>
        /// Handles changes to progress bar value. Sets media position accordingly.
        /// </summary>
        /// <param name="sender">progSlider</param>
        /// <param name="e">Contains state information and event data associated with a routed property change.</param>
        private void progSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            TimeSpan t = TimeSpan.FromMilliseconds(progSlider.Value);
            mediaPlayer.Position = t;
        }
    }
}
