using HotelApiProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApiProject.DataAccessLayer.Abstract
{
    public interface IStaffDAL:IGenericDAL<Staff>
    {
        public int StaffCount();
        public List<Staff> GetStaffLast4();
    }
}
