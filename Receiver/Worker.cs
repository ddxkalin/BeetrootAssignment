using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Receiver;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private const int receivePort = 11100;
    //private const long IPAddress = 127.0.0.1;

    public Worker(ILogger<Worker> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Receiver running at: {time}", DateTimeOffset.Now);

        while (true)
        {
            await Receiver();
            await Task.Delay(1000, stoppingToken);
        }
    }

    private async Task Receiver()
    {
        using (UdpClient udpClient = new UdpClient(receivePort))
        {
            try
            {
                IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, receivePort);

                Byte[] receiveBytes = udpClient.Receive(ref RemoteIpEndPoint);
                string returnData = Encoding.ASCII.GetString(receiveBytes);

                Console.WriteLine("This is the message you received " +
                                                returnData.ToString());
                Console.WriteLine("This message was sent from " +
                                            RemoteIpEndPoint.Address.ToString() +
                                            " on their port number " +
                                            RemoteIpEndPoint.Port.ToString());

                //udpClient.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                udpClient.Dispose();
            }
        }
    }
}