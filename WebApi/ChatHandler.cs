using System.Dynamic;
using System.Threading.Tasks;
using WebSocketManager;

namespace WebApi
{
    public class ChatHandler : WebSocketHandler
    {
        public ChatHandler(WebSocketConnectionManager webSocketConnectionManager) : base(webSocketConnectionManager)
        {
            
        }

        public async Task Connected(string username, string room, string message)
        {
            await InvokeClientMethodToAllAsync("pingConnected", username, room, message);
        }
        public async Task SendMessage(string username, string room, string message)
        {
            await InvokeClientMethodToAllAsync("pingMessage", username, room, message);
        }
    }
}
