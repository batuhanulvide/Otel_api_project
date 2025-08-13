using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApiProject.EntityLayer.Concrete
{
    public class SendMessage
    {
        public int SendMessageId { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverSurname { get; set; }
        public string ReceiverMail { get; set; }
        public string SenderName { get; set; }
        public string SenderSurname { get; set; }
        public string SenderMail { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime SendingDate { get; set; }
    }
}
