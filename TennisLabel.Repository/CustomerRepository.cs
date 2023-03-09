using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisLabel.Data;

namespace TennisLabel.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {

        public CustomerRepository(TennisDbContext database) : base(database) { }



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

        public override int Create(Customer item)
        {
            database.Set<Customer>().Add(item);
            database.SaveChanges();
            int id = Convert.ToInt32(item.PkCustomerId);
            return id;
        }

        public override Customer GetOne(int id)
        {
            return database.Customers.SingleOrDefault(x => x.PkCustomerId == id);
        }


        public override void Update(Customer entity)
        {
            Customer c = GetOne(Convert.ToInt32(entity.PkCustomerId));
            c.FirstName = entity.FirstName;
            c.LastName = entity.LastName;
            c.Phone = entity.Phone;
            c.City = entity.City;
            c.PostalCode = entity.PostalCode;
            c.Country = entity.Country;
            database.SaveChanges();
        }

    }
}
