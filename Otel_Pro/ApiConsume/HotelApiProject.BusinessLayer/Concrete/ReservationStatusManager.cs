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
    public class ReservationStatusManager : IReservationStatusService
    {
        private readonly IReservationStatusDAL _ReservationStatusDAL;

        public ReservationStatusManager(IReservationStatusDAL ReservationStatusDAL)
        {
            _ReservationStatusDAL = ReservationStatusDAL;
        }

        public void TDelete(int id)
        {
            _ReservationStatusDAL.Delete(id);
        }

        public ReservationStatus TGetById(int id)
        {
            return _ReservationStatusDAL.GetById(id);
        }

        public List<ReservationStatus> TGetList()
        {
           return _ReservationStatusDAL.GetList();
        }

        public void TInsert(ReservationStatus t)
        {
            _ReservationStatusDAL.Insert(t);
        }

        public void TUpdate(ReservationStatus t)
        {
            _ReservationStatusDAL.Update(t);
        }
    }
}
