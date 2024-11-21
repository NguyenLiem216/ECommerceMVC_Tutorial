using System;
using System.Collections.Generic;

namespace ECommerceMVC.Data;

public partial class Nhacungcap
{
    public string Mancc { get; set; } = null!;

    public string Tencongty { get; set; } = null!;

    public string Logo { get; set; } = null!;

    public string? Nguoilienlac { get; set; }

    public string Email { get; set; } = null!;

    public string? Dienthoai { get; set; }

    public string? Diachi { get; set; }

    public string? Mota { get; set; }

    public virtual ICollection<Hanghoa> Hanghoas { get; set; } = new List<Hanghoa>();
}
