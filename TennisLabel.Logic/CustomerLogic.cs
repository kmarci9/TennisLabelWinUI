// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisLabel.Data;
using TennisLabel.Repository;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace TennisLabel.Logic
{
    
    public class CustomerLogic : ICustomerLogic
    {
        private ICustomerRepository customerrepo;

        public CustomerLogic(ICustomerRepository custRepo)
        {
            this.customerrepo= custRepo;
        }

        public int CreateCustomer(Data.Customer customer)
        {
            return this.customerrepo.Create(customer);
        }

        public void Detach(Customer customer)
        {
            this.customerrepo.Detach(customer);
        }

        public Customer GetCustomerById(int id)
        {
            return this.customerrepo.GetOne(id);
        }

        public IQueryable<Data.Customer> GetCustomers()
        {
            return this.customerrepo.GetTable();
        }

        public void RemoveCustomer(int id)
        {
            this.customerrepo.Delete(id);
        }

        public void UpdateCustomer(Data.Customer customer)
        {
            this.customerrepo.Update(customer);
        }

    }
}
