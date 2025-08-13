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
    public class CommentManager : ICommentService
    {
        private readonly ICommentDAL _CommentDAL;

        public CommentManager(ICommentDAL CommentDAL)
        {
            _CommentDAL = CommentDAL;
        }

        public void TDelete(int id)
        {
            _CommentDAL.Delete(id);
        }

        public Comment TGetById(int id)
        {
            return _CommentDAL.GetById(id);
        }

        public List<Comment> TGetCommentList()
        {
            return _CommentDAL.GetCommentList();
        }

        public List<Comment> TGetCommentListByRoomId(int id)
        {
            return _CommentDAL.GetCommentListByRoomId(id);
        }

        public List<Comment> TGetList()
        {
           return _CommentDAL.GetList();
        }

        public void TInsert(Comment t)
        {
            _CommentDAL.Insert(t);
        }

        public void TUpdate(Comment t)
        {
            _CommentDAL.Update(t);
        }
    }
}
