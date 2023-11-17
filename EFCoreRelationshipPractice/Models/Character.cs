namespace EFCoreRelationshipPractice.Models
{
    public class Character
    {
        public int Id { get; set; }
        public String Name { get; set; }

        // one to one relationship
        public Backpack Backpack { get; set; }
        public List<Weapon> Weapons { get; set; }
        public List<Faction> Factions { get; set; }
    }
}
