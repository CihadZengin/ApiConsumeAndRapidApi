using System.ComponentModel.DataAnnotations;

namespace HotelProject.WepUI.Dtos.LoginDto
{
    public class LoginUserDto
    {
        [Required(ErrorMessage = "Kullanıcı Adı alanı boş geçilemez")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Şifre alanı boş geçilemez")]
        public string Password { get; set; }
    }
}
