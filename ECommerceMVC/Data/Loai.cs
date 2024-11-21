using System;
using System.Collections.Generic;

namespace ECommerceMVC.Data;

public partial class Loai
{
    public int Maloai { get; set; }

    public string Tenloai { get; set; } = null!;

    public string? Tenloaialias { get; set; }

    public string? Mota { get; set; }

    public string? Hinh { get; set; }

    public virtual ICollection<Hanghoa> Hanghoas { get; set; } = new List<Hanghoa>();
}
