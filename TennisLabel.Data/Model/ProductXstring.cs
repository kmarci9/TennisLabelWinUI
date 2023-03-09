using System;
using System.Collections.Generic;

namespace TennisLabel.Data;

public partial class ProductXstring
{
    public long? FkProductId { get; set; }

    public long? FkStringId { get; set; }

    public virtual Product FkProduct { get; set; }

    public virtual String FkString { get; set; }
}
