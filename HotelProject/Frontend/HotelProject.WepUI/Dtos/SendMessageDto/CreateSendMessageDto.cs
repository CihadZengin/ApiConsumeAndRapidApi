namespace HotelProject.WepUI.Dtos.SendMessageDto
{
    public class CreateSendMessageDto
    {
        public string ReceiverName { get; set; }
        public string ReceiverMail { get; set; }
        public string SendrName { get; set; }
        public string SenderMail { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
    }
}
