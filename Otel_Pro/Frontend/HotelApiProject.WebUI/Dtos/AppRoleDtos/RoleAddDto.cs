using System.ComponentModel.DataAnnotations;

namespace HotelApiProject.WebUI.Dtos.AppRoleDtos
{
    public class RoleAddDto
    {
        [Required(ErrorMessage ="Rol adı boş geçilemez")]
        public string Name { get; set; }
    }
}
