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
    public class MessageCategoryManager : IMessageCategoryService
    {
        private readonly IMessageCategoryDAL _MessageCategoryDAL;

        public MessageCategoryManager(IMessageCategoryDAL MessageCategoryDAL)
        {
            _MessageCategoryDAL = MessageCategoryDAL;
        }

        public void TDelete(int id)
        {
            _MessageCategoryDAL.Delete(id);
        }

        public MessageCategory TGetById(int id)
        {
            return _MessageCategoryDAL.GetById(id);
        }

        public List<MessageCategory> TGetList()
        {
           return _MessageCategoryDAL.GetList();
        }

        public void TInsert(MessageCategory t)
        {
            _MessageCategoryDAL.Insert(t);
        }

        public void TUpdate(MessageCategory t)
        {
            _MessageCategoryDAL.Update(t);
        }
    }
}
