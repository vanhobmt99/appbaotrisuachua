using System;
using System.Collections.Generic;

namespace CMMSBT.Domain;

public partial class Tailieu
{
    public int Matl { get; set; }

    public string? Tentl { get; set; }

    public int Matb { get; set; }

    public string? Noiluu { get; set; }

    public string? Ghichu { get; set; }

    public string? Filescan { get; set; }

    public DateTime? Ngaycn { get; set; }

    public virtual Thietbi MatbNavigation { get; set; } = null!;
}
