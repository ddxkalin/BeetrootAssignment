using Kalin.Udp.Concrete;
using Kalin.Utility.Model;
using Microsoft.Extensions.Options;

namespace Kalin.Udp
{
    public class UdpListener
    {
        private readonly UdpServerOptions _udpServerOptions;
        private readonly KalinUdpServer _server;
        public UdpListener(IOptions<UdpServerOptions> options, KalinUdpServer server)
        {
            _udpServerOptions = options?.Value ?? throw new ArgumentNullException(nameof(options));
            _server = server;
        }

        public void Run(string[] args)
        { 
            Console.WriteLine($"UDP server port: {_udpServerOptions.Port}");

            Console.WriteLine();

            // Start the server
            Console.WriteLine("Server starting...");
            _server.Start();
            Console.WriteLine($"Server ip address is {_server.Address} and port is {_server.Port}");
            Console.WriteLine("Done!");

            Console.WriteLine("Press Enter to stop the server or '!' to restart the server...");

            // Perform text input
            for (; ; )
            {
                string line = Console.ReadLine() ?? string.Empty;
                if (string.IsNullOrEmpty(line))
                    break;

                // Restart the server
                if (line == "!")
                {
                    Console.Write("Server restarting...");
                    _server.Restart();
                    Console.WriteLine("Done!");
                }
            }

            // Stop the server
            Console.Write("Server stopping...");
            _server.Stop();
            Console.WriteLine("Done!");

        }
       
    }
}
