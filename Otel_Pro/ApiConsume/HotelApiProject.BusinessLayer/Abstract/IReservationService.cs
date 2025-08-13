using HotelApiProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApiProject.BusinessLayer.Abstract
{
    public interface IReservationService:IGenericService<Reservation>
    {
        public int TGetReservationCount();
        public List<Reservation> TGetReservationLast6();
        public List<Reservation> TGetListReservationWithStatus();
    }
}
