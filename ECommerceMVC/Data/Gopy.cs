using System;
using System.Collections.Generic;

namespace ECommerceMVC.Data;

public partial class Gopy
{
    public string Magy { get; set; } = null!;

    public int Macd { get; set; }

    public string Noidung { get; set; } = null!;

    public DateOnly Ngaygy { get; set; }

    public string? Hoten { get; set; }

    public string? Email { get; set; }

    public string? Dienthoai { get; set; }

    public bool Cantraloi { get; set; }

    public string? Traloi { get; set; }

    public DateOnly? Ngaytl { get; set; }

    public virtual Chude MacdNavigation { get; set; } = null!;
}
