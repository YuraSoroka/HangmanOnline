namespace HangmanOnline.Models.ViewModels
{
    public class GameSession
    {
        public string Word { get; set; }
        public string FirstPlayerName { get; set; }
        public byte FirstPlayerHearts { get; set; }
        public string SecondPlayerName { get; set; }
        public byte SecondPlayerHearts { get; set; }
        public string Letter { get; set; }
        public bool ContainsLetter { get; set; }
    }
}
