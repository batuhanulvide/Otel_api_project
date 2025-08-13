using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApiProject.WebUI.Dtos.ServiceDtos
{
    public class ServiceListDto
    {
        public int ServiceId { get; set; }
        public string ServiceIconUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
