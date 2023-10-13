using System;
using System.Collections.Generic;

namespace CMMSBT.Domain;

public partial class Nuocsanxuat
{
    public int Mansx { get; set; }

    public string? Tennuocsx { get; set; }

    public virtual ICollection<Thietbi> Thietbis { get; set; } = new List<Thietbi>();
}
