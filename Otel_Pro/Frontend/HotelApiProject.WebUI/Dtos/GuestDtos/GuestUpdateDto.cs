namespace HotelApiProject.WebUI.Dtos.GuestDtos
{
    public class GuestUpdateDto
    {
        public int GuestId { get; set; }
        public string? TC { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DateTime? Birthday { get; set; }
        public string? City { get; set; }
    }
}
