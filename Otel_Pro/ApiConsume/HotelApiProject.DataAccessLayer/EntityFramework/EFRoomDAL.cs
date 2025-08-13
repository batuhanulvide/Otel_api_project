using HotelApiProject.DataAccessLayer.Abstract;
using HotelApiProject.DataAccessLayer.Concrete;
using HotelApiProject.DataAccessLayer.Repositories;
using HotelApiProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApiProject.DataAccessLayer.EntityFramework
{
    public class EFRoomDAL : GenericRepository<Room>, IRoomDAL
    {
        private readonly Context _context;

        public EFRoomDAL(Context context) : base(context)
        {
            _context = context;
        }
        public int GetRoomCount()
        {
            var count = _context.Rooms.Count();
            return count;
        }
        public Room GetRoomDetail(int id)
        {
            var value=_context.Rooms.Where(x=>x.RoomId == id).FirstOrDefault();
            return value;
        }
    }
}
