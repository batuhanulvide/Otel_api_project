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
    public class EFWorkLocationDAL : GenericRepository<WorkLocation>, IWorkLocationDAL
    {
        private readonly Context _context;

        public EFWorkLocationDAL(Context context) : base(context)
        {
            _context = context;
        }
    }
}
