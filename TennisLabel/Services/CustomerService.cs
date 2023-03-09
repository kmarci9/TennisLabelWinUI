using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisLabel.Data;
using TennisLabel.Logic;
using TennisLabel.Models;

namespace TennisLabel.Services
{
    public class CustomerService
    {
        private ICustomerLogic _logic;

        public CustomerService(ICustomerLogic custLogic)
        {
            this._logic = custLogic;
        }
        public ObservableCollection<Models.Customer> GetCustomersTable()
        {
            IQueryable<TennisLabel.Data.Customer> list2 = _logic.GetCustomers();
            ObservableCollection<Models.Customer> list = new ObservableCollection<Models.Customer>();
            foreach (TennisLabel.Data.Customer cust in list2)
            {

                list.Add(new Models.Customer
                {
                    Firstname = cust.FirstName,
                    Lastname = cust.LastName,
                    Country = cust.Country,
                    Phone = cust.Phone,
                    Zip = cust.PostalCode != null ? Convert.ToInt32(cust.PostalCode.Value) : 0,
                    City = cust.City,
                    ID = Convert.ToInt32(cust.PkCustomerId)
                }) ;
            }
            return list;
        }

        public int CreateCustomer(Models.Customer customer)
        {
            TennisLabel.Data.Customer datacust = new Data.Customer {
                FirstName = customer.Firstname,
                LastName = customer.Lastname,
                Phone = customer.Phone,
                Country = customer.Country,
                PostalCode = customer.Zip,
                City = customer.City,


            };
            return _logic.CreateCustomer(datacust);
        }

        public void UpdateCustomer(Models.Customer customer)
        {
            _logic.UpdateCustomer(MapModelCustomerToDataCustomer(customer));
        }

        private Data.Customer MapModelCustomerToDataCustomer(Models.Customer customer)
        {
            if (customer == null) { throw new NullReferenceException("customer is null"); }
            TennisLabel.Data.Customer datacust = new Data.Customer
            {
                FirstName = customer.Firstname,
                LastName = customer.Lastname,
                Phone = customer.Phone,
                Country = customer.Country,
                PostalCode = customer.Zip,
                PkCustomerId = customer.ID,
                City = customer.City
            };
            return datacust;
        }

        public Models.Customer GetOne(int id)
        {
            Models.Customer vmcustomer = new Models.Customer();
            TennisLabel.Data.Customer datacust = _logic.GetCustomerById(id);
            return MapDBCustomerToModelCustomer(datacust);
        }

        private Models.Customer MapDBCustomerToModelCustomer(Data.Customer customer)
        {
            if (customer == null) throw new NullReferenceException("customer is null");
            Models.Customer vmcustomer = new Models.Customer();
            vmcustomer.ID = Convert.ToInt32(customer.PkCustomerId);
            vmcustomer.Firstname = customer.FirstName;
            vmcustomer.Lastname = customer.LastName;
            vmcustomer.Phone = customer.Phone;
            vmcustomer.Country= customer.Country;
            vmcustomer.Zip = Convert.ToInt32(customer.PostalCode);
            return vmcustomer;

        }




    }
}
