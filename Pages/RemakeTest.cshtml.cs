using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PokemonFinder.Models;
using PokemonFinder.Services;

namespace PokemonFinder.Pages
{

    public class RemakeTestModel : PageModel
    {
        private readonly PokemonAPIService service;
        private readonly PokemonService dBService;
        private readonly SessionService sessionService;

        public RemakeTestModel(PokemonAPIService service, PokemonService dBService, SessionService sessionService) 
        {
            this.service = service;
            this.dBService = dBService;
            this.sessionService = sessionService;
        }
        [BindProperty]
        public string SearchedId { get; set; }
        public PokemonView SelectedPokemon { get; set; }
    


        public void OnGet()
        {

        }
        public async Task OnPost()
        {
            await GetData();
        }
        public async Task GetData()
        {
            //var pokemon = await service.GetAPokemon(SearchedId.ToLower());
            //SelectedPokemon = new PokemonView() { Id = pokemon.Id, Name = pokemon.Name, Back_default = pokemon.Sprites.Back_default, Back_shiny = pokemon.Sprites.Back_shiny, Front_default = pokemon.Sprites.Front_default, Front_shiny = pokemon.Sprites.Front_shiny, HP = pokemon.Stats.Where(e => e.Stat.Name == "hp").Select(e => e.Base_stat).First(), Attack = pokemon.Stats.Where(e => e.Stat.Name == "attack").Select(e => e.Base_stat).First(), Defense = pokemon.Stats.Where(e => e.Stat.Name == "defense").Select(e => e.Base_stat).First(), Special_attack = pokemon.Stats.Where(e => e.Stat.Name == "special-attack").Select(e => e.Base_stat).First(), Special_defense = pokemon.Stats.Where(e => e.Stat.Name == "special-defense").Select(e => e.Base_stat).First(), Speed = pokemon.Stats.Where(e => e.Stat.Name == "speed").Select(e => e.Base_stat).First() };

            List<DBPokemon> pokemon = await dBService.ReturnPokemonList();
            var chosenPokemon = pokemon.Where(e => e.Id == int.Parse(SearchedId)).First();
            SelectedPokemon = new PokemonView() { Id = chosenPokemon.Id, Name = chosenPokemon.Name, Back_default = chosenPokemon.Back_default, Back_shiny = chosenPokemon.Back_shiny, Front_default = chosenPokemon.Front_default, Front_shiny = chosenPokemon.Front_shiny, HP = chosenPokemon.HP, Attack = chosenPokemon.Attack, Defense = chosenPokemon.Defense, Special_attack = chosenPokemon.Special_attack, Special_defense = chosenPokemon.Special_defense, Speed = chosenPokemon.Speed };
        }
    }
}
