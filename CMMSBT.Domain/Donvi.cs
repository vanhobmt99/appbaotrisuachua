using System;
using System.Collections.Generic;

namespace CMMSBT.Domain;

public partial class Donvi
{
    public int Madv { get; set; }

    public string? Tendonvi { get; set; }

    public string? Tengiayto { get; set; }

    public string? Diachi { get; set; }

    public string? Dienthoai { get; set; }

    public string? Fax { get; set; }

    public string? Website { get; set; }

    public string? Masothue { get; set; }

    public string? Nganhang { get; set; }

    public string? Tengiamdoc { get; set; }

    public string? Phogiamdoc { get; set; }

    public string? Phongkinhdoanh { get; set; }

    public string? Phonghoadon { get; set; }

    public string? Email { get; set; }

    public string? So { get; set; }

    public string? Phongqlmang { get; set; }

    public string? Sotaikhoan { get; set; }

    public string? Phongketoan { get; set; }

    public string? Tenbaocao { get; set; }

    public string? Vitribaocao { get; set; }

    public virtual ICollection<Nhanvien> Nhanviens { get; set; } = new List<Nhanvien>();
}
