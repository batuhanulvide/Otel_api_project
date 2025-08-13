using HotelApiProject.EntityLayer.Concrete;
using System.ComponentModel.DataAnnotations;

namespace HotelApiProject.WebUI.Dtos.ReservationStatusDtos
{
    public class ReservationStatusUpdateDto
    {
        public int ReservationStatusId { get; set; }
        public string StatusName { get; set; }
    }
}
