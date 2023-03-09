using System;
using System.Collections.Generic;

namespace TennisLabel.Data;

public partial class Customer
{
    public long PkCustomerId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Phone { get; set; }

    public string City { get; set; }

    public long? PostalCode { get; set; }

    public string Country { get; set; }

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
