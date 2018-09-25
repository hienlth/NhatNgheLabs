using System.ComponentModel.DataAnnotations;

namespace PassDataFromControllerToView.Models
{
    public class LoginViewModel
    {
        [Display(Name = "Mã khách hàng")]
        [MaxLength(50)]
        public string MaKH { get; set; }
        [Display(Name = "Mật khẩu")]
        [MaxLength(50)]
        [DataType(DataType.Password)]
        public string MatKhau { get; set; }
    }
}