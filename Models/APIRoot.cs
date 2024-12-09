namespace PokemonFinder.Models
{
    public class PokemonRoot
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }
    public class APIRoot
    {
        public int Count { get; set; }
        public List<PokemonRoot> Results { get; set; }
    }


}
