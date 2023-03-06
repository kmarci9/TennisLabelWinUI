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
    
    public class TennisLogic
    {
        private IRepository<Customer> customerrepo;

        public TennisLogic()
        {
            this.customerrepo = new CustomerRepository();
        }

        public void CreateCustomer(Customer customer)
        {
            this.customerrepo.Create(customer);
        }

        public List<Customer> GetCustomers()
        {
            return this.customerrepo.GetTable();
        }

        public void UpdateCustomer(Customer customer)
        {
            this.customerrepo.Update(customer);
        }

    }
}
