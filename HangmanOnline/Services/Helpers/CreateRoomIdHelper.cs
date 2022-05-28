namespace HangmanOnline.Services.Helpers
{
    public class CreateRoomIdHelper
    {
        public Guid CreateRoomID()
        {
            Guid roomId = Guid.NewGuid();
            return roomId;
        }
    }
}
