using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApiProject.EntityLayer.Concrete
{
    public class AppUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? About { get; set; }
        public string? City { get; set; }
        public string? Profession { get; set; }
        public string ImageUrl { get; set; }
        public string? InstagramUrl { get; set; }
        public string? TwitterUrl { get; set; }
        public DateTime Birtday { get; set; }
        public DateTime RegisterDate { get; set; }
        public int WorkLocationId { get; set; }
        public WorkLocation WorkLocation { get; set; }
        public bool Gender { get; set; }
        public List<Comment>? Comments { get; set; }
    }
}
