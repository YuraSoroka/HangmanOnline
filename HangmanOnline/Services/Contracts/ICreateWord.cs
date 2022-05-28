namespace HangmanOnline.Services.Contracts
{
    public interface ICreateWord
    {
        Task<string> GetWord();
    }
}
