using System;
using System.Collections.Generic;

namespace TennisLabel.Data
{
    public partial class String
    {
        public String()
        {
            Products = new HashSet<Product>();
        }

        public int PkStringId { get; set; }
        public string StringName { get; set; }
        public string Brand { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
