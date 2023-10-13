using System;
using System.Collections.Generic;

namespace CMMSBT.Domain;

public partial class CrmFunction
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string Url { get; set; } = null!;

    public int Parent { get; set; }

    public bool Deleted { get; set; }

    public int? Order { get; set; }

    public virtual ICollection<GroupPermission> GroupPermissions { get; set; } = new List<GroupPermission>();
}
