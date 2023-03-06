using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisLabel.Logic;
using TennisLabel.Models;

namespace TennisLabel.Services
{
    public class CustomerService
    {
        private TennisLogic _logic;

        public CustomerService()
        {
            this._logic = new TennisLogic();
        }
        public ObservableCollection<Customer> GetCustomersTable()
        {
            List<TennisLabel.Data.Customer> list2 = _logic.GetCustomers();
            ObservableCollection<Customer> list = new ObservableCollection<Customer>();
            foreach (TennisLabel.Data.Customer cust in list2)
            {

                list.Add(new Customer
                {
                    Firstname = cust.FirstName,
                    Lastname = cust.LastName,
                    ID = cust.PkCustomerId
                });
            }
            return list;
        }

        public void CreateCustomer(Customer customer)
        {
            TennisLabel.Data.Customer datacust = new Data.Customer {
                FirstName = customer.Firstname,
                LastName = customer.Lastname,
                Phone = customer.Phone,
                Country = customer.Country,
                PostalCode = customer.Zip,


            };
            _logic.CreateCustomer(datacust);
        }

        public void UpdateCustomer(Customer customer)
        {
            TennisLabel.Data.Customer datacust = new Data.Customer
            {
                FirstName = customer.Firstname,
                LastName = customer.Lastname,
                Phone = customer.Phone,
                Country = customer.Country,
                PostalCode = customer.Zip,
                PkCustomerId = customer.ID


            };
            _logic.UpdateCustomer(datacust);
        }




    }
}
