using System;
using System.Collections.Generic;

namespace CMMSBT.Domain;

public partial class Chitietpbt
{
    public int Mact { get; set; }

    public int Mapbt { get; set; }

    public bool Congviec { get; set; }

    public virtual ICollection<Chitietcv> Chitietcvs { get; set; } = new List<Chitietcv>();

    public virtual Phieubaotri MapbtNavigation { get; set; } = null!;
}
