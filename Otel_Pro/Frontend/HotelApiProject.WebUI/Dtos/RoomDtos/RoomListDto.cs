using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApiProject.WebUI.Dtos.RoomDtos
{
    public class RoomListDto
    {
        public int RoomId { get; set; }
        public string RoomNumber { get; set; }
        public string CoverImageUrl { get; set; }
        public int Price { get; set; }
        public string Title { get; set; }
        public int BedCount { get; set; }
        public int BathCount { get; set; }
        public bool Wifi { get; set; }
        public string Description { get; set; }
    }
}
