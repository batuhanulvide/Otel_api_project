using System.ComponentModel.DataAnnotations;

namespace HotelApiProject.WebUI.Models.Subscribe
{
    public class ModelCreateSubscibe
    {
        [Required(ErrorMessage="E-posta bilgisi boş geçilemez.")]
        public string Email { get; set; }
    }
}
