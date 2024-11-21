using System;
using System.Collections.Generic;

namespace ECommerceMVC.Data;

public partial class Banbe
{
    public int Mabb { get; set; }

    public string? Makh { get; set; }

    public int Mahh { get; set; }

    public string? Hoten { get; set; }

    public string Email { get; set; } = null!;

    public DateTime Ngaygui { get; set; }

    public string? Ghichu { get; set; }

    public virtual Hanghoa MahhNavigation { get; set; } = null!;

    public virtual Khachhang? MakhNavigation { get; set; }
}
