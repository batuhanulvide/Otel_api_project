using HotelApiProject.EntityLayer.Concrete;

namespace HotelApiProject.WebUI.Dtos.AppUserDtos
{
    public class UserListDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? About { get; set; }
        public string? City { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string? Profession { get; set; }
        public string ImageUrl { get; set; }
        public string? InstagramUrl { get; set; }
        public string? TwitterUrl { get; set; }
        public int WorkLocationId { get; set; }
        public WorkLocation WorkLocation { get; set; }
        public DateTime Birtday { get; set; }
        public bool Gender { get; set; }
    }
}
