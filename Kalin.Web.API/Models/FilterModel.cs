namespace Kalin.Web.API.Models
{
    public class FilterModel
    {
        public string IpAddress { get; set; } = string.Empty;
        public int? Port { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? fetchAll { get; set; }
    }
}
