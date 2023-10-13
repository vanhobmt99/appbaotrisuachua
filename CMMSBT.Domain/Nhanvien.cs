using System;
using System.Collections.Generic;

namespace CMMSBT.Domain;

public partial class Nhanvien
{
    public int Manv { get; set; }

    public string? Mapb { get; set; }

    public string? Makv { get; set; }

    public string? Macv { get; set; }

    public string? Hoten { get; set; }

    public DateTime? Ngaysinh { get; set; }

    public string? Diachi { get; set; }

    public string? Sdt { get; set; }

    public string? Chuky { get; set; }

    public int Madonvi { get; set; }

    public bool? Trangthai { get; set; }

    public virtual ICollection<Kehoachbaotri> KehoachbaotriManvduyetNavigations { get; set; } = new List<Kehoachbaotri>();

    public virtual ICollection<Kehoachbaotri> KehoachbaotriManvlapNavigations { get; set; } = new List<Kehoachbaotri>();

    public virtual ICollection<Khonhap> Khonhaps { get; set; } = new List<Khonhap>();

    public virtual ICollection<Khoxuat> Khoxuats { get; set; } = new List<Khoxuat>();

    public virtual Congviec? MacvNavigation { get; set; }

    public virtual Donvi MadonviNavigation { get; set; } = null!;

    public virtual Khuvuc? MakvNavigation { get; set; }

    public virtual Phongban? MapbNavigation { get; set; }

    public virtual ICollection<Thietbi> Thietbis { get; set; } = new List<Thietbi>();
}
