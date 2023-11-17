using EFCoreRelationshipPractice.Data;
using EFCoreRelationshipPractice.DTOs;
using EFCoreRelationshipPractice.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreRelationshipPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TlouController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TlouController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<Character>> GetCharacterById(int id)
        {
            var character = await _context.Characters
                .Include(x => x.Backpack)
                .Include(x => x.Weapons)
                .Include(x => x.Factions)
                .FirstOrDefaultAsync(x => x.Id == id);

            return Ok(character);
        }

        [HttpPost]
        public async Task<ActionResult<List<Character>>> CreateCharacter(CharacterCreateDto request)
        {
            var newCharacter = new Character()
            {
                Name = request.Name,
            };

            var backpack = new Backpack()
            {
                Description = request.Backpack.Description,
                //Character = newCharacter
            };

            var weapons = request.Weapons.Select(x => new Weapon() { Name = x.Name }).ToList();
            var factions = request.Factions.Select(x => new Faction() { Name = x.Name }).ToList();

            newCharacter.Backpack = backpack;
            newCharacter.Weapons = weapons;
            newCharacter.Factions = factions;

            _context.Characters.Add(newCharacter);
            await _context.SaveChangesAsync();

            return Ok(await _context.Characters.Include(x => x.Backpack).Include(x => x.Weapons).Include(x => x.Factions).ToListAsync());
        }
    }
}
