using System;
using System.Collections.Generic;

namespace ECommerceMVC.Data;

public partial class Yeuthich
{
    public int Mayt { get; set; }

    public int? Mahh { get; set; }

    public string? Makh { get; set; }

    public DateTime? Ngaychon { get; set; }

    public string? Mota { get; set; }

    public virtual Hanghoa? MahhNavigation { get; set; }

    public virtual Khachhang? MakhNavigation { get; set; }
}
