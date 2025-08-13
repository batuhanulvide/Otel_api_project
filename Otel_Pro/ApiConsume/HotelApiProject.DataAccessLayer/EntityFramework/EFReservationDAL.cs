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
    public class EFReservationDAL : GenericRepository<Reservation>, IReservationDAL
    {
        private readonly Context _context;

        public EFReservationDAL(Context context) : base(context)
        {
            _context = context;
        }
        public int GetReservationCount()
        {
            var count = _context.Reservations.Count();
            return count;
        }
        public List<Reservation> GetReservationLast6()
        {
            var values = _context.Reservations.Take(6).OrderByDescending(x => x.ReservationId).Include(x=>x.ReservationStatus).ToList();
            return values;
        }
        public List<Reservation> GetListReservationWithStatus()
        {
            var values= _context.Reservations.Include(x=>x.ReservationStatus).ToList();
            return values;
        }
    }
}
