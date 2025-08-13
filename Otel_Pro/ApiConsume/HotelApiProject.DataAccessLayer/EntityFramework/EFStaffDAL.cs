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
    public class EFStaffDAL : GenericRepository<Staff>, IStaffDAL
    {
        private readonly Context _context;

        public EFStaffDAL(Context context) : base(context)
        {
            _context = context;
        }
        public int StaffCount()
        {
            var count= _context.Staffs.Count();
            return count;
        }
        public List<Staff> GetStaffLast4()
        {
            var values= _context.Staffs.Take(4).OrderByDescending(x=>x.StaffId).ToList();
            return values;
        }
    }
}
