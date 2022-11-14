using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UDPServerService;

public class ServerService : BackgroundService
{
    private readonly ILogger<ServerService> _logger;

    public ServerService(ILogger<ServerService> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            Receiver();
            await Task.Delay(1000, stoppingToken);
        }
    }

    private static void Receiver()
    {
        UdpClient udpClient = new UdpClient();
        udpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
        udpClient.Client.Bind(new IPEndPoint(IPAddress.Any, 11000));

        Task.Run(async () =>
        {
            try
            {
                //IPEndPoint object will allow us to read datagrams sent from any source.
                IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);

                string message = String.Empty;
                do
                {
                    // Blocks until a message returns on this socket from a remote host.
                    Byte[] receiveBytes = udpClient.Receive(ref RemoteIpEndPoint);
                    message = Encoding.ASCII.GetString(receiveBytes);

                    // Uses the IPEndPoint object to determine which of these two hosts responded.
                    Console.WriteLine("This is the message you received: " + message);
                }
                while (message != "exit");
                udpClient.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
                finally
                {
                    udpClient.Dispose();
                }

                Console.WriteLine("Press Any Key to Continue");
                Console.ReadKey();
        });
    }
}

