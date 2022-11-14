using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Web.Models;
using Domain;
using UDPClientService;
using Microsoft.Extensions.Hosting;
using UDPServerService;

namespace Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;
    private readonly ClientService _client;
    private readonly ServerService _server;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, ClientService client, ServerService server)
    {
        _logger = logger;
        _context = context;
        _client = client;
        _server = server;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult GetIP()
    {
        return Ok(_context.Clients.Count());
    }

    public async Task<IActionResult> Start()
    {
        await _client.StartAsync(default);
        await _server.StartAsync(default);

        return Ok();
    }

    public async Task<IActionResult> Stop()
    {
        await _client.StopAsync(default);
        await _server.StopAsync(default);

        return Ok();
    }
}

