using System;
using System.Collections.Generic;

namespace CMMSBT.Domain;

public partial class Group
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public bool Deleted { get; set; }

    public bool Active { get; set; }

    public DateTime CreateDate { get; set; }

    public string CreateBy { get; set; } = null!;

    public DateTime UpdateDate { get; set; }

    public string UpdateBy { get; set; } = null!;

    public virtual ICollection<GroupPermission> GroupPermissions { get; set; } = new List<GroupPermission>();

    public virtual ICollection<UserAdmin> Users { get; set; } = new List<UserAdmin>();
}
