using System;
using System.Collections.Generic;

namespace ECommerceMVC.Data;

public partial class Hanghoa
{
    public int Mahh { get; set; }

    public string Tenhh { get; set; } = null!;

    public string? Tenalias { get; set; }

    public int Maloai { get; set; }

    public string? Motadonvi { get; set; }

    public double? Dongia { get; set; }

    public string? Hinh { get; set; }

    public DateTime Ngaysx { get; set; }

    public double Giamgia { get; set; }

    public int Solanxem { get; set; }

    public string? Mota { get; set; }

    public string Mancc { get; set; } = null!;

    public virtual ICollection<Banbe> Banbes { get; set; } = new List<Banbe>();

    public virtual ICollection<Chitiethd> Chitiethds { get; set; } = new List<Chitiethd>();

    public virtual Loai MaloaiNavigation { get; set; } = null!;

    public virtual Nhacungcap ManccNavigation { get; set; } = null!;

    public virtual ICollection<Yeuthich> Yeuthiches { get; set; } = new List<Yeuthich>();
}
