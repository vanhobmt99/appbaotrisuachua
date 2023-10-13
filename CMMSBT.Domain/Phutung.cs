using System;
using System.Collections.Generic;

namespace CMMSBT.Domain;

public partial class Phutung
{
    public int Mapt { get; set; }

    public string? Tenpt { get; set; }

    public int Mabp { get; set; }

    public string? Vitri { get; set; }

    public int Soluong { get; set; }

    public string? Ghichu { get; set; }

    public DateTime? Ngaycn { get; set; }

    public bool Isselected { get; set; }

    public virtual ICollection<Chitietthaythe> Chitietthaythes { get; set; } = new List<Chitietthaythe>();

    public virtual Bophan MabpNavigation { get; set; } = null!;

    public virtual ICollection<Thongsopt> Thongsopts { get; set; } = new List<Thongsopt>();
}
