namespace Kalin.EntityframeworkCore.Models
{
    public class Message
    {
        public string Id { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;

        public virtual Request Request { get; set; }
    }
}
