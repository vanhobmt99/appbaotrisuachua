using System;
using System.Collections.Generic;

namespace CMMSBT.Domain;

public partial class Phongban
{
    public string Mapb { get; set; } = null!;

    public string? Tenpb { get; set; }

    public string? Tructhuoc { get; set; }

    public string? Mota { get; set; }

    public int? Orders { get; set; }

    public string? Diachi { get; set; }

    public string? Sdt { get; set; }

    public virtual ICollection<Nhanvien> Nhanviens { get; set; } = new List<Nhanvien>();
}
