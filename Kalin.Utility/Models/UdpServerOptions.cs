using System.Net;

namespace Kalin.Utility.Model
{
    public class UdpServerOptions
    {
        public int Port { get; set; } = 3333;
        public string IpAddress { get; set; } = IPAddress.Any.ToString();
    }
}
