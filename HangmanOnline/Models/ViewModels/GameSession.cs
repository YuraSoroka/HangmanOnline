namespace HangmanOnline.Models.ViewModels
{
    public class GameSession
    {
        public string Word { get; set; }
        public string FirstPlayerName { get; set; }
        public byte FirstPlayerHearts { get; set; }
        public string SecondPlayerName { get; set; }
        public byte SecondPlayerHearts { get; set; }
        // TODO: foreach for word, if letter exists - put it in box ( ajax )
        //public char Letter { get; set; }
    }
}
