using HotelApiProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApiProject.DataAccessLayer.Abstract
{
    public interface ICommentDAL:IGenericDAL<Comment>
    {
        public List<Comment> GetCommentList();
        public List<Comment> GetCommentListByRoomId(int id);
    }
}
