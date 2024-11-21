using ECommerceMVC.Data;
using ECommerceMVC.Helpers;
using ECommerceMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Serialization;


namespace ECommerceMVC.Controllers
{
    public class CartController : Controller
    {
        private readonly ECommerceTutContext _context;

        public CartController(ECommerceTutContext context)
        {
            _context = context;
        }
                
        public List<CartItem> Carts => HttpContext.Session.Get<List<CartItem>>(SettingKey.CART_KEY) ?? new List<CartItem>();
        public IActionResult Index()
        {
            return View(Carts);
        }

        public IActionResult AddToCart(int id, int quantity = 1)
        {
            var giohang = Carts;
            var item = giohang.SingleOrDefault(p => p.MaHh == id);
            if (item == null)
            {
                var hangHoa = _context.Hanghoas.SingleOrDefault(p => p.Mahh == id);
                if (hangHoa == null)
                {
                    TempData["Message"] = $"Không tìm thấy hàng hóa có mã {id}";
                    return Redirect("/404");
                }
                item = new CartItem
                {
                    MaHh = hangHoa.Mahh,
                    TenHH = hangHoa.Tenhh,
                    DonGia = hangHoa.Dongia ?? 0,
                    Hinh = hangHoa.Hinh,
                    SoLuong = quantity
                };
                giohang.Add(item);
            }
            else
            {
                item.SoLuong += quantity;
            }

            HttpContext.Session.Set(SettingKey.CART_KEY, giohang);

            return RedirectToAction("Index");
        }

        public IActionResult RemoveCart(int id)
        {
            var giohang = Carts;
            var item = giohang.SingleOrDefault(p => p.MaHh == id);
            if (item != null)
            {
                giohang.Remove(item);
                HttpContext.Session.Set(SettingKey.CART_KEY, giohang);
            }
            return RedirectToAction("Index");
        }
    }
}
