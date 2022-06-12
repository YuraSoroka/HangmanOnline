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
                ContainsLetter = false,
                Letter = string.Empty
            };
        }

        public GameSession UpdateSession(string roomId , string guessedLetter)
        {
            Room currentRoom = context.Rooms.First(room => room.Id == roomId);
            bool contains = false;

            if (currentRoom.Word.Contains(guessedLetter))
            {
                contains = true;
            }
            return new GameSession
            {
                FirstPlayerName = currentRoom.PlayerOne.Name,
                FirstPlayerHearts = currentRoom.PlayerOne.Health,
                SecondPlayerName = currentRoom.PlayerTwo.Name,
                SecondPlayerHearts = currentRoom.PlayerTwo.Health,
                Word = currentRoom.Word,
                Letter = guessedLetter,
                ContainsLetter = contains
            };
        }
    }
}
