using System;
using System.Collections.Generic;

namespace CMMSBT.Domain;

public partial class Thongsotb
{
    public int Mats { get; set; }

    public string? Tents { get; set; }

    public int Matb { get; set; }

    public DateTime? Ngaycn { get; set; }

    public virtual Thietbi MatbNavigation { get; set; } = null!;
}
