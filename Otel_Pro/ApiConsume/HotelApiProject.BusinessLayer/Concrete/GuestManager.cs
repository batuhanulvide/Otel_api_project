using HotelApiProject.BusinessLayer.Abstract;
using HotelApiProject.DataAccessLayer.Abstract;
using HotelApiProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApiProject.BusinessLayer.Concrete
{
    public class GuestManager : IGuestService
    {
        private readonly IGuestDAL _GuestDAL;

        public GuestManager(IGuestDAL GuestDAL)
        {
            _GuestDAL = GuestDAL;
        }

        public void TDelete(int id)
        {
            _GuestDAL.Delete(id);
        }

        public Guest TGetById(int id)
        {
            return _GuestDAL.GetById(id);
        }

        public List<Guest> TGetList()
        {
           return _GuestDAL.GetList();
        }

        public int TGetGuestCount()
        {
            return _GuestDAL.GetGuestCount();
        }

        public void TInsert(Guest t)
        {
            _GuestDAL.Insert(t);
        }

        public void TUpdate(Guest t)
        {
            _GuestDAL.Update(t);
        }
    }
}
