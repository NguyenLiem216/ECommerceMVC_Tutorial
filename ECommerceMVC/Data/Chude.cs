using System;
using System.Collections.Generic;

namespace ECommerceMVC.Data;

public partial class Chude
{
    public int Macd { get; set; }

    public string? Tencd { get; set; }

    public string? Manv { get; set; }

    public virtual ICollection<Gopy> Gopies { get; set; } = new List<Gopy>();

    public virtual Nhanvien? ManvNavigation { get; set; }
}
