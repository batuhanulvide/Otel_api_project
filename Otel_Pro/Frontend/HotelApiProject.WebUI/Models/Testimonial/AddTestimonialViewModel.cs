namespace HotelApiProject.WebUI.Models.Testimonial
{
    public class AddTestimonialViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public IFormFile Image { get; set; }
    }
}
