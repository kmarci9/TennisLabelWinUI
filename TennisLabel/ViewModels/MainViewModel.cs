using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisLabel.Models;
using TennisLabel.Services;

namespace TennisLabel
{
    public partial class MainViewModel : ObservableObject
    {

        private CustomerService _customerService;

        public ObservableCollection<Customer> Customers { get; set; }

        [RelayCommand]
        private void addCustomer()
        {
            Window custdetail = new CustomerDetailWindow(this,_customerService,null);
            custdetail.Activate();


        }

        [RelayCommand]
        private void deleteCustomer()
        {

        }

        [RelayCommand]
        private void modifyCustomer(ListView CustomerListView)
        {
            if (CustomerListView != null)
            {
                Customer c = CustomerListView.SelectedItem as Customer;
                if (c == null) return;
                Window custdetail = new CustomerDetailWindow(this, _customerService, c);
                custdetail.Activate();

                
            }
            
        }

        public MainViewModel(CustomerService service)
        {
            this._customerService = service;
            Customers = new ObservableCollection<Customer>();
            
            Customers = _customerService.GetCustomersTable();
        }
    }
}
