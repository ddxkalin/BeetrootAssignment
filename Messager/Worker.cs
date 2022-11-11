using System.Net.Sockets;
using System.Text;
using System.Net;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Messager;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;

    private const int listenPort = 11000;

    private readonly IServiceProvider _serviceProvider;

    public Worker(ILogger<Worker> logger, IServiceProvider serviceProvider)
    {
        _logger = logger;
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Sender running at: {time}", DateTimeOffset.Now);
        await Listener();
        await Task.Delay(1000, stoppingToken);
    }

    private async Task Listener()
    {
        using (UdpClient udpClient = new UdpClient(listenPort))
        {
            try
            {
                udpClient.Connect(IPAddress.Any, listenPort);

                Byte[] sendBytes = Encoding.ASCII.GetBytes("Is anybody there?");
                await udpClient.SendAsync(sendBytes, sendBytes.Length);

                Console.WriteLine("Sended the message" + sendBytes.ToString());

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
        }
    }
}