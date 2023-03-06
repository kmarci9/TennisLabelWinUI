using System;
using System.Collections.Generic;

namespace TennisLabel.Data
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int PkCustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public double? City { get; set; }
        public int? PostalCode { get; set; }
        public string Country { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
