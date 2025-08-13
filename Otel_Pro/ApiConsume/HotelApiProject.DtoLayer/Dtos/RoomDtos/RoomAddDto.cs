using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApiProject.DtoLayer.Dtos.RoomDtos
{
    public class RoomAddDto
    {
        [Required(ErrorMessage ="Oda numarası boş bırakılamaz.")]
        public string RoomNumber { get; set; }
        public string CoverImageUrl { get; set; }
        [Required(ErrorMessage = "Fiyat bilgisi boş bırakılamaz.")]
        public int Price { get; set; }
        [Required(ErrorMessage = "Başlık bilgisi boş bırakılamaz.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Yatak sayı bilgisi boş bırakılamaz.")]
        public int BedCount { get; set; }
        [Required(ErrorMessage = "Banyo sayı bilgisi boş bırakılamaz.")]
        public int BathCount { get; set; }
        public bool Wifi { get; set; }
        public string Description { get; set; }
    }
}
