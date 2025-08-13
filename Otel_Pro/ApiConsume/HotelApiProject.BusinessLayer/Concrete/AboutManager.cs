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
    public class AboutManager : IAboutService
    {
        private readonly IAboutDAL _aboutDAL;

        public AboutManager(IAboutDAL aboutDAL)
        {
            _aboutDAL = aboutDAL;
        }

        public void TDelete(int id)
        {
            _aboutDAL.Delete(id);
        }

        public About TGetById(int id)
        {
            return _aboutDAL.GetById(id);
        }

        public List<About> TGetList()
        {
           return _aboutDAL.GetList();
        }

        public void TInsert(About t)
        {
            _aboutDAL.Insert(t);
        }

        public void TUpdate(About t)
        {
            _aboutDAL.Update(t);
        }
    }
}
