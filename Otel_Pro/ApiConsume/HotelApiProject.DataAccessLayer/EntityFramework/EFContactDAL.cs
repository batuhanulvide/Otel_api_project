using HotelApiProject.DataAccessLayer.Abstract;
using HotelApiProject.DataAccessLayer.Concrete;
using HotelApiProject.DataAccessLayer.Repositories;
using HotelApiProject.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApiProject.DataAccessLayer.EntityFramework
{
    public class EFContactDAL : GenericRepository<Contact>, IContactDAL
    {
        private readonly Context _context;

        public EFContactDAL(Context context) : base(context)
        {
            _context = context;
        }
        public int GetContactCount()
        {
            int count = _context.Contacts.Count();
            return count;
        }
        public List<Contact> GetListContact()
        {
            var values= _context.Contacts.Include(x=>x.MessageCategory).ToList();
            return values;
        }
        public List<Contact> GetNewMessageForNavbar()
        {
            var values = _context.Contacts.Where(x=>x.IsApproved==false).Include(x => x.MessageCategory).Take(3).ToList();
            return values;
        }
        public List<Contact> GetMessageByCategory(int id)
        {
            var values = _context.Contacts.Where(x => x.MessageCategoryId==id).Include(x => x.MessageCategory).ToList();
            return values;
        }
    }
}
