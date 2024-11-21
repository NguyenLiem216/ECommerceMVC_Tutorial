using System;
using System.Collections.Generic;

namespace ECommerceMVC.Data;

public partial class Hoadon
{
    public int Mahd { get; set; }

    public string Makh { get; set; } = null!;

    public DateTime Ngaydat { get; set; }

    public DateTime? Ngaycan { get; set; }

    public DateTime? Ngaygiao { get; set; }

    public string? Hoten { get; set; }

    public string Diachi { get; set; } = null!;

    public string Cachthanhtoan { get; set; } = null!;

    public string Cachvanchuyen { get; set; } = null!;

    public double Phivanchuyen { get; set; }

    public int Matrangthai { get; set; }

    public string? Manv { get; set; }

    public string? Ghichu { get; set; }

    public virtual ICollection<Chitiethd> Chitiethds { get; set; } = new List<Chitiethd>();

    public virtual Khachhang MakhNavigation { get; set; } = null!;

    public virtual Nhanvien? ManvNavigation { get; set; }

    public virtual Trangthai MatrangthaiNavigation { get; set; } = null!;
}
