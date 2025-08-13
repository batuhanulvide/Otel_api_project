using HotelApiProject.EntityLayer.Concrete;

namespace HotelApiProject.WebUI.Dtos.ReservationStatusDtos
{
    public class ReservationStatusListDto
    {
        public int ReservationStatusId { get; set; }
        public string StatusName { get; set; }
    }
}
