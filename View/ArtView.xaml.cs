﻿using System;
using System.Collections.Generic;
using System.IO;
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

namespace IVPlay.View
{
    /// <summary>
    /// Interaction logic for ArtView.xaml
    /// </summary>
    public partial class ArtView : UserControl
    {


        public string Source
        {
            get { return (string)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Source.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SourceProperty =
            DependencyProperty.Register("Source", typeof(string), typeof(ArtView), new PropertyMetadata(string.Empty, new PropertyChangedCallback(OnSourcePropertyChanged)));


        private static void OnSourcePropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            ArtView control = source as ArtView;

            if (e.NewValue.ToString() == e.OldValue.ToString()) return;
            // Put some update logic here...
            control.text.Visibility = Visibility.Hidden;
            control.image.Visibility = Visibility.Hidden;
            control.video.Visibility = Visibility.Hidden;
            control.text.IsEnabled = false;
            control.image.IsEnabled = false;
            control.video.IsEnabled = false;

            var value = e.NewValue.ToString();
            if (value.EndsWith(".png") && File.Exists(value))
            {
                control.image.IsEnabled = true;
                control.image.Visibility = Visibility.Visible;
            }
            else if (value.EndsWith(".mp4") && File.Exists(value))
            {
                control.video.IsEnabled = true;
                control.video.Visibility = Visibility.Visible;
            }
            else
            {
                control.text.IsEnabled = true;
                control.text.Visibility = Visibility.Visible;
            }
        }

        public ArtView()
        {            
            InitializeComponent();
            
        }
    }
}