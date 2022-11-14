using System.Net.Sockets;
using System.Text;

namespace UDPClientService;

public class ClientService : BackgroundService
{
    private readonly ILogger<ClientService> _logger;

    public ClientService(ILogger<ClientService> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            Client();
            await Task.Delay(1000, stoppingToken);
        }
    }

    private static void Client()
    {
        UdpClient udpClient = new UdpClient();
        udpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
        udpClient.Connect("localhost", 11000);

        try
        {
            string message = String.Empty;
            do
            {
                message = Console.ReadLine();

                // Sends a message to the host to which you have connected.
                Byte[] sendBytes = Encoding.ASCII.GetBytes(message);

                udpClient.Send(sendBytes, sendBytes.Length);
            } while (message != String.Empty);

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

    }
}

