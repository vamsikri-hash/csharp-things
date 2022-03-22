using System.Threading.Tasks;
using WSocket.Models;
using Microsoft.AspNetCore.SignalR;

namespace WSocket.Hubs

{
    public interface IChatClient
    {
        Task ReceiveMessage(ChatMessage message);
    }
    public class ChatHub : Hub<IChatClient>
    {
        public async Task SendMessage(ChatMessage message)
        {
            //  await Clients.All.SendAsync("ReceiveMessage", message); - normal
            await Clients.All.ReceiveMessage(message); // strongly typed
        }
    }
}