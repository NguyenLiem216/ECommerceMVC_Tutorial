using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ECommerceMVC.Data;

public partial class ECommerceTutContext : DbContext
{
    public ECommerceTutContext()
    {
    }

    public ECommerceTutContext(DbContextOptions<ECommerceTutContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Banbe> Banbes { get; set; }

    public virtual DbSet<Chitiethd> Chitiethds { get; set; }

    public virtual DbSet<Chude> Chudes { get; set; }

    public virtual DbSet<Gopy> Gopies { get; set; }

    public virtual DbSet<Hanghoa> Hanghoas { get; set; }

    public virtual DbSet<Hoadon> Hoadons { get; set; }

    public virtual DbSet<Hoidap> Hoidaps { get; set; }

    public virtual DbSet<Khachhang> Khachhangs { get; set; }

    public virtual DbSet<Loai> Loais { get; set; }

    public virtual DbSet<Nhacungcap> Nhacungcaps { get; set; }

    public virtual DbSet<Nhanvien> Nhanviens { get; set; }

    public virtual DbSet<Phancong> Phancongs { get; set; }

    public virtual DbSet<Phanquyen> Phanquyens { get; set; }

    public virtual DbSet<Phongban> Phongbans { get; set; }

    public virtual DbSet<Trangthai> Trangthais { get; set; }

    public virtual DbSet<Trangweb> Trangwebs { get; set; }

    public virtual DbSet<Yeuthich> Yeuthiches { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=E-Commerce_TUT;Username=admin;Password=123456");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Banbe>(entity =>
        {
            entity.HasKey(e => e.Mabb).HasName("banbe_pkey");

            entity.ToTable("banbe");

            entity.Property(e => e.Mabb).HasColumnName("mabb");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Ghichu).HasColumnName("ghichu");
            entity.Property(e => e.Hoten)
                .HasMaxLength(50)
                .HasColumnName("hoten");
            entity.Property(e => e.Mahh).HasColumnName("mahh");
            entity.Property(e => e.Makh)
                .HasMaxLength(20)
                .HasColumnName("makh");
            entity.Property(e => e.Ngaygui)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("ngaygui");

            entity.HasOne(d => d.MahhNavigation).WithMany(p => p.Banbes)
                .HasForeignKey(d => d.Mahh)
                .HasConstraintName("fk_banbe_hanghoa");

            entity.HasOne(d => d.MakhNavigation).WithMany(p => p.Banbes)
                .HasForeignKey(d => d.Makh)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_banbe_khachhang");
        });

        modelBuilder.Entity<Chitiethd>(entity =>
        {
            entity.HasKey(e => e.Mact).HasName("chitiethd_pkey");

            entity.ToTable("chitiethd");

            entity.Property(e => e.Mact).HasColumnName("mact");
            entity.Property(e => e.Dongia).HasColumnName("dongia");
            entity.Property(e => e.Giamgia).HasColumnName("giamgia");
            entity.Property(e => e.Mahd).HasColumnName("mahd");
            entity.Property(e => e.Mahh).HasColumnName("mahh");
            entity.Property(e => e.Soluong)
                .HasDefaultValue(1)
                .HasColumnName("soluong");

            entity.HasOne(d => d.MahdNavigation).WithMany(p => p.Chitiethds)
                .HasForeignKey(d => d.Mahd)
                .HasConstraintName("fk_chitiethd_hoadon");

            entity.HasOne(d => d.MahhNavigation).WithMany(p => p.Chitiethds)
                .HasForeignKey(d => d.Mahh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_chitiethd_hanghoa");
        });

        modelBuilder.Entity<Chude>(entity =>
        {
            entity.HasKey(e => e.Macd).HasName("chude_pkey");

            entity.ToTable("chude");

            entity.Property(e => e.Macd).HasColumnName("macd");
            entity.Property(e => e.Manv)
                .HasMaxLength(50)
                .HasColumnName("manv");
            entity.Property(e => e.Tencd)
                .HasMaxLength(50)
                .HasColumnName("tencd");

            entity.HasOne(d => d.ManvNavigation).WithMany(p => p.Chudes)
                .HasForeignKey(d => d.Manv)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_chude_nhanvien");
        });

        modelBuilder.Entity<Gopy>(entity =>
        {
            entity.HasKey(e => e.Magy).HasName("gopy_pkey");

            entity.ToTable("gopy");

            entity.Property(e => e.Magy)
                .HasMaxLength(50)
                .HasColumnName("magy");
            entity.Property(e => e.Cantraloi)
                .HasDefaultValue(false)
                .HasColumnName("cantraloi");
            entity.Property(e => e.Dienthoai)
                .HasMaxLength(50)
                .HasColumnName("dienthoai");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Hoten)
                .HasMaxLength(50)
                .HasColumnName("hoten");
            entity.Property(e => e.Macd).HasColumnName("macd");
            entity.Property(e => e.Ngaygy)
                .HasDefaultValueSql("CURRENT_DATE")
                .HasColumnName("ngaygy");
            entity.Property(e => e.Ngaytl).HasColumnName("ngaytl");
            entity.Property(e => e.Noidung).HasColumnName("noidung");
            entity.Property(e => e.Traloi)
                .HasMaxLength(50)
                .HasColumnName("traloi");

            entity.HasOne(d => d.MacdNavigation).WithMany(p => p.Gopies)
                .HasForeignKey(d => d.Macd)
                .HasConstraintName("fk_gopy_chude");
        });

        modelBuilder.Entity<Hanghoa>(entity =>
        {
            entity.HasKey(e => e.Mahh).HasName("hanghoa_pkey");

            entity.ToTable("hanghoa");

            entity.Property(e => e.Mahh).HasColumnName("mahh");
            entity.Property(e => e.Dongia)
                .HasDefaultValueSql("0")
                .HasColumnName("dongia");
            entity.Property(e => e.Giamgia).HasColumnName("giamgia");
            entity.Property(e => e.Hinh)
                .HasMaxLength(50)
                .HasColumnName("hinh");
            entity.Property(e => e.Maloai).HasColumnName("maloai");
            entity.Property(e => e.Mancc)
                .HasMaxLength(50)
                .HasColumnName("mancc");
            entity.Property(e => e.Mota).HasColumnName("mota");
            entity.Property(e => e.Motadonvi)
                .HasMaxLength(50)
                .HasColumnName("motadonvi");
            entity.Property(e => e.Ngaysx)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("ngaysx");
            entity.Property(e => e.Solanxem)
                .HasDefaultValue(0)
                .HasColumnName("solanxem");
            entity.Property(e => e.Tenalias)
                .HasMaxLength(50)
                .HasColumnName("tenalias");
            entity.Property(e => e.Tenhh)
                .HasMaxLength(50)
                .HasColumnName("tenhh");

            entity.HasOne(d => d.MaloaiNavigation).WithMany(p => p.Hanghoas)
                .HasForeignKey(d => d.Maloai)
                .HasConstraintName("fk_hanghoa_loai");

            entity.HasOne(d => d.ManccNavigation).WithMany(p => p.Hanghoas)
                .HasForeignKey(d => d.Mancc)
                .HasConstraintName("fk_hanghoa_nhacungcap");
        });

        modelBuilder.Entity<Hoadon>(entity =>
        {
            entity.HasKey(e => e.Mahd).HasName("hoadon_pkey");

            entity.ToTable("hoadon");

            entity.Property(e => e.Mahd).HasColumnName("mahd");
            entity.Property(e => e.Cachthanhtoan)
                .HasMaxLength(50)
                .HasDefaultValueSql("'Cash'::character varying")
                .HasColumnName("cachthanhtoan");
            entity.Property(e => e.Cachvanchuyen)
                .HasMaxLength(50)
                .HasDefaultValueSql("'Airline'::character varying")
                .HasColumnName("cachvanchuyen");
            entity.Property(e => e.Diachi)
                .HasMaxLength(60)
                .HasColumnName("diachi");
            entity.Property(e => e.Ghichu)
                .HasMaxLength(50)
                .HasColumnName("ghichu");
            entity.Property(e => e.Hoten)
                .HasMaxLength(50)
                .HasColumnName("hoten");
            entity.Property(e => e.Makh)
                .HasMaxLength(20)
                .HasColumnName("makh");
            entity.Property(e => e.Manv)
                .HasMaxLength(50)
                .HasColumnName("manv");
            entity.Property(e => e.Matrangthai)
                .HasDefaultValue(0)
                .HasColumnName("matrangthai");
            entity.Property(e => e.Ngaycan)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("ngaycan");
            entity.Property(e => e.Ngaydat)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("ngaydat");
            entity.Property(e => e.Ngaygiao)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("ngaygiao");
            entity.Property(e => e.Phivanchuyen).HasColumnName("phivanchuyen");

            entity.HasOne(d => d.MakhNavigation).WithMany(p => p.Hoadons)
                .HasForeignKey(d => d.Makh)
                .HasConstraintName("fk_hoadon_khachhang");

            entity.HasOne(d => d.ManvNavigation).WithMany(p => p.Hoadons)
                .HasForeignKey(d => d.Manv)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_hoadon_nhanvien");

            entity.HasOne(d => d.MatrangthaiNavigation).WithMany(p => p.Hoadons)
                .HasForeignKey(d => d.Matrangthai)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_hoadon_trangthai");
        });

        modelBuilder.Entity<Hoidap>(entity =>
        {
            entity.HasKey(e => e.Mahd).HasName("hoidap_pkey");

            entity.ToTable("hoidap");

            entity.Property(e => e.Mahd)
                .ValueGeneratedNever()
                .HasColumnName("mahd");
            entity.Property(e => e.Cauhoi)
                .HasMaxLength(50)
                .HasColumnName("cauhoi");
            entity.Property(e => e.Manv)
                .HasMaxLength(50)
                .HasColumnName("manv");
            entity.Property(e => e.Ngaydua)
                .HasDefaultValueSql("CURRENT_DATE")
                .HasColumnName("ngaydua");
            entity.Property(e => e.Traloi)
                .HasMaxLength(50)
                .HasColumnName("traloi");

            entity.HasOne(d => d.ManvNavigation).WithMany(p => p.Hoidaps)
                .HasForeignKey(d => d.Manv)
                .HasConstraintName("fk_hoidap_nhanvien");
        });

        modelBuilder.Entity<Khachhang>(entity =>
        {
            entity.HasKey(e => e.Makh).HasName("khachhang_pkey");

            entity.ToTable("khachhang");

            entity.Property(e => e.Makh)
                .HasMaxLength(20)
                .HasColumnName("makh");
            entity.Property(e => e.Diachi)
                .HasMaxLength(60)
                .HasColumnName("diachi");
            entity.Property(e => e.Dienthoai)
                .HasMaxLength(24)
                .HasColumnName("dienthoai");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Gioitinh)
                .HasDefaultValue(false)
                .HasColumnName("gioitinh");
            entity.Property(e => e.Hieuluc)
                .HasDefaultValue(false)
                .HasColumnName("hieuluc");
            entity.Property(e => e.Hinh)
                .HasMaxLength(50)
                .HasDefaultValueSql("'Photo.gif'::character varying")
                .HasColumnName("hinh");
            entity.Property(e => e.Hoten)
                .HasMaxLength(50)
                .HasColumnName("hoten");
            entity.Property(e => e.Matkhau)
                .HasMaxLength(50)
                .HasColumnName("matkhau");
            entity.Property(e => e.Ngaysinh)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("ngaysinh");
            entity.Property(e => e.Randomkey)
                .HasMaxLength(50)
                .HasColumnName("randomkey");
            entity.Property(e => e.Vaitro)
                .HasDefaultValue(0)
                .HasColumnName("vaitro");
        });

        modelBuilder.Entity<Loai>(entity =>
        {
            entity.HasKey(e => e.Maloai).HasName("loai_pkey");

            entity.ToTable("loai");

            entity.Property(e => e.Maloai).HasColumnName("maloai");
            entity.Property(e => e.Hinh)
                .HasMaxLength(50)
                .HasColumnName("hinh");
            entity.Property(e => e.Mota).HasColumnName("mota");
            entity.Property(e => e.Tenloai)
                .HasMaxLength(50)
                .HasColumnName("tenloai");
            entity.Property(e => e.Tenloaialias)
                .HasMaxLength(50)
                .HasColumnName("tenloaialias");
        });

        modelBuilder.Entity<Nhacungcap>(entity =>
        {
            entity.HasKey(e => e.Mancc).HasName("nhacungcap_pkey");

            entity.ToTable("nhacungcap");

            entity.Property(e => e.Mancc)
                .HasMaxLength(50)
                .HasColumnName("mancc");
            entity.Property(e => e.Diachi)
                .HasMaxLength(50)
                .HasColumnName("diachi");
            entity.Property(e => e.Dienthoai)
                .HasMaxLength(50)
                .HasColumnName("dienthoai");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Logo)
                .HasMaxLength(50)
                .HasColumnName("logo");
            entity.Property(e => e.Mota).HasColumnName("mota");
            entity.Property(e => e.Nguoilienlac)
                .HasMaxLength(50)
                .HasColumnName("nguoilienlac");
            entity.Property(e => e.Tencongty)
                .HasMaxLength(50)
                .HasColumnName("tencongty");
        });

        modelBuilder.Entity<Nhanvien>(entity =>
        {
            entity.HasKey(e => e.Manv).HasName("nhanvien_pkey");

            entity.ToTable("nhanvien");

            entity.Property(e => e.Manv)
                .HasMaxLength(50)
                .HasColumnName("manv");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Hoten)
                .HasMaxLength(50)
                .HasColumnName("hoten");
            entity.Property(e => e.Matkhau)
                .HasMaxLength(50)
                .HasColumnName("matkhau");
        });

        modelBuilder.Entity<Phancong>(entity =>
        {
            entity.HasKey(e => e.Mapc).HasName("phancong_pkey");

            entity.ToTable("phancong");

            entity.Property(e => e.Mapc).HasColumnName("mapc");
            entity.Property(e => e.Hieuluc).HasColumnName("hieuluc");
            entity.Property(e => e.Manv)
                .HasMaxLength(50)
                .HasColumnName("manv");
            entity.Property(e => e.Mapb)
                .HasMaxLength(7)
                .HasColumnName("mapb");
            entity.Property(e => e.Ngaypc)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("ngaypc");

            entity.HasOne(d => d.ManvNavigation).WithMany(p => p.Phancongs)
                .HasForeignKey(d => d.Manv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_phancong_nhanvien");

            entity.HasOne(d => d.MapbNavigation).WithMany(p => p.Phancongs)
                .HasForeignKey(d => d.Mapb)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_phancong_phongban");
        });

        modelBuilder.Entity<Phanquyen>(entity =>
        {
            entity.HasKey(e => e.Mapq).HasName("phanquyen_pkey");

            entity.ToTable("phanquyen");

            entity.Property(e => e.Mapq).HasColumnName("mapq");
            entity.Property(e => e.Mapb)
                .HasMaxLength(7)
                .HasColumnName("mapb");
            entity.Property(e => e.Matrang).HasColumnName("matrang");
            entity.Property(e => e.Sua)
                .HasDefaultValue(false)
                .HasColumnName("sua");
            entity.Property(e => e.Them)
                .HasDefaultValue(false)
                .HasColumnName("them");
            entity.Property(e => e.Xem)
                .HasDefaultValue(false)
                .HasColumnName("xem");
            entity.Property(e => e.Xoa)
                .HasDefaultValue(false)
                .HasColumnName("xoa");

            entity.HasOne(d => d.MapbNavigation).WithMany(p => p.Phanquyens)
                .HasForeignKey(d => d.Mapb)
                .HasConstraintName("fk_phanquyen_phongban");

            entity.HasOne(d => d.MatrangNavigation).WithMany(p => p.Phanquyens)
                .HasForeignKey(d => d.Matrang)
                .HasConstraintName("fk_phanquyen_trangweb");
        });

        modelBuilder.Entity<Phongban>(entity =>
        {
            entity.HasKey(e => e.Mapb).HasName("phongban_pkey");

            entity.ToTable("phongban");

            entity.Property(e => e.Mapb)
                .HasMaxLength(7)
                .HasColumnName("mapb");
            entity.Property(e => e.Tenpb)
                .HasMaxLength(50)
                .HasColumnName("tenpb");
            entity.Property(e => e.Thongtin).HasColumnName("thongtin");
        });

        modelBuilder.Entity<Trangthai>(entity =>
        {
            entity.HasKey(e => e.Matrangthai).HasName("trangthai_pkey");

            entity.ToTable("trangthai");

            entity.Property(e => e.Matrangthai)
                .ValueGeneratedNever()
                .HasColumnName("matrangthai");
            entity.Property(e => e.Mota)
                .HasMaxLength(500)
                .HasColumnName("mota");
            entity.Property(e => e.Tentrangthai)
                .HasMaxLength(50)
                .HasColumnName("tentrangthai");
        });

        modelBuilder.Entity<Trangweb>(entity =>
        {
            entity.HasKey(e => e.Matrang).HasName("trangweb_pkey");

            entity.ToTable("trangweb");

            entity.Property(e => e.Matrang).HasColumnName("matrang");
            entity.Property(e => e.Tentrang)
                .HasMaxLength(50)
                .HasColumnName("tentrang");
            entity.Property(e => e.Url)
                .HasMaxLength(250)
                .HasColumnName("url");
        });

        modelBuilder.Entity<Yeuthich>(entity =>
        {
            entity.HasKey(e => e.Mayt).HasName("yeuthich_pkey");

            entity.ToTable("yeuthich");

            entity.Property(e => e.Mayt).HasColumnName("mayt");
            entity.Property(e => e.Mahh).HasColumnName("mahh");
            entity.Property(e => e.Makh)
                .HasMaxLength(20)
                .HasColumnName("makh");
            entity.Property(e => e.Mota)
                .HasMaxLength(255)
                .HasColumnName("mota");
            entity.Property(e => e.Ngaychon)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("ngaychon");

            entity.HasOne(d => d.MahhNavigation).WithMany(p => p.Yeuthiches)
                .HasForeignKey(d => d.Mahh)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_yeuthich_hanghoa");

            entity.HasOne(d => d.MakhNavigation).WithMany(p => p.Yeuthiches)
                .HasForeignKey(d => d.Makh)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_yeuthich_khachhang");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
