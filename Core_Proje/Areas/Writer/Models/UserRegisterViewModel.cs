using System.ComponentModel.DataAnnotations;

namespace Core_Proje.Areas.Writer.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "Lütfen kullanıcı adını giriniz.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Lütfen şifreyi giriniz.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Lütfen şifreyi doğrulayınız.")]
        [Compare("Password", ErrorMessage = "Şifreler uyuşmuyor.")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Lütfen mail adresini giriniz.")]
        public string Mail { get; set; }

    }
}
