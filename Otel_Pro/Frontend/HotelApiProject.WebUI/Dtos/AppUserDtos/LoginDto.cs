using System.ComponentModel.DataAnnotations;

namespace HotelApiProject.WebUI.Dtos.AppUserDtos
{
    public class LoginDto
    {
        [Required(ErrorMessage ="Kullanıcı adı bilgisi boş bırakılamaz.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Parola bilgisi boş bırakılamaz.")]
        public string Password { get; set; }
    }
}
