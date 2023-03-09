using System;
using System.Collections.Generic;

namespace TennisLabel.Data;

public partial class String
{
    public long PkStringId { get; set; }

    public string StringName { get; set; }

    public string Brand { get; set; }

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
