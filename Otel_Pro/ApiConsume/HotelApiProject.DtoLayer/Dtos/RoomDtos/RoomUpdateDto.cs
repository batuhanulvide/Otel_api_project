using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApiProject.DtoLayer.Dtos.RoomDtos
{
    public class RoomUpdateDto
    {
        public int RoomId { get; set; }

        [Required(ErrorMessage = "Oda numarası boş bırakılamaz.")]
        public string RoomNumber { get; set; }

        [Required(ErrorMessage = "Oda görsel bilgisi boş bırakılamaz.")]
        public string CoverImageUrl { get; set; }

        [Required(ErrorMessage = "Fiyat bilgisi boş bırakılamaz.")]
        public int Price { get; set; }

        [Required(ErrorMessage = "Başlık bilgisi boş bırakılamaz.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Yatak sayı bilgisi boş bırakılamaz.")]
        [Range(1, 200, ErrorMessage = "Yatak sayısı 1 ile 200 arasında olmalıdır.")]
        public int BedCount { get; set; }

        [Required(ErrorMessage = "Banyo sayı bilgisi boş bırakılamaz.")]
        public int BathCount { get; set; }

        public bool Wifi { get; set; }

        [Required(ErrorMessage = "Açıklama bilgisi boş bırakılamaz.")]
        public string Description { get; set; }
    }

}
