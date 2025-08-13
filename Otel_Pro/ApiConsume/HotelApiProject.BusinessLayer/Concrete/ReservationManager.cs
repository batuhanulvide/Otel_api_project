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
    public class ReservationManager : IReservationService
    {
        private readonly IReservationDAL _ReservationDAL;

        public ReservationManager(IReservationDAL ReservationDAL)
        {
            _ReservationDAL = ReservationDAL;
        }

        public void TDelete(int id)
        {
            _ReservationDAL.Delete(id);
        }

        public Reservation TGetById(int id)
        {
            return _ReservationDAL.GetById(id);
        }

        public List<Reservation> TGetList()
        {
           return _ReservationDAL.GetList();
        }

        public List<Reservation> TGetListReservationWithStatus()
        {
          return  _ReservationDAL.GetListReservationWithStatus();
        }

        public int TGetReservationCount()
        {
           return _ReservationDAL.GetReservationCount();
        }

        public List<Reservation> TGetReservationLast6()
        {
            return _ReservationDAL.GetReservationLast6();
        }

        public void TInsert(Reservation t)
        {
            _ReservationDAL.Insert(t);
        }

        public void TUpdate(Reservation t)
        {
            _ReservationDAL.Update(t);
        }
    }
}
