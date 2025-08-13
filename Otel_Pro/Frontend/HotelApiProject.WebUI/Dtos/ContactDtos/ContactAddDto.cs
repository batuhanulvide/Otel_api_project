using HotelApiProject.EntityLayer.Concrete;
using System.ComponentModel.DataAnnotations;

namespace HotelApiProject.WebUI.Dtos.ContactDtos
{
    public class ContactAddDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
        public DateTime SendingDate { get; set; }
        public int MessageCategoryId { get; set; }
        public bool IsApproved { get; set; }
    }
}
