using ECommerceMVC.Data;
using ECommerceMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceMVC.ViewComponents
{
    public class MenuLoaiViewComponent : ViewComponent
    {
        private readonly ECommerceTutContext _context;

        public MenuLoaiViewComponent(ECommerceTutContext context) => _context = context;
        
        public IViewComponentResult Invoke()
        {
            var data = _context.Loais.Select(lo => new MenuLoaiVM
            {
                MaLoai = lo.Maloai, TenLoai=lo.Tenloai, SoLuong = lo.Hanghoas.Count
            }).OrderBy(p => p.TenLoai);

            return View(data);
        }
    }
}
