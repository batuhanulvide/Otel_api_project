using HotelApiProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApiProject.BusinessLayer.Abstract
{
    public interface IContactService:IGenericService<Contact>
    {
        public int TGetContactCount();
        public List<Contact> TGetListContact();
        public List<Contact> TGetNewMessageForNavbar();
        public List<Contact> TGetMessageByCategory(int id);
    }
}
