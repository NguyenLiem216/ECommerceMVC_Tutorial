using System;
using System.Collections.Generic;

namespace ECommerceMVC.Data;

public partial class Trangweb
{
    public int Matrang { get; set; }

    public string Tentrang { get; set; } = null!;

    public string Url { get; set; } = null!;

    public virtual ICollection<Phanquyen> Phanquyens { get; set; } = new List<Phanquyen>();
}
