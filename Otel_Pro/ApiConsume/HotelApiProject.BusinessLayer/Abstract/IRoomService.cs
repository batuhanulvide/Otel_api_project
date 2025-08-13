using HotelApiProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApiProject.BusinessLayer.Abstract
{
    public interface IRoomService:IGenericService<Room>
    {
        public int TGetRoomCount();
        public Room TGetRoomDetail(int id);
    }
}
