namespace PokemonFinder.Models
{
    public class DBPokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Back_default {  get; set; }
        public string Back_shiny { get; set; }
        public string Front_default { get; set; }
        public string Front_shiny { get; set; }
        public int HP { get; set; }
        public int Attack { get; set; }
        public int Defence { get; set; }
        public int Special_attack { get; set; }
        public int Special_defence { get; set; }
        public int Speed { get; set; }
        public List<string> Type { get; set; }

        public DBPokemon(int id, string name, string back_d, string back_s, string front_d, string front_s, int hp, int att, int def, int special_att, int special_def, int speed, List<string> type)
        {
            Id = id;
            Name = name;
            Back_default = back_d;
            Back_shiny = back_s;
            Front_default = front_d;
            Front_shiny = front_s;
            HP = hp;
            Attack = att;
            Defence = def;
            Special_attack = special_att;
            Special_defence = special_def;
            Speed = speed;
            Type = type;
        }
    }
}
