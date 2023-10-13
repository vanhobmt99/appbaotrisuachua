using System;
using System.Collections.Generic;

namespace CMMSBT.Domain;

public partial class Phieubaotri
{
    public int Mapbt { get; set; }

    public int Makh { get; set; }

    public int Matb { get; set; }

    public string? Maso { get; set; }

    public DateTime? Ngaylap { get; set; }

    public string? Noidungkhac { get; set; }

    public string? Ykien { get; set; }

    public string? Ketqua { get; set; }

    public int Manvth { get; set; }

    public int Manvkt { get; set; }

    public int Loaibaocao { get; set; }

    public virtual ICollection<Chitietpbt> Chitietpbts { get; set; } = new List<Chitietpbt>();

    public virtual Chitietkehoach Ma { get; set; } = null!;
}
