using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PokemonFinder.Models;
using PokemonFinder.Services;

namespace PokemonFinder.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly PokemonAPIService service;

        public IndexModel(ILogger<IndexModel> logger, PokemonAPIService service)
        {
            _logger = logger;
            this.service = service;
        }
        [BindProperty]
        public string SearchedID { get; set; }
        public Pokemon Pokemon { get; set; }
        public bool IsShiny { get; set; } 
        public async Task OnGet()
        {
            //await service.GetAllPokemon();
            //await service.GetAPokemon("5");
        }
        public async Task OnPost()
        {
            await GetData();
        }
        public async Task OnPostShiny()
        {
            await GetData();
            IsShiny = !IsShiny;
        }
        public async Task<IActionResult> OnPostNext()
        {

            SearchedID = SearchedID + 1;
            await GetData();
            return Page();
            
        }
        public async Task GetData()
        {
            var pokemon = await service.GetAPokemon(SearchedID.ToLower());
            Pokemon = pokemon;
        }
    }
}
