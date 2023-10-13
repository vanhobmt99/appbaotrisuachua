using System;
using System.Collections.Generic;

namespace CMMSBT.Domain;

public partial class Hangsanxuat
{
    public int Mahsx { get; set; }

    public string? TenHangsx { get; set; }

    public virtual ICollection<Thietbi> Thietbis { get; set; } = new List<Thietbi>();
}
