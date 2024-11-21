using System;
using System.Collections.Generic;

namespace ECommerceMVC.Data;

public partial class Phancong
{
    public int Mapc { get; set; }

    public string Manv { get; set; } = null!;

    public string Mapb { get; set; } = null!;

    public DateTime? Ngaypc { get; set; }

    public bool? Hieuluc { get; set; }

    public virtual Nhanvien ManvNavigation { get; set; } = null!;

    public virtual Phongban MapbNavigation { get; set; } = null!;
}
