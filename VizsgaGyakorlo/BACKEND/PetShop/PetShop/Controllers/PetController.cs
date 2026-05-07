using Microsoft.AspNetCore.Mvc;
using PetShop.Classes;
using PetShop.Data;
using static PetShop.Controllers.OwnerController;

namespace PetShop.Controllers
{
    [ApiController]
    [Route("/api/pets")]
    public class PetController : Controller
    {
        private PetDbContext _context;

        public PetController(PetDbContext context) {
            _context = context;
        }

        public record PetShowing(int Id, string Name, string Species, string? Breed, int? BirtYear);

        [HttpGet()]
        public async Task<IActionResult> GettingPets([FromQuery] string? search, string? species)
        {
            if (String.IsNullOrEmpty(search))
            {
                search = "";
            }

            if (String.IsNullOrEmpty(species))
            {
                species = "";
            }

            var pets = _context.Pets.Where(o => o.Name.Contains(search) && o.Species.Contains(species));

            var showing = pets.OrderBy(o => o.Name)
                .Select(o => new PetShowing
                (
                    o.Id,
                    o.Name,
                    o.Species,
                    o.Breed,
                    o.BirthYear
                )).ToList();

            return Ok(showing);
        }

        public record PetAddDTO(string Name, string Species, string? Breed, int? BirthYear, int OwnerId);


        [HttpPost()]
        public async Task<IActionResult> AddingPets([FromBody]PetAddDTO dto) {

            if (dto.Species != "Kutya" && dto.Species != "Macska" && dto.Species != "Nyúl" && dto.Species != "Egyéb") return BadRequest("Nincs ilyen faj");

            var owner = _context.Owners.FirstOrDefault(o => o.Id == dto.OwnerId);
            if (owner is null) return NotFound($"Nem található a {dto.OwnerId} azonosítójú felhasználó");


            var pet = new Pet
            {
                Name = dto.Name,
                Species = dto.Species,
                Breed = dto.Breed,
                BirthYear = dto.BirthYear,
                OwnerId = dto.OwnerId
            };
            _context.Pets.Add(pet);
            await _context.SaveChangesAsync();

            return Created();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GettingPetsById(int id)
        {
            var pet = _context.Pets.FirstOrDefault(p => p.Id == id);

            if (pet is null) return NotFound();   

            return Ok(new PetShowing(pet.Id, pet.Name, pet.Species, pet.Breed, pet.BirthYear));
        }


    }
}
