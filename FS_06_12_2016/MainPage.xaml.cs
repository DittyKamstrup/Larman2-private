﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FS_06_12_2016
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            SideMenu.IsPaneOpen = !SideMenu.IsPaneOpen;
        }


        //private void Menu_Click(object sender, RoutedEventArgs e)
        //{
        //    this.Frame.Navigate(typeof(Menu));
        //}

        private void Forside_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        //private void Person_Click(object sender, RoutedEventArgs e)
        //{
        //    this.Frame.Navigate(typeof(Personer));
        //}

        //private void MBHus_OnClick(object sender, RoutedEventArgs e)
        //{
        //    this.Frame.Navigate(typeof(Huse));
        //}

        //private void Dag_Click(object sender, RoutedEventArgs e)
        //{
        //    this.Frame.Navigate(typeof(Dag));
        //}


        private void listViewHuse_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
