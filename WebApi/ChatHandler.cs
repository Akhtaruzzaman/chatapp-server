using Microsoft.AspNetCore.SignalR;
using System.Dynamic;
using System.Threading.Tasks;
using WebSocketManager;

namespace WebApi
{
    public class ChatHandler : Hub
    {
        public async Task SendMessage(string fromid, string toid, string message)
        {
            await Clients.All.SendAsync("SendMessage", fromid, toid, message);
        }
    }
}
