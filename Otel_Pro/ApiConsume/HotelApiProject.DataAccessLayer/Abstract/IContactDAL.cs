using HotelApiProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApiProject.DataAccessLayer.Abstract
{
    public interface IContactDAL:IGenericDAL<Contact>
    {
        public int GetContactCount();
        public List<Contact> GetListContact();
        public List<Contact> GetNewMessageForNavbar();
        public List<Contact> GetMessageByCategory(int id);
    }
}
