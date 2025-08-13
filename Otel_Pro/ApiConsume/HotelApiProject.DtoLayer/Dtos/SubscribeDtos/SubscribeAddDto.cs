using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApiProject.DtoLayer.Dtos.SubscribeDtos
{
    public class SubscribeAddDto
    {
        [Required(ErrorMessage ="E-posta adresi boş bırakılamaz.")]
        public string Email { get; set; }
    }
}
