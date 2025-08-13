using HotelApiProject.EntityLayer.Concrete;
using System.ComponentModel.DataAnnotations;

namespace HotelApiProject.WebUI.Dtos.CommentDtos
{
    public class CommentUpdateDto
    {
        public int CommentId { get; set; }
        public string Text { get; set; }
        public DateTime CommentDate { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public int UserId { get; set; }
        public AppUser User { get; set; }
        public bool IsApproved { get; set; }
    }
}
