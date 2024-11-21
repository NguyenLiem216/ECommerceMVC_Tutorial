using AutoMapper;
using ECommerceMVC.Data;
using ECommerceMVC.Helpers;
using ECommerceMVC.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ECommerceMVC.Controllers
{
    public class KhachHangController : Controller
    {
        private readonly ECommerceTutContext _context;
        private readonly IMapper _mapper;

        public KhachHangController(ECommerceTutContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        #region Register
        [HttpGet]
        public IActionResult DangKy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DangKy(RegisterVM model, IFormFile Hinh)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var khachHang = _mapper.Map<Khachhang>(model);
                    khachHang.Randomkey = Util.GenerateRandomKey();
                    khachHang.Matkhau = model.Matkhau.ToMd5Hash(khachHang.Randomkey);
                    khachHang.Hieuluc = true; //sẽ xử lý khi dùng mail để active
                    khachHang.Vaitro = 0;

                    if (Hinh != null)
                    {
                        khachHang.Hinh = Util.UploadHinh(Hinh, "KhachHang");
                    }
                    _context.Add(khachHang);
                    _context.SaveChanges();
                    return RedirectToAction("Index", "HangHoa");
                }
                catch (Exception ex) { }

            }
            return View();
        }
        #endregion

        #region Login
        [HttpGet]
        public IActionResult DangNhap(string? ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DangNhap(LoginVM model, string? ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            if (ModelState.IsValid)
            {
                var khachHang = _context.Khachhangs.SingleOrDefault(kh => kh.Makh == model.UserName);
                if (khachHang == null)
                {
                    ModelState.AddModelError("loi","Không có khách hàng này");
                }
                else
                {
                    if(!khachHang.Hieuluc)
                    {
                        ModelState.AddModelError("loi", "Tài khoản đã bị khóa. Vui lòng liên hệ Admin.");
                    }
                    else
                    {
                        if (khachHang.Matkhau != model.Password.ToMd5Hash(khachHang.Randomkey))
                        {
                            ModelState.AddModelError("loi", "Sai mật khẩu");
                        }
                        else
                        {
                            var claims = new List<Claim>
                            {
                                new Claim(ClaimTypes.Email, khachHang.Email),
                                new Claim(ClaimTypes.Name, khachHang.Hoten),
                                new Claim("CustomerID", khachHang.Makh),

                                //claim - role động
                                new Claim(ClaimTypes.Role,"Customer")
                            };

                            var claimsIdentity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
                            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                            await HttpContext.SignInAsync(claimsPrincipal);

                            if (Url.IsLocalUrl(ReturnUrl))
                            {
                                return Redirect(ReturnUrl);
                            }
                            else
                            {
                                return Redirect("/");
                            }
                        }
                    }

                }
            }
            return View();
        }
        #endregion

        [Authorize]
        public IActionResult Profile()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> DangXuat()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}
