using System;
using System.Collections.Generic;

namespace Lab4DbAPI.Models;

public partial class Material
{
    public int MaterialId { get; set; }

    public string MaterialName { get; set; } = null!;

    public decimal Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public int SupplierId { get; set; }

    public int ProjectId { get; set; }

    public decimal? MaterialCost { get; set; }

    public virtual Project Project { get; set; } = null!;

    public virtual Supplier Supplier { get; set; } = null!;
}
