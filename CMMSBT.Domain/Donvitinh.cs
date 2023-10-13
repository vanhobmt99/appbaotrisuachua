using System;
using System.Collections.Generic;

namespace CMMSBT.Domain;

public partial class Donvitinh
{
    public int Madvt { get; set; }

    public string? Tendvt { get; set; }

    public virtual ICollection<Thietbi> Thietbis { get; set; } = new List<Thietbi>();
}
