using Microsoft.EntityFrameworkCore;

namespace PokemonFinder.Models
{
	public class PokemonContext
		(DbContextOptions<PokemonContext> options) : DbContext(options)
	{
		public DbSet<DBPokemon> DBPokemon { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			
			modelBuilder.Entity<DBPokemon>(eb =>
			{
				eb.ToTable("Pokemon");

			});
		}
	}
}
