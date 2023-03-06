using System;
using System.Collections.Generic;

namespace TennisLabel.Data
{
    public partial class ProductXstring
    {
        public int? FkProductId { get; set; }
        public int? FkStringId { get; set; }

        public virtual Product FkProduct { get; set; }
        public virtual String FkString { get; set; }
    }
}
