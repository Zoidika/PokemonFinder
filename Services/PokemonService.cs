using Microsoft.EntityFrameworkCore;
using PokemonFinder.Models;

namespace PokemonFinder.Services
{
	public class PokemonService
	{
		private readonly PokemonContext dbContext;

		public PokemonService(PokemonContext dbContext)
		{
			this.dbContext = dbContext;
		}
		public async Task<List<DBPokemon>> ReturnPokemonList()
		{
			return await dbContext.DBPokemon.ToListAsync();
		}
		public async Task FillDataBase(List<DBPokemon> pokemon)
		{
			await dbContext.DBPokemon.AddRangeAsync(pokemon);
			await dbContext.SaveChangesAsync();
		}
	}
}
