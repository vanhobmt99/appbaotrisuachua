using System;
using System.Collections.Generic;

namespace CMMSBT.Domain;

public partial class Khonhap
{
    public int Manhap { get; set; }

    public DateTime? Ngaynhap { get; set; }

    public int Manv { get; set; }

    public int Matb { get; set; }

    public int Slnhap { get; set; }

    public int Slton { get; set; }

    public string? Ghichu { get; set; }

    public DateTime? Ngaycn { get; set; }

    public virtual Nhanvien ManvNavigation { get; set; } = null!;

    public virtual Thietbi MatbNavigation { get; set; } = null!;
}
