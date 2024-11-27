using System;

namespace MyInMemoryApp.Models
{
    public class LogItem
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
