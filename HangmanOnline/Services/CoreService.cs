using HangmanOnline.Models;
using HangmanOnline.Models.Context;
using HangmanOnline.Models.ViewModels;
using HangmanOnline.Services.Contracts;

namespace HangmanOnline.Services
{
    public class CoreService : ICoreService
    {
        private readonly HangmanContext context;
        public CoreService(HangmanContext context)
        {
            this.context = context;

        }
        public GameSession GetSession(string roomId)
        {
            Room currentRoom = context.Rooms.First(room => room.Id == roomId);
            string word = currentRoom.Word;
            string firstPlayerName = currentRoom.PlayerOne?.Name ?? String.Empty;
            byte firstPlayerHearts = currentRoom.PlayerOne?.Health ?? 0;
            string secondPlayerName = currentRoom.PlayerTwo?.Name ?? String.Empty;
            byte secondPlayerHearts = currentRoom.PlayerTwo?.Health ?? 0;
            return new GameSession
            {
                Word = word,
                FirstPlayerName = firstPlayerName,
                FirstPlayerHearts = firstPlayerHearts,
                SecondPlayerName = secondPlayerName,
                SecondPlayerHearts = secondPlayerHearts,
            };
        }
    }
}
