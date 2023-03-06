using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisLabel.Data;

namespace TennisLabel.Repository
{
    public class CustomerRepository : ICustomerRepository, IRepository<Customer>
    {
        private static TennisDBEntities database = new TennisDBEntities();


        public void ChangeFirstname(Customer tobechanged, string firstname)
        {
            tobechanged.FirstName = firstname;
            database.SaveChanges();
        }

        public void ChangeLastname(Customer tobechanged, string lastname)
        {
            tobechanged.LastName = lastname;
            database.SaveChanges();
        }

        public void Create(Customer item)
        {
            database.Set<Customer>().Add(item);
            database.SaveChanges();
        }

        public void Delete(Customer customer)
        {

            database.Customers.Remove(customer);
            database.SaveChanges();
        }

        public Customer GetOne(int id)
        {
            return database.Customers.SingleOrDefault(x => x.PkCustomerId== id);
        }

        public List<Customer> GetTable()
        {
            return database.Customers.ToList();
        }


        public void Update(Customer entity)
        {
            database.Customers.Update(entity);
            database.SaveChanges();
        }
    }
}
