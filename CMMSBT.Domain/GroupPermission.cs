using System;
using System.Collections.Generic;

namespace CMMSBT.Domain;

public partial class GroupPermission
{
    public int FunctionId { get; set; }

    public int GroupId { get; set; }

    public int Mash { get; set; }

    public string? Description { get; set; }

    public bool Deleted { get; set; }

    public bool Active { get; set; }

    public DateTime CreateDate { get; set; }

    public string CreateBy { get; set; } = null!;

    public DateTime UpdateDate { get; set; }

    public string UpdateBy { get; set; } = null!;

    public virtual CrmFunction Function { get; set; } = null!;

    public virtual Group Group { get; set; } = null!;
}
