using Microsoft.AspNetCore.SignalR;

namespace chat.Classe
{
    public class MessageHub : Hub
    {
        public Task SendMessage(string user, string message) 
        {
            return Clients.All.SendAsync("ReceiveMessage",user, message);
        }
        public Task SendToCaller(string user, string message) 
        {
            return Clients.Caller.SendAsync("ReceiveMessage",user,message);
        } 

        public Task SendToUser(string connectionId, string user, string message) 
        {
            return Clients.Client(connectionId).SendAsync("ReceiveMessage",user,message);
        }

        public override async Task OnConnectedAsync() 
        {
           await Clients.All.SendAsync("UserConnected",Context.ConnectionId);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception ex) 
        {
            await Clients.All.SendAsync("UserDisconnected", Context.ConnectionId);
            await base.OnDisconnectedAsync(ex);
        }
    }
}
