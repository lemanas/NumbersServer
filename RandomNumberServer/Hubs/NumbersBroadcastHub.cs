using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace RandomNumberServer.Hubs
{
    public class NumbersBroadcastHub : Hub
    {
        public const string PublishEventName = "PublishLocation";

        public Task BroadcastLocation(object obj)
        {
            return Clients.All.SendAsync(PublishEventName, obj);
        }
    }
}