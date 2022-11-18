namespace Kalin.EntityframeworkCore.Models
{
    public class Request
    {
        public string Id { get; set; } = string.Empty;
        public string IpAddress { get; set; } = string.Empty;
        public int? Port { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;

        public string MessageId { get; set; } = string.Empty;
        public virtual Message Message { get; set; }
    }
}
