namespace EFCoreRelationshipPractice.DTOs
{
    public record struct CharacterCreateDto(String Name, BackpackCreateDto Backpack, List<WeaponCreateDto> Weapons, List<FactionCreateDto> Factions);

}
