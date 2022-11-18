using Kalin.Utility.Concrete;
using System.Net.Sockets;
using System.Net;
using System.Text;
using Microsoft.Extensions.Options;
using Kalin.Utility.Model;
using Kalin.EntityframeworkCore.Context;
using Kalin.EntityframeworkCore.Models;

namespace Kalin.Udp.Concrete
{
    public class KalinUdpServer: UdpServer
    {
        private readonly ApplicationDbContext _context;
        public KalinUdpServer(IOptions<UdpServerOptions> options, ApplicationDbContext context ) : this(IPAddress.Parse(options.Value.IpAddress), options.Value.Port) {
            _context = context;
        }
        public KalinUdpServer(IPAddress address, int port) : base(address, port) { }

        private void StoreMessage(EndPoint endPoint, string message)
        {
            try
            {
                IPEndPoint remoteIpEndPoint = endPoint as IPEndPoint;

                var request = new Request()
                {
                    Id = Guid.NewGuid().ToString(),
                    Date = DateTime.UtcNow,
                    Port = remoteIpEndPoint?.Port,
                    IpAddress = remoteIpEndPoint?.Address.ToString() ?? IPAddress.None.ToString(),
                    Message = new Message()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Body = message ?? String.Empty
                    }
                };

                _context.Requests.Add(request);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occured in storing the message");
                Console.WriteLine(ex);
            }
        }

        protected override void OnStarted()
        {
            // Start receive datagrams
            ReceiveAsync();
        }

        protected override void OnReceived(EndPoint endpoint, byte[] buffer, long offset, long size)
        {
            var message = Encoding.UTF8.GetString(buffer, (int)offset, (int)size);
            Console.WriteLine("Incoming: " + message);

            // Echo the message back to the sender
            StoreMessage(endpoint, message);
            SendAsync(endpoint, buffer, 0, size);
        }

        protected override void OnSent(EndPoint endpoint, long sent)
        {
            // Continue receive datagrams
            ReceiveAsync();
        }

        protected override void OnError(SocketError error)
        {
            Console.WriteLine($"Echo UDP server caught an error with code {error}");
        }

    }
}
