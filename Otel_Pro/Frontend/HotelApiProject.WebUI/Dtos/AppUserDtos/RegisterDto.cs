using System.ComponentModel.DataAnnotations;

namespace HotelApiProject.WebUI.Dtos.AppUserDtos
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "Ad bilgisi boş bırakılamaz.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Soyad bilgisi boş bırakılamaz.")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Şehir bilgisi boş bırakılamaz.")]
        public string City { get; set; }
        [Required(ErrorMessage = "Kullanıcı adı bilgisi boş bırakılamaz.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "E-posta bilgisi boş bırakılamaz.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Parola bilgisi boş bırakılamaz.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Parola tekrar bilgisi boş bırakılamaz.")]
        [Compare("Password", ErrorMessage = "Parolalar birbirleriyle uyuşmuyor.")]
        public string ConfirmPassword { get; set; }
        public bool Gender { get; set; }
    }
}
