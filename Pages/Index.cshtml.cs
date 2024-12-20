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
        
        public bool IsShiny { get; set; } 
        public bool Error { get; set; }
        public PokemonView SelectedPokemon { get; set; }
        [BindProperty]
        public bool UsingAPI { get; set; } = true;
        public async Task OnGet()
        {
            
        }
        public async Task OnPost()
        {
            await GetData();
            sessionService.ClearSessionData();
            
            
            await sessionService.SaveItem(SelectedPokemon, "CachedPokemon");
            var Donkey = await sessionService.GetItem<PokemonView>("CachedPokemon");

            


        }
        public async Task OnPostDownload()
        {
            Console.WriteLine("It works?");
            await service.DownloadPokemon();
        }

        public async Task OnPostRandom()
        {
            if (UsingAPI == true)
            {
                SelectedPokemon = await sessionService.GetItem<PokemonView>("CachedPokemon");
                Random random = new Random();
                int rando1 = random.Next(1, 1026);
                SearchedID = $"{rando1}";
                await GetData();
                await sessionService.SaveItem(SelectedPokemon, "CachedPokemon");
                await sessionService.ClearItem("CachedShiny");
            }
            else
            {
                SelectedPokemon = await sessionService.GetItem<PokemonView>("CachedPokemon");
                Random random = new Random();
                int rando1 = random.Next(1, 100);
                SearchedID = $"{rando1}";
                await GetData();
                await sessionService.SaveItem(SelectedPokemon, "CachedPokemon");
                await sessionService.ClearItem("CachedShiny");
            }
        }

        public async Task OnPostShiny()
        {
            IsShiny = await sessionService.GetItem<bool>("CachedShiny");
            IsShiny = !IsShiny;
            await sessionService.SaveItem(IsShiny, "CachedShiny");
            SelectedPokemon = await sessionService.GetItem<PokemonView>("CachedPokemon");
        }
        public async Task OnPostNext()
        {
            if (UsingAPI == true)
            {
                SelectedPokemon = await sessionService.GetItem<PokemonView>("CachedPokemon");
                var PokeId = SelectedPokemon.Id;
                PokeId++;
                if (PokeId >= 1026)
                {
                    PokeId = 1;
                }
                SearchedID = PokeId.ToString();
                await GetData();
                await sessionService.SaveItem(SelectedPokemon, "CachedPokemon");
                await sessionService.ClearItem("CachedShiny");
            }
            else
            {
                SelectedPokemon = await sessionService.GetItem<PokemonView>("CachedPokemon");
                var PokeId = SelectedPokemon.Id;
                PokeId++;
                if (PokeId >= 101)
                {
                    PokeId = 1;
                }
                SearchedID = PokeId.ToString();
                await GetData();
                await sessionService.SaveItem(SelectedPokemon, "CachedPokemon");
                await sessionService.ClearItem("CachedShiny");
            }
        }

        public async Task OnPostPrevious()
        {
            if (UsingAPI == true)
            {
                SelectedPokemon = await sessionService.GetItem<PokemonView>("CachedPokemon");
                var PokeId = SelectedPokemon.Id;
                PokeId--;
                if (PokeId <= 0)
                {
                    PokeId = 1025;
                }
                SearchedID = PokeId.ToString();

                await GetData();
                await sessionService.SaveItem(SelectedPokemon, "CachedPokemon");
                await sessionService.ClearItem("CachedShiny");
            }
            else
            {
                SelectedPokemon = await sessionService.GetItem<PokemonView>("CachedPokemon");
                var PokeId = SelectedPokemon.Id;
                PokeId--;
                if (PokeId <= 0)
                {
                    PokeId = 100;
                }
                SearchedID = PokeId.ToString();

                await GetData();
                await sessionService.SaveItem(SelectedPokemon, "CachedPokemon");
                await sessionService.ClearItem("CachedShiny");
            }
        }
        public async Task GetData()
        {
            
            if (UsingAPI == true)
            {
                var pokemon = await service.GetAPokemon(SearchedID.ToLower());
                if (pokemon != null)
                {
                    SelectedPokemon = new PokemonView() { Id = pokemon.Id, Name = pokemon.Name, Back_default = pokemon.Sprites.Back_default, Back_shiny = pokemon.Sprites.Back_shiny, Front_default = pokemon.Sprites.Front_default, Front_shiny = pokemon.Sprites.Front_shiny, HP = pokemon.Stats.Where(e => e.Stat.Name == "hp").Select(e => e.Base_stat).First(), Attack = pokemon.Stats.Where(e => e.Stat.Name == "attack").Select(e => e.Base_stat).First(), Defense = pokemon.Stats.Where(e => e.Stat.Name == "defense").Select(e => e.Base_stat).First(), Special_attack = pokemon.Stats.Where(e => e.Stat.Name == "special-attack").Select(e => e.Base_stat).First(), Special_defense = pokemon.Stats.Where(e => e.Stat.Name == "special-defense").Select(e => e.Base_stat).First(), Speed = pokemon.Stats.Where(e => e.Stat.Name == "speed").Select(e => e.Base_stat).First() };
                }
                else
                {
                    Error = true;
                }
            }
            else
            {
                List<DBPokemon> NewPokemons = await dBService.ReturnPokemonList();
                if (SearchedID != null)
                {
                    var selectedPokemon = NewPokemons.Where(e => e.Id == int.Parse(SearchedID)).First();
                    SelectedPokemon = new PokemonView() { Id = selectedPokemon.Id, Name = selectedPokemon.Name, Back_default = selectedPokemon.Back_default, Back_shiny = selectedPokemon.Back_shiny, Front_default = selectedPokemon.Front_default, Front_shiny = selectedPokemon.Front_shiny, HP = selectedPokemon.HP, Attack = selectedPokemon.Attack, Defense = selectedPokemon.Defense, Special_attack = selectedPokemon.Special_attack, Special_defense = selectedPokemon.Special_defense, Speed = selectedPokemon.Speed };
                }
                else
                {
                    Error = true;
                }
            }
            
        }

        
    }
}
