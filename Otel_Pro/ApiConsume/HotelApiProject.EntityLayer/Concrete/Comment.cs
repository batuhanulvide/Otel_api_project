using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApiProject.EntityLayer.Concrete
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Text { get; set; }
        public DateTime CommentDate { get; set; }
        public int roomId { get; set; }
        public Room? Room { get; set; }
        public int userId { get; set; }
        public AppUser? User { get; set; }
        public bool IsApproved { get; set; }
    }
}
