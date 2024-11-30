using System;
using System.Collections.Generic;

namespace Lab4DbAPI.Models;

public partial class Supplier
{
    public int SupplierId { get; set; }

    public string SupplierName { get; set; } = null!;

    public string ContactNumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Address { get; set; } = null!;

    public virtual ICollection<Material> Materials { get; set; } = new List<Material>();
}
