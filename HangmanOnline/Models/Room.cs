namespace HangmanOnline.Models
{
    public class Room
    {
        public string Id { get; set; }
        public string Word { get; set; }

        public Room(string id, string word)
        {
            Id = id;
            Word = word;
         }
    }
}
