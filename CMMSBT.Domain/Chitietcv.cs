using System;
using System.Collections.Generic;

namespace CMMSBT.Domain;

public partial class Chitietcv
{
    public int Mactcv { get; set; }

    public int Mact { get; set; }

    public string? Congviec1 { get; set; }

    public bool Congviec2 { get; set; }

    public virtual Chitietpbt MactNavigation { get; set; } = null!;
}
