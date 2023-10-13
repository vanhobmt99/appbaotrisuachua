using System;
using System.Collections.Generic;

namespace CMMSBT.Domain;

public partial class Khoxuat
{
    public int Maxuat { get; set; }

    public DateTime? Ngayxuat { get; set; }

    public int Manv { get; set; }

    public int Matb { get; set; }

    public int Soluong { get; set; }

    public string? Ghichu { get; set; }

    public DateTime? Ngaycn { get; set; }

    public virtual Nhanvien ManvNavigation { get; set; } = null!;

    public virtual Thietbi MatbNavigation { get; set; } = null!;
}
