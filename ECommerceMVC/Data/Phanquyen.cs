using System;
using System.Collections.Generic;

namespace ECommerceMVC.Data;

public partial class Phanquyen
{
    public int Mapq { get; set; }

    public string? Mapb { get; set; }

    public int? Matrang { get; set; }

    public bool Them { get; set; }

    public bool Sua { get; set; }

    public bool Xoa { get; set; }

    public bool Xem { get; set; }

    public virtual Phongban? MapbNavigation { get; set; }

    public virtual Trangweb? MatrangNavigation { get; set; }
}
