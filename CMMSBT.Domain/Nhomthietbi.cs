using System;
using System.Collections.Generic;

namespace CMMSBT.Domain;

public partial class Nhomthietbi
{
    public int Manhom { get; set; }

    public string? Tennhom { get; set; }

    public string? Ghichu { get; set; }

    public virtual ICollection<Thietbi> Thietbis { get; set; } = new List<Thietbi>();
}
