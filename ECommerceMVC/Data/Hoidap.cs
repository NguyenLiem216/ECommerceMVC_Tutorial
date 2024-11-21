using System;
using System.Collections.Generic;

namespace ECommerceMVC.Data;

public partial class Hoidap
{
    public int Mahd { get; set; }

    public string Cauhoi { get; set; } = null!;

    public string Traloi { get; set; } = null!;

    public DateOnly Ngaydua { get; set; }

    public string Manv { get; set; } = null!;

    public virtual Nhanvien ManvNavigation { get; set; } = null!;
}
