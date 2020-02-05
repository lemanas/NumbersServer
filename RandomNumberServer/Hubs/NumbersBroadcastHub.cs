using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace RandomNumberServer.Hubs
{
    public class NumbersBroadcastHub : Hub
    {
        public const string PublishEventName = "PublishNumber";

        public Task BroadcastNumber(int senderId, int number)
        {
            return Clients.All.SendAsync(PublishEventName, senderId, number);
        }
    }
}