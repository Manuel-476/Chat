using Microsoft.AspNetCore.SignalR;

namespace chat.Classe
{
    public class MessageHub : Hub
    {
        public Task SendMessage(string user, string message) 
        {
            return Clients.All.SendAsync("ReceiveMessage",user, message);
        }
    }
}
