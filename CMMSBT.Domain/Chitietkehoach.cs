using System;
using System.Collections.Generic;

namespace CMMSBT.Domain;

public partial class Chitietkehoach
{
    public int Makh { get; set; }

    public int Matb { get; set; }

    public int Trangthai { get; set; }

    public DateTime? Ngayyeucau { get; set; }

    public int Loaibaotri { get; set; }

    public int Thang { get; set; }

    public virtual Kehoachbaotri MakhNavigation { get; set; } = null!;

    public virtual Thietbi MatbNavigation { get; set; } = null!;

    public virtual ICollection<Phieubaotri> Phieubaotris { get; set; } = new List<Phieubaotri>();
}
