using HangmanOnline.Models;
using HangmanOnline.Models.Context;
using HangmanOnline.Services.Contracts;

namespace HangmanOnline.Services
{
    public class RoomService : IRoomService
    {
        private readonly HangmanContext context;
        private readonly HttpClient httpClient;
        public RoomService(HangmanContext context, HttpClient httpClient)
        {
            this.context = context;
            this.httpClient = httpClient;
        }

        public bool AddRoom(Guid roomId, string playerName)
        {
            string id = roomId.ToString();

            if (!context.Rooms.Any(room => room.Id == id))
            {
                Room room = new Room
                {
                    Id = roomId.ToString(),
                    Word = new CreateWordService(httpClient).GetWord().Result,
                    PlayerOne = new Player
                    {
                        Health = 5,
                        Name = playerName
                    }
                };
                context.Rooms.Add(room);
            }
            else
            {
                if (CheckIfRoomIsFull(id))
                    return false;
                Room existingRoom = context.Rooms.Single(room => room.Id == id);
                existingRoom.PlayerTwo = new Player
                {
                    Name = playerName,
                    Health = 5
                };
            }
            context.SaveChanges();
            return true;
        }

        private bool CheckIfRoomIsFull(string roomId)
        {
            var result = context.Rooms.Where(room => room.Id == roomId)
                .Join(context.Players,
                rooms => rooms.PlayerTwo.Id,
                players => players.Id,
                (rooms, players) => new Player
                {
                    Id = players.Id,
                    Health = players.Health,
                    Name = players.Name
                })
                .FirstOrDefault();

            if(result is null)
            {
                return false;
            }
            return true;
        }
    }
}