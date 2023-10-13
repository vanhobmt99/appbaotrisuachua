using System;
using System.Collections.Generic;

namespace CMMSBT.Domain;

public partial class UserAdmin
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public bool Deleted { get; set; }

    public bool Active { get; set; }

    public DateTime CreateDate { get; set; }

    public string CreateBy { get; set; } = null!;

    public DateTime UpdateDate { get; set; }

    public string UpdateBy { get; set; } = null!;

    public string? Password { get; set; }

    public string? HoTen { get; set; }

    public int Manv { get; set; }

    public virtual ICollection<Group> Groups { get; set; } = new List<Group>();
}
