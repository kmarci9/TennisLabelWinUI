using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisLabel.Logic
{
    public interface ICustomerLogic
    {
        public void UpdateCustomer(Data.Customer customer);

        public IQueryable<Data.Customer> GetCustomers();

        public int CreateCustomer(Data.Customer customer);

        public void RemoveCustomer(int id);

        public Data.Customer GetCustomerById(int id);

        public void Detach(Data.Customer customer);
    }
}
