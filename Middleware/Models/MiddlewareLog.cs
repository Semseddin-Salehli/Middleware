namespace Middleware.Models
{
    public sealed class MiddlewareLog
    {
        public int Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Message { get; set; }
        public string Logger { get; set; }
        public string Level { get; set; }
        public string Exception { get; set; }
    }
}
