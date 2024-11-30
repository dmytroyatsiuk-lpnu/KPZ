using System;
using System.Collections.Generic;

namespace Lab4DbAPI.Models;

public partial class Project
{
    public int ProjectId { get; set; }

    public string ProjectName { get; set; } = null!;

    public DateOnly StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public decimal Budget { get; set; }

    public string Address { get; set; } = null!;

    public string ProjectStatus { get; set; } = null!;

    public virtual ICollection<Material> Materials { get; set; } = new List<Material>();
}
