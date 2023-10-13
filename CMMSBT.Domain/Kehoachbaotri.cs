using System;
using System.Collections.Generic;

namespace CMMSBT.Domain;

public partial class Kehoachbaotri
{
    public int Makh { get; set; }

    public int Manvlap { get; set; }

    public DateTime? Ngaylap { get; set; }

    public DateTime? Tungay { get; set; }

    public DateTime? Denngay { get; set; }

    public int Manvduyet { get; set; }

    public DateTime? Ngayduyet { get; set; }

    public virtual ICollection<Chitietkehoach> Chitietkehoaches { get; set; } = new List<Chitietkehoach>();

    public virtual ICollection<Chitietthaythe> Chitietthaythes { get; set; } = new List<Chitietthaythe>();

    public virtual Nhanvien ManvduyetNavigation { get; set; } = null!;

    public virtual Nhanvien ManvlapNavigation { get; set; } = null!;
}
