using ECommerceMVC.Data;
using ECommerceMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerceMVC.Controllers
{
    public class HangHoaController : Controller
    {
        private readonly ECommerceTutContext _context;

        public HangHoaController(ECommerceTutContext context) => _context = context;
        public IActionResult Index(int? loai)
        {
            var hangHoas = _context.Hanghoas.AsQueryable();

            if (loai.HasValue)
            {
                hangHoas = hangHoas.Where(p => p.Maloai == loai.Value);
            }

            var result = hangHoas.Select(p => new HangHoaVM
            {
                MaHh = p.Mahh,
                TenHH = p.Tenhh,
                DonGia = p.Dongia ?? 0,
                MoTaNgan = p.Motadonvi,
                Hinh = p.Hinh,
                TenLoai = p.MaloaiNavigation.Tenloai
            });
            return View(result);
        }
        public IActionResult Search(string? query)
        {
            var hangHoas = _context.Hanghoas.AsQueryable();

            if (query != null)
            {
                hangHoas = hangHoas.Where(p => p.Tenhh.Contains(query));
            }

            var result = hangHoas.Select(p => new HangHoaVM
            {
                MaHh = p.Mahh,
                TenHH = p.Tenhh,
                DonGia = p.Dongia ?? 0,
                MoTaNgan = p.Motadonvi,
                Hinh = p.Hinh,
                TenLoai = p.MaloaiNavigation.Tenloai
            });
            return View(result);
        }

        public IActionResult Detail(int id)
        {
            var data = _context.Hanghoas
                .Include(p => p.MaloaiNavigation)
                .SingleOrDefault(p => p.Mahh == id);
            if(data == null)
            {
                TempData["Message"] = $"Không thấy sản phẩm có mã {id}";
                return Redirect("/404");
            }
            var result = new ChiTietHangHoaVM
            {
                MaHh = data.Mahh,
                TenHH = data.Tenhh,
                DonGia = data.Dongia ?? 0,
                ChiTiet = data.Mota,
                Hinh = data.Hinh,
                MoTaNgan = data.Motadonvi,
                TenLoai = data.MaloaiNavigation.Tenloai,
                SoLuongTon = 10,
                DiemDanhGia = 5
            };
            return View(result);
        }
    }
}