using System.Collections.Generic;

namespace ASPDotNetProject.Models
{
    public class Classroom
    {
        public int Id { get; set; }
        public List<int> UserIds { get; set; } = new List<int>();
        public string ClassName { get; set; }
        public string Type { get; set; }
        public string? Password { get; set; }

        public List<Message> Messages { get; set; } = new List<Message>();
    }
}