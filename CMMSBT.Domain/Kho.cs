using System;
using System.Collections.Generic;

namespace CMMSBT.Domain;

public partial class Kho
{
    public int Makho { get; set; }

    public string? Tenkho { get; set; }

    public int Slton { get; set; }

    public string? Ghichu { get; set; }

    public DateTime? Ngaycn { get; set; }
}
