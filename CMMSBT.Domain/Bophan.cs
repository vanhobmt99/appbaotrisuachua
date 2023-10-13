using System;
using System.Collections.Generic;

namespace CMMSBT.Domain;

public partial class Bophan
{
    public int Mabp { get; set; }

    public string? Tenbp { get; set; }

    public int Matb { get; set; }

    public string? Congdung { get; set; }

    public string? Xuatxu { get; set; }

    public int Soluong { get; set; }

    public string? Hinhanh { get; set; }

    public string? Ghichu { get; set; }

    public DateTime? Ngaycn { get; set; }

    public virtual ICollection<Chitietthaythe> Chitietthaythes { get; set; } = new List<Chitietthaythe>();

    public virtual Thietbi MatbNavigation { get; set; } = null!;

    public virtual ICollection<Phutung> Phutungs { get; set; } = new List<Phutung>();

    public virtual ICollection<Thongsobp> Thongsobps { get; set; } = new List<Thongsobp>();
}
