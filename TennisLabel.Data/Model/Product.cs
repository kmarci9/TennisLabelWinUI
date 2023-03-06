using System;
using System.Collections.Generic;

namespace TennisLabel.Data
{
    public partial class Product
    {
        public int PkProductId { get; set; }
        public string ProductName { get; set; }
        public string Brand { get; set; }
        public int? FkStringId { get; set; }

        public virtual String FkString { get; set; }
    }
}
