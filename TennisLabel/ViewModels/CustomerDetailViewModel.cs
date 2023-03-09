using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisLabel.Models;
using TennisLabel.Services;
using Windows.Networking;

namespace TennisLabel.ViewModels
{
    public partial class CustomerDetailViewModel
    {
        private enum Operation
        {
            Modify,
            NewEntity
        }
        private Operation operation;
        public Customer Customer { get; set; }

        private CustomerService _customerService;

        public List<string> Countries { get; set; }

        public int selectedCountryIndex { get; set; }

        private MainViewModel _mainvm;

        public CustomerDetailViewModel(MainViewModel mainvm,CustomerService customerService,Customer customer)
        {
            FillCountries();
            this._customerService = customerService;
            this._mainvm = mainvm;
            this.operation = customer == null ? Operation.NewEntity : Operation.Modify;
            Customer = customer == null ? new Customer() : customer;
            initViewModel();
        }

        private void initViewModel()
        {
            
            this.selectedCountryIndex = 51;//Hungary
            if (this.Customer.Country != null) this.selectedCountryIndex = Countries.IndexOf(this.Customer.Country);


        }

        [RelayCommand]
        private  void saveCustomer(Window window)
        {
            this.Customer.Country = Countries[selectedCountryIndex];

            if (operation == Operation.NewEntity)
            {
                int id = _customerService.CreateCustomer(this.Customer);
                this.Customer.ID = id;
                _mainvm.Customers.Add(this.Customer);


            }
            else
            {
                _customerService.UpdateCustomer(this.Customer);
                _mainvm.Customers.Remove(this.Customer);
                _mainvm.Customers.Add(this.Customer);
            }
            if (window != null)
            {
                window.Close();
            }
        }


        private void FillCountries()
        {
            this.Countries = new List<string>();
            CultureInfo[] getCultureInfo = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
            foreach (CultureInfo c in getCultureInfo)
            {
                RegionInfo getRegionInfo = new RegionInfo(c.LCID);
                if (!(Countries.Contains(getRegionInfo.EnglishName)))
                {
                    Countries.Add(getRegionInfo.EnglishName);
                }
            }
            Countries.Sort();
        }
    }
}
