using HotelApiProject.DataAccessLayer.Abstract;
using HotelApiProject.DataAccessLayer.Concrete;
using HotelApiProject.DataAccessLayer.Repositories;
using HotelApiProject.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApiProject.DataAccessLayer.EntityFramework
{
    public class EFCommentDAL : GenericRepository<Comment>, ICommentDAL
    {
        private readonly Context _context;

        public EFCommentDAL(Context context) : base(context)
        {
            _context = context;
        }
        public List<Comment> GetCommentList()
        {
            var values = _context.Comments.Include(x => x.User).Include(x => x.Room).ToList();
            return values;
        }
        public List<Comment> GetCommentListByRoomId(int id)
        {
            var values = _context.Comments.Where(x => x.roomId == id).Include(x => x.User).Include(x => x.Room).ToList();
            return values;
        }
    }
}
