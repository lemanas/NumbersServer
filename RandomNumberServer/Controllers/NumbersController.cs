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

        [HttpGet("{senderId}/{number}")]
        public Task PublishNumber(int senderId, int number)
        {
            return _context.Clients.All.SendAsync("PublishNumber", senderId, number);
        }
    }
}