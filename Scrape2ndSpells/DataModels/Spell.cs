namespace Scrape2ndSpells.DataModels
{
    public class Spell
    {
        public string Name { get; set; }
        public string Class { get; set; }
        public string Spheres { get; set; }
        public int Level { get; set; }
        public string Range { get; set; }
        public string Save { get; set; }
        public string Components { get; set; }
        public string AoE { get; set; }
        public string CastingTime { get; set; }
        public string Duration { get; set; }
        public string Description { get; set; }

        public Spell()
        {

        }
    }
}
