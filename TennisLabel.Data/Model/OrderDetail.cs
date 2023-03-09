using System;
using System.Collections.Generic;

namespace TennisLabel.Data;

public partial class OrderDetail
{
    public long? FkOrderId { get; set; }

    public long? FkProductId { get; set; }

    public long? UnitPrice { get; set; }

    public long? Quantity { get; set; }

    public virtual Order FkOrder { get; set; }

    public virtual Product FkProduct { get; set; }
}
