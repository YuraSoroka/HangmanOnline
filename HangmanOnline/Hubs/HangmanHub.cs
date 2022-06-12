using HangmanOnline.Models.ViewModels;
using Microsoft.AspNetCore.SignalR;

namespace HangmanOnline.Hubs
{
    public class HangmanHub : Hub
    {
        public async Task UpdateSessionToOthers(GameSession gameSession)
        {
            await Clients.All.SendAsync("RenderScene", gameSession);
        }
    }
}