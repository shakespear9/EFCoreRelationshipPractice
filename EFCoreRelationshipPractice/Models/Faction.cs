namespace EFCoreRelationshipPractice.Models
{
    public class Faction
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public List<Character> Characters { get; set; }

    }
}
