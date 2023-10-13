using System;
using System.Collections.Generic;

namespace CMMSBT.Domain;

public partial class Khuvuc
{
    public string Makv { get; set; } = null!;

    public string? Tenkv { get; set; }

    public int? Orders { get; set; }

    public bool? Dacbiet { get; set; }

    public virtual ICollection<Nhanvien> Nhanviens { get; set; } = new List<Nhanvien>();

    public virtual ICollection<Thietbi> Thietbis { get; set; } = new List<Thietbi>();
}
