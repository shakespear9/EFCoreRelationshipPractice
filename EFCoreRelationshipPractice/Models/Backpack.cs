namespace EFCoreRelationshipPractice.Models
{
    public class Backpack
    {
        public int Id { get; set; }
        public String Description { get; set; }

        // one to one relationship
        public int CharacterId { get; set; }
        public Character Character { get; set; }
    }
}
