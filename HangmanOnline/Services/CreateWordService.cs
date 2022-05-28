using HangmanOnline.Services.Contracts;

namespace HangmanOnline.Services
{
    public class CreateWordService : ICreateWord
    {
        private HttpClient httpClient;
        private readonly string url = "https://random-word-api.herokuapp.com/word";

        public CreateWordService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<string> GetWord()
        {
            HttpResponseMessage result = await httpClient.GetAsync(url);
            if (!result.IsSuccessStatusCode)
            {
                return "SERVER ERROR";
            }
            string wordContent = await result.Content.ReadAsStringAsync();
            return PrettifyString(wordContent);
        }

        private string PrettifyString(string uglyString)
        {
            return uglyString.Substring(2, uglyString.Length - 4);
        }
    }
}
