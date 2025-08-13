using System.ComponentModel.DataAnnotations;

namespace HotelApiProject.WebUI.Dtos.SubscribeDtos
{
    public class SubscribeAddDto
    {
        [Required(ErrorMessage ="E-posta bilgisi boş bırakılamaz.")]
        public string Email { get; set; }
    }
}
