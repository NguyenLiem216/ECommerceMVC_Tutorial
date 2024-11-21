using System;
using System.Collections.Generic;

namespace ECommerceMVC.Data;

public partial class Nhanvien
{
    public string Manv { get; set; } = null!;

    public string Hoten { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Matkhau { get; set; }

    public virtual ICollection<Chude> Chudes { get; set; } = new List<Chude>();

    public virtual ICollection<Hoadon> Hoadons { get; set; } = new List<Hoadon>();

    public virtual ICollection<Hoidap> Hoidaps { get; set; } = new List<Hoidap>();

    public virtual ICollection<Phancong> Phancongs { get; set; } = new List<Phancong>();
}
