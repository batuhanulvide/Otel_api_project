using HotelApiProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApiProject.DataAccessLayer.Abstract
{
    public interface IReservationDAL:IGenericDAL<Reservation>
    {
        public int GetReservationCount();
        public List<Reservation> GetReservationLast6();
        public List<Reservation> GetListReservationWithStatus();
    }
}
