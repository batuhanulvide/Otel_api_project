using HotelApiProject.EntityLayer.Concrete;

namespace HotelApiProject.WebUI.Dtos.ReservationDtos
{
    public class ReservationListDto
    {
        public int ReservationId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public DateTime ReservationDate { get; set; }
        public int ChildCount { get; set; }
        public int AdultCount { get; set; }
        public int RoomCount { get; set; }
        public string? Request { get; set; }
        public string? Description { get; set; }
        public int ReservationStatusId { get; set; }
        public ReservationStatus ReservationStatus { get; set; }
    }
}
