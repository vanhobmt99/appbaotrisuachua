using System;
using System.Collections.Generic;

namespace CMMSBT.Domain;

public partial class Thongsobp
{
    public int Mats { get; set; }

    public string? Tents { get; set; }

    public int Mabp { get; set; }

    public DateTime? Ngaycn { get; set; }

    public virtual Bophan MabpNavigation { get; set; } = null!;
}
