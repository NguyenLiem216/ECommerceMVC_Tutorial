using System;
using System.Collections.Generic;

namespace ECommerceMVC.Data;

public partial class Trangthai
{
    public int Matrangthai { get; set; }

    public string Tentrangthai { get; set; } = null!;

    public string? Mota { get; set; }

    public virtual ICollection<Hoadon> Hoadons { get; set; } = new List<Hoadon>();
}
