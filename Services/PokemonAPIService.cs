using PokemonFinder.Models;

namespace PokemonFinder.Services
{
    public class StringsNumbers
    {
        public int Number { get; set; }
        public string Word { get; set; }
        public StringsNumbers(int number, string word)
        {
            Number = number;
            Word = word;
        }
    }
    public class PokemonAPIService
    {
        private readonly HttpClient httpClient;

        public PokemonAPIService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
            httpClient.BaseAddress = new Uri("https://pokeapi-proxy.freecodecamp.rocks/");
        }
        public async Task GetAllPokemon()
        {
            var result = await httpClient.GetAsync("api/pokemon");
            var result2 = await result.Content.ReadFromJsonAsync<APIRoot>();
        }
        public async Task<Pokemon> GetAPokemon(string identifier)
        {
            var result = await httpClient.GetAsync($"api/pokemon/{identifier}");
            if (result.IsSuccessStatusCode)
            {
                Pokemon result2 = await result.Content.ReadFromJsonAsync<Pokemon>();
                return result2;
            }
            else { return null; }
        }
        public async Task DownloadPokemon()
        {
            //1. Create an empty List of <Pokemon>
            //2. Call the API everytime from 1- 100 
            //2.5. with result of API call, make that into a Pokemon Obj
            //3. Add new Pokemon Obj to Empty List.

            List<Pokemon> Pokemon = new List<Pokemon>();

            for (int i = 1; i < 101; i++)
            {
                var result = await httpClient.GetAsync($"api/pokemon/{i}");
                Pokemon result2 = await result.Content.ReadFromJsonAsync<Pokemon>();
                Pokemon.Add(result2);
            }
            


        }
    }
}
