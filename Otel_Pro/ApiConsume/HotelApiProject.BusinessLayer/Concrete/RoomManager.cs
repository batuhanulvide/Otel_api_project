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
    public class RoomManager : IRoomService
    {
        private readonly IRoomDAL _RoomDAL;

        public RoomManager(IRoomDAL RoomDAL)
        {
            _RoomDAL = RoomDAL;
        }

        public void TDelete(int id)
        {
            _RoomDAL.Delete(id);
        }

        public Room TGetById(int id)
        {
            return _RoomDAL.GetById(id);
        }

        public List<Room> TGetList()
        {
           return _RoomDAL.GetList();
        }

        public int TGetRoomCount()
        {
            return _RoomDAL.GetRoomCount();
        }

        public Room TGetRoomDetail(int id)
        {
            return _RoomDAL.GetRoomDetail(id);
        }

        public void TInsert(Room t)
        {
            _RoomDAL.Insert(t);
        }

        public void TUpdate(Room t)
        {
            _RoomDAL.Update(t);
        }
    }
}
