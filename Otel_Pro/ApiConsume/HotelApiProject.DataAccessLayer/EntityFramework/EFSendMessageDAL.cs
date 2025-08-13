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
    public class EFSendMessageDAL : GenericRepository<SendMessage>, ISendMessageDAL
    {
        private readonly Context _context;

        public EFSendMessageDAL(Context context) : base(context)
        {
            _context = context;
        }
        public int GetSendboxCount()
        {
            int count = _context.SendMessages.Count();
            return count;
        }
    }
}
