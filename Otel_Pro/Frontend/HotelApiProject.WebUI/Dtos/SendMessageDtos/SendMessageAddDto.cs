namespace HotelApiProject.WebUI.Dtos.SendMessageDtos
{
    public class SendMessageAddDto
    {
        public string? ReceiverName { get; set; }
        public string? ReceiverSurname { get; set; }
        public string? ReceiverMail { get; set; }
        public string? SenderName { get; set; }
        public string? SenderSurname { get; set; }
        public string? SenderMail { get; set; }
        public string? Subject { get; set; }
        public string? Content { get; set; }
        public DateTime? SendingDate { get; set; }
    }
}
