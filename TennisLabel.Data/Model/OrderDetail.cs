using System;
using System.Collections.Generic;

namespace TennisLabel.Data
{
    public partial class OrderDetail
    {
        public int? FkOrderId { get; set; }
        public int? FkProductId { get; set; }
        public int? UnitPrice { get; set; }
        public int? Quantity { get; set; }

        public virtual Order FkOrder { get; set; }
        public virtual Product FkProduct { get; set; }
    }
}
