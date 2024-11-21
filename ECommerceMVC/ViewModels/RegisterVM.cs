using System.ComponentModel.DataAnnotations;

namespace ECommerceMVC.ViewModels
{
    public class RegisterVM
    {
        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage = "*")]
        [MaxLength(20, ErrorMessage = "Tối đa 20 ký tự")]
        public string Makh { get; set; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "*")]
        [DataType(DataType.Password)]
        public string Matkhau { get; set; }

        [Display(Name = "Họ tên")]
        [Required(ErrorMessage = "*")]
        [MaxLength(50, ErrorMessage = "Tối đa 50 ký tự")]
        public string Hoten { get; set; }

        [Display(Name = "Giới tính")]
        public bool Gioitinh { get; set; } = true;

        [Display(Name = "Ngày sinh")]
        [DataType(DataType.Date)]
        public DateTime? Ngaysinh { get; set; }

        [MaxLength(60, ErrorMessage = "Tối đa 60 ký tự")]
        [Display(Name ="Địa chỉ")]
        public string Diachi { get; set; }

        [Display(Name = "Điện thoại")]
        [MaxLength(24, ErrorMessage = "Tối đa 24 ký tự")]
        [RegularExpression(@"0[9875]\d{8}", ErrorMessage = "Chưa đúng định dạng số điện thoại")]
        public string Dienthoai { get; set; }

        [EmailAddress(ErrorMessage = "Chưa đúng định dạng")]
        public string Email { get; set; }

        [Display(Name = "Hình")]
        public string? Hinh { get; set; }
    }
}