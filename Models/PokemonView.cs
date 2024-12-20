namespace PokemonFinder.Models
{
    public class PokemonView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Back_default { get; set; }
        public string Back_shiny { get; set; }
        public string Front_default { get; set; }
        public string Front_shiny { get; set; }
        public int HP { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Special_attack { get; set; }
        public int Special_defense { get; set; }
        public int Speed { get; set; }
        //public List<string> Type { get; set; }

        
        //public PokemonView(int id, string name, string back_d, string back_s, string front_d, string front_s, int hp, int att, int def, int special_att, int special_def, int speed)
        //{
        //    Id = id;
        //    Name = name;
        //    Back_default = back_d;
        //    Back_shiny = back_s;
        //    Front_default = front_d;
        //    Front_shiny = front_s;
        //    HP = hp;
        //    Attack = att;
        //    Defense = def;
        //    Special_attack = special_att;
        //    Special_defense = special_def;
        //    Speed = speed;
        //    //Type = type;

        //}
    }
}
