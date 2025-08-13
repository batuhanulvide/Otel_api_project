namespace HotelApiProject.WebUI.Models.Staff
{
    public class AddStaffViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string? FacebookUrl { get; set; }
        public string? TwitterUrl { get; set; }
        public string? InstagramUrl { get; set; }
        public bool IsApproved { get; set; }
        public IFormFile Image {  get; set; }
    }
}
