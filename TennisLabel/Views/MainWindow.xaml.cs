// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TennisLabel.Logic;
using TennisLabel.Models;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace TennisLabel
{
    
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            ViewModel = new MainViewModel();
        }

        public MainViewModel ViewModel { get; }

        private void CustomerListView_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            Customer c = CustomerListView.SelectedItem as Customer;
            if (c == null) return ;
            Window Customerwindow = new OrderWindow(c);
            
            Customerwindow.Activate();
        }

    }
}
