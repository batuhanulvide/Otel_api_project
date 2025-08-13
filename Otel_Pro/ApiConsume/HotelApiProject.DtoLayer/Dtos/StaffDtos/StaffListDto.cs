using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApiProject.DtoLayer.Dtos.StaffDtos
{
    public class StaffListDto
    {
        public int StaffId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public bool IsApproved { get; set; }
    }
}
