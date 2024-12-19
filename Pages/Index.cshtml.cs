using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PokemonFinder.Models;
using PokemonFinder.Services;
using System.Security.Cryptography.X509Certificates;

namespace PokemonFinder.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly PokemonAPIService service;
        private readonly SessionService sessionService;
		private readonly PokemonService dBService;

		public IndexModel(ILogger<IndexModel> logger, PokemonAPIService service, SessionService sessionService, PokemonService DBService)
        {
            _logger = logger;
            this.service = service;
            this.sessionService = sessionService;
			this.dBService = DBService;
		}
        [BindProperty]
        public string SearchedID { get; set; }
        public Pokemon Pokemon { get; set; }
        public bool IsShiny { get; set; } 
        public bool Error { get; set; }
        public DBPokemon SelectedPokemon { get; set; }
        public async Task OnGet()
        {
            //await sessionService.SaveItem("Potato", "Fishy");
            //await service.GetAllPokemon();
            //await service.GetAPokemon("5");

            string Horse = "horse";
            string Dog = "dog";

            Console.WriteLine(string.Join(" , , , , ", Horse, Dog));
            //List<DBPokemon> NewPokemons = await dBService.ReturnPokemonList();
            


        }
        public async Task OnPost()
        {
            await GetData();
            //var test = await sessionService.GetItem<string>("Fishy");
            sessionService.ClearSessionData();
            await sessionService.SaveItem(Pokemon, "CachedPokemon");
            await sessionService.SaveItem(SelectedPokemon, "CachedPokemon2");

        }
        public async Task OnPostDownload()
        {
            Console.WriteLine("It works?");
            await service.DownloadPokemon();
        }

        public async Task OnPostRandom()
        {
            Pokemon = await sessionService.GetItem<Pokemon>("CachedPokemon");
            Pokemon = await sessionService.GetItem<Pokemon>("CachedPokemon2");
            Random random = new Random();
            //int rando1 = random.Next(1, 1026);
            int rando1 = random.Next(1, 101);
            SearchedID = $"{rando1}";
            await GetData();
            await sessionService.SaveItem(Pokemon, "CachedPokemon");
            await sessionService.SaveItem(SelectedPokemon, "CachedPokemon2");
            List<DBPokemon> NewPokemons = await dBService.ReturnPokemonList();
        }

        public async Task OnPostShiny()
        {
            IsShiny = await sessionService.GetItem<bool>("CachedShiny");
            IsShiny = !IsShiny;
            await sessionService.SaveItem(IsShiny, "CachedShiny");
            Pokemon = await sessionService.GetItem<Pokemon>("CachedPokemon");
        }
        public async Task OnPostNext()
        {
            
            Pokemon = await sessionService.GetItem<Pokemon>("CachedPokemon");
            Pokemon = await sessionService.GetItem<Pokemon>("CachedPokemon2");
            var PokeId = Pokemon.Id;
            PokeId++;
            if(PokeId >= 1026)
            {
                PokeId = 1;
            }
            SearchedID = PokeId.ToString();
            List<DBPokemon> NewPokemons = await dBService.ReturnPokemonList();
            await GetData();
            await sessionService.SaveItem(Pokemon, "CachedPokemon");
            await sessionService.SaveItem(SelectedPokemon, "CachedPokemon2");
            await sessionService.ClearItem("CachedShiny");
        }

        public async Task OnPostPrevious()
        {
            Pokemon = await sessionService.GetItem<Pokemon>("CachedPokemon");
            Pokemon = await sessionService.GetItem<Pokemon>("CachedPokemon2");
            var PokeId = Pokemon.Id;
            PokeId--;
            if(PokeId <= 0)
            {
                PokeId = 1025;
            }
            SearchedID = PokeId.ToString();
            List<DBPokemon> NewPokemons = await dBService.ReturnPokemonList();
            await GetData();
            await sessionService.SaveItem(Pokemon, "CachedPokemon");
            await sessionService.SaveItem(SelectedPokemon, "CachedPokemon2");
            await sessionService.ClearItem("CachedShiny");
        }
        public async Task GetData()
        {
            
            var pokemon = await service.GetAPokemon(SearchedID.ToLower());
            if (pokemon != null)
            {
                Pokemon = pokemon;
            }
            else {
                Error = true;
            }
            List<DBPokemon> NewPokemons = await dBService.ReturnPokemonList();
            if (SearchedID != null)
            {
                SelectedPokemon = NewPokemons.Where(e => e.Id == int.Parse(SearchedID)).First();
            }
            else
            {
                Error = true;
            }

            //await sessionService.GetItem<Pokemon>("CachedPokemon");
        }

        
    }
}
