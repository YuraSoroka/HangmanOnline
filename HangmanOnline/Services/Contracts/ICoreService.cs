using HangmanOnline.Models.ViewModels;

namespace HangmanOnline.Services.Contracts
{
    public interface ICoreService
    {
        GameSession GetSession(string roomId);
    }
}
