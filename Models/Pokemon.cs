namespace PokemonFinder.Models
{
    public class Pokemon
    {
        public int Base_experience { get; set; }
        public int Height { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public PokemonSprites Sprites { get; set; }
        public List<Stats> Stats { get; set; }
    }
    public class PokemonSprites
    {
        public string Back_default { get; set; }
        public string Back_shiny { get; set; }
        public string Front_default { get; set; }
        public string Front_shiny { get; set; }
    }

    public class Stats
    {
        public int Base_stat { get; set; }
        public int Effort {  get; set; }
        public Stat Stat { get; set; }

    }
    public class Stat
    {
        public string Name { get; set; }
        public string url { get; set; }
    }

}
