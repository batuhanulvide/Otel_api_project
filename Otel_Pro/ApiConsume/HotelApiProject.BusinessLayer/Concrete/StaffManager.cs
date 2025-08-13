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
    public class StaffManager : IStaffService
    {
        private readonly IStaffDAL _StaffDAL;

        public StaffManager(IStaffDAL StaffDAL)
        {
            _StaffDAL = StaffDAL;
        }

        public void TDelete(int id)
        {
            _StaffDAL.Delete(id);
        }

        public Staff TGetById(int id)
        {
            return _StaffDAL.GetById(id);
        }

        public List<Staff> TGetList()
        {
           return _StaffDAL.GetList();
        }

        public List<Staff> TGetStaffLast4()
        {
            return _StaffDAL.GetStaffLast4();
        }

        public void TInsert(Staff t)
        {
            _StaffDAL.Insert(t);
        }

        public int TStaffCount()
        {
           return _StaffDAL.StaffCount();
        }

        public void TUpdate(Staff t)
        {
            _StaffDAL.Update(t);
        }
    }
}
