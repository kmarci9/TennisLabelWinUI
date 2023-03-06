using System;
using System.Collections.Generic;

namespace TennisLabel.Data
{
    public partial class Order
    {
        public int PkOrderId { get; set; }
        public DateTime? OrderStartdate { get; set; }
        public DateTime? OrderEnddate { get; set; }
        public string Comments { get; set; }
        public int? FkCustomerId { get; set; }

        public virtual Customer FkCustomer { get; set; }
    }
}
