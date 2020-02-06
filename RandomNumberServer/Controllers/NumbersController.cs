using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using RandomNumberServer.Hubs;

namespace RandomNumberServer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NumbersController : ControllerBase
    {
        private readonly IHubContext<NumbersBroadcastHub> _context;

        public NumbersController(IHubContext<NumbersBroadcastHub> context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> PublishLocation([FromBody] object obj)
        {
            await _context.Clients.All.SendAsync("PublishLocation", obj).ConfigureAwait(false);
            return Ok(obj);
        }
    }
}