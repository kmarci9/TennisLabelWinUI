using System;
using System.Collections.Generic;

namespace TennisLabel.Data;

public partial class Order
{
    public long PkOrderId { get; set; }

    public string DtOrderStartdate { get; set; }

    public string DtOrderEnddate { get; set; }

    public string Comments { get; set; }

    public long? FkCustomerId { get; set; }

    public virtual Customer FkCustomer { get; set; }
}
