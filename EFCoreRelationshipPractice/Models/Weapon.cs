namespace EFCoreRelationshipPractice.Models
{
    public class Weapon
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public int CharacterId { get; set; }
        public Character Character { get; set; }
    }
}
