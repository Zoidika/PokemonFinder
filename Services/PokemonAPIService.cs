using PokemonFinder.Models;

namespace PokemonFinder.Services
{
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
            Pokemon result2 = await result.Content.ReadFromJsonAsync<Pokemon>();
            return result2;
        }
    }
}
