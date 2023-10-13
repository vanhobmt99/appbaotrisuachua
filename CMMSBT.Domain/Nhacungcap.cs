using System;
using System.Collections.Generic;

namespace CMMSBT.Domain;

public partial class Nhacungcap
{
    public int Mancc { get; set; }

    public string? Tenncc { get; set; }

    public string? Diachi { get; set; }

    public string? Dienthoai { get; set; }

    public string? Ghichu { get; set; }

    public virtual ICollection<Thietbi> Thietbis { get; set; } = new List<Thietbi>();
}
