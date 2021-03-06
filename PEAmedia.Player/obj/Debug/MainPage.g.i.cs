﻿#pragma checksum "C:\Users\Alex\Documents\VideoStream\PEAmedia.Player\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "97EA441D405EE0B7AF8398E0BCC47B50"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace PEAmedia.Player {
    
    
    public partial class MainPage : System.Windows.Controls.UserControl {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.MediaElement mediaPlayer;
        
        internal System.Windows.Controls.Label currentMedia;
        
        internal System.Windows.Controls.ProgressBar gestaltBar;
        
        internal System.Windows.Shapes.Rectangle mouseCaptureFrame;
        
        internal System.Windows.Controls.Canvas controlPanel;
        
        internal System.Windows.Controls.ProgressBar progBar;
        
        internal System.Windows.Controls.Button playBtn;
        
        internal System.Windows.Controls.Button volBtn;
        
        internal System.Windows.Controls.Button fullScreenBtn;
        
        internal System.Windows.Controls.Slider volSlider;
        
        internal System.Windows.Controls.Slider progSlider;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/PEAmedia.Player;component/MainPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.mediaPlayer = ((System.Windows.Controls.MediaElement)(this.FindName("mediaPlayer")));
            this.currentMedia = ((System.Windows.Controls.Label)(this.FindName("currentMedia")));
            this.gestaltBar = ((System.Windows.Controls.ProgressBar)(this.FindName("gestaltBar")));
            this.mouseCaptureFrame = ((System.Windows.Shapes.Rectangle)(this.FindName("mouseCaptureFrame")));
            this.controlPanel = ((System.Windows.Controls.Canvas)(this.FindName("controlPanel")));
            this.progBar = ((System.Windows.Controls.ProgressBar)(this.FindName("progBar")));
            this.playBtn = ((System.Windows.Controls.Button)(this.FindName("playBtn")));
            this.volBtn = ((System.Windows.Controls.Button)(this.FindName("volBtn")));
            this.fullScreenBtn = ((System.Windows.Controls.Button)(this.FindName("fullScreenBtn")));
            this.volSlider = ((System.Windows.Controls.Slider)(this.FindName("volSlider")));
            this.progSlider = ((System.Windows.Controls.Slider)(this.FindName("progSlider")));
        }
    }
}

