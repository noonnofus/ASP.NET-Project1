namespace ASPDotNetProject.Models
{
    public class Message
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;
        public string Sender { get; set; }
        public bool IsUser { get; set; }
    }
}
