// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using TennisLabel.Models;
using TennisLabel.ViewModels;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace TennisLabel
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public partial class OrderWindow : Window
    {
        public OrderWindow(Customer customer)
        {
            this.InitializeComponent();
            OrderViewModel = new OrderViewModel(customer);
        }

        public OrderViewModel OrderViewModel { get; }


        private void orderDataGrid_AutoGeneratingColumn(object sender, CommunityToolkit.WinUI.UI.Controls.DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "Startdate")
            {
                e.Column.Header = "Leadás";
            }
            if (e.Column.Header.ToString() == "Enddate")
            {
                e.Column.Header = "Felvétel";
            }
        }
    }
}
