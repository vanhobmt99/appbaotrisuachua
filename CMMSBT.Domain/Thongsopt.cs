using System;
using System.Collections.Generic;

namespace CMMSBT.Domain;

public partial class Thongsopt
{
    public int Mats { get; set; }

    public string? Tents { get; set; }

    public int Mapt { get; set; }

    public DateTime? Ngaycn { get; set; }

    public virtual Phutung MaptNavigation { get; set; } = null!;
}
