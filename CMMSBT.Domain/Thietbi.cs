using System;
using System.Collections.Generic;

namespace CMMSBT.Domain;

public partial class Thietbi
{
    public int Matb { get; set; }

    public string? Tentb { get; set; }

    public string? Serial { get; set; }

    public string? Model { get; set; }

    public int Manhom { get; set; }

    public int Manv { get; set; }

    public int Madvt { get; set; }

    public string? Makv { get; set; }

    public int Mancc { get; set; }

    public DateTime? Ngaylap { get; set; }

    public string? Noilap { get; set; }

    public DateTime? Ngaysudung { get; set; }

    public int Mansx { get; set; }

    public int Mahsx { get; set; }

    public DateTime? Ngayhetbh { get; set; }

    public string? Ghichu { get; set; }

    public decimal? Chuky { get; set; }

    public string? Hinhanh { get; set; }

    public string? Congdung { get; set; }

    public virtual ICollection<Bophan> Bophans { get; set; } = new List<Bophan>();

    public virtual ICollection<Chitietkehoach> Chitietkehoaches { get; set; } = new List<Chitietkehoach>();

    public virtual ICollection<Chitietthaythe> Chitietthaythes { get; set; } = new List<Chitietthaythe>();

    public virtual ICollection<Khonhap> Khonhaps { get; set; } = new List<Khonhap>();

    public virtual ICollection<Khoxuat> Khoxuats { get; set; } = new List<Khoxuat>();

    public virtual Donvitinh MadvtNavigation { get; set; } = null!;

    public virtual Hangsanxuat MahsxNavigation { get; set; } = null!;

    public virtual Khuvuc? MakvNavigation { get; set; }

    public virtual Nhacungcap ManccNavigation { get; set; } = null!;

    public virtual Nhomthietbi ManhomNavigation { get; set; } = null!;

    public virtual Nuocsanxuat MansxNavigation { get; set; } = null!;

    public virtual Nhanvien ManvNavigation { get; set; } = null!;

    public virtual ICollection<Tailieu> Tailieus { get; set; } = new List<Tailieu>();

    public virtual ICollection<Thongsotb> Thongsotbs { get; set; } = new List<Thongsotb>();
}
