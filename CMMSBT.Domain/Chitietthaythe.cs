using System;
using System.Collections.Generic;

namespace CMMSBT.Domain;

public partial class Chitietthaythe
{
    public int Madon { get; set; }

    public int Makh { get; set; }

    public int Matb { get; set; }

    public int Mabp { get; set; }

    public int Mapt { get; set; }

    public int Slbp { get; set; }

    public int Slpt { get; set; }

    public string? Noidung { get; set; }

    public DateTime? Ngaycn { get; set; }

    public virtual Bophan MabpNavigation { get; set; } = null!;

    public virtual Kehoachbaotri MakhNavigation { get; set; } = null!;

    public virtual Phutung MaptNavigation { get; set; } = null!;

    public virtual Thietbi MatbNavigation { get; set; } = null!;
}
