namespace HangmanOnline.Services.Contracts
{
    public interface IRoomService
    {
        bool AddRoom(Guid roomId, string playerName);
    }
}
