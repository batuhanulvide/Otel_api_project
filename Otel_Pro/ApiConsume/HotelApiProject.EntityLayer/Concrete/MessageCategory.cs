using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApiProject.EntityLayer.Concrete
{
    public class MessageCategory
    {
        public int MessageCategoryId { get; set; }
        public string MessageCategoryName { get; set; }
        public string IconUrl { get; set; }
        public List<Contact>? Contacts { get; set; }
    }
}
