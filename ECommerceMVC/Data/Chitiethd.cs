using System;
using System.Collections.Generic;

namespace ECommerceMVC.Data;

public partial class Chitiethd
{
    public int Mact { get; set; }

    public int Mahd { get; set; }

    public int Mahh { get; set; }

    public double Dongia { get; set; }

    public int Soluong { get; set; }

    public double Giamgia { get; set; }

    public virtual Hoadon MahdNavigation { get; set; } = null!;

    public virtual Hanghoa MahhNavigation { get; set; } = null!;
}
