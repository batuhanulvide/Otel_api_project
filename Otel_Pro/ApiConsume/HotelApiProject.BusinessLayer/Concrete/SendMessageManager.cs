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
    public class SendMessageManager : ISendMessageService
    {
        private readonly ISendMessageDAL _SendMessageDAL;

        public SendMessageManager(ISendMessageDAL SendMessageDAL)
        {
            _SendMessageDAL = SendMessageDAL;
        }

        public void TDelete(int id)
        {
            _SendMessageDAL.Delete(id);
        }

        public SendMessage TGetById(int id)
        {
            return _SendMessageDAL.GetById(id);
        }

        public List<SendMessage> TGetList()
        {
           return _SendMessageDAL.GetList();
        }

        public int TGetSendboxCount()
        {
           return _SendMessageDAL.GetSendboxCount();
        }

        public void TInsert(SendMessage t)
        {
            _SendMessageDAL.Insert(t);
        }

        public void TUpdate(SendMessage t)
        {
            _SendMessageDAL.Update(t);
        }
    }
}
