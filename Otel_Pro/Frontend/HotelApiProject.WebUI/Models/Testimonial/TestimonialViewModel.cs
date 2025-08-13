namespace HotelApiProject.WebUI.Models.Testimonial
{
    public class TestimonialViewModel
    {
        public int TestimonialId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsApproved { get; set; }
        public string ImageUrl { get; set; }

    }
}
