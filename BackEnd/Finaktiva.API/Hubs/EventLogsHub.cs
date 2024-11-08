using Microsoft.AspNetCore.SignalR;

namespace Finaktiva.API.Hubs
{
    public class EventLogsHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }
    }
}
