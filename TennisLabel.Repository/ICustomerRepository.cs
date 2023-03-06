using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisLabel.Data;

namespace TennisLabel.Repository
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        void ChangeFirstname(Customer tobechanged,string firstname);

        void ChangeLastname(Customer tobechanged,string lastname);




    }
}
