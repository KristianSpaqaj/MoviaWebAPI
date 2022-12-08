namespace MoviaWebAPI.Models
{
    public class BusLine
    {
        public string Line { get; set; }
        public DateTime Time { get; set; }
        public string Message { get; set; }
        public BusLine(string line, DateTime time, string message)
        {
            Line = line;
            Time = time;
            Message = message;
        }
    }
}
