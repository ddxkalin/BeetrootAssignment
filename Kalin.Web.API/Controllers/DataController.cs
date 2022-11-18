using Kalin.EntityframeworkCore.Context;
using Kalin.EntityframeworkCore.Models;
using Kalin.Web.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kalin.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DataController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> HttpPost(FilterModel filter)
        {
            DateTime? startDate = filter.StartDate ?? (filter.fetchAll.HasValue && filter.fetchAll.Value==true ? null : DateTime.UtcNow.AddDays(-30));
            DateTime? endDate =  filter.EndDate ?? (filter.fetchAll.HasValue && filter.fetchAll.Value == true ? null: DateTime.UtcNow);
            IQueryable<Request> requests = _context.Requests.Include(x => x.Message).AsQueryable();

            if (!string.IsNullOrEmpty(filter.IpAddress))
                requests = requests.Where(x => x.IpAddress.Contains(filter.IpAddress));
            if(filter.Port.HasValue)
                requests = requests.Where(x=> x.Port.HasValue && x.Port==filter.Port.Value);
            if(startDate.HasValue)
                requests = requests.Where(x => x.Date >= startDate);
            if(endDate.HasValue)
                requests = requests.Where(x => x.Date <= endDate);

            return Ok(await requests.ToListAsync());
        }
    }
}
