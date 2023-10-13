using System;
using System.Collections.Generic;

namespace CMMSBT.Domain;

public partial class Congviec
{
    public string Macv { get; set; } = null!;

    public string? Tencv { get; set; }

    public virtual ICollection<Nhanvien> Nhanviens { get; set; } = new List<Nhanvien>();
}
