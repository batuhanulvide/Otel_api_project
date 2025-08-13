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
    public class SubscribeManager : ISubscribeService
    {
        private readonly ISubscribeDAL _SubscribeDAL;

        public SubscribeManager(ISubscribeDAL SubscribeDAL)
        {
            _SubscribeDAL = SubscribeDAL;
        }

        public void TDelete(int id)
        {
            _SubscribeDAL.Delete(id);
        }

        public Subscribe TGetById(int id)
        {
            return _SubscribeDAL.GetById(id);
        }

        public List<Subscribe> TGetList()
        {
           return _SubscribeDAL.GetList();
        }

        public void TInsert(Subscribe t)
        {
            _SubscribeDAL.Insert(t);
        }

        public void TUpdate(Subscribe t)
        {
            _SubscribeDAL.Update(t);
        }
    }
}
