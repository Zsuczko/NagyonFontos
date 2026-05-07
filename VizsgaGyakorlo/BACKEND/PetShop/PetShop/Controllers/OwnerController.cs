using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetShop.Classes;
using PetShop.Data;
using static PetShop.Controllers.PetController;

namespace PetShop.Controllers
{
    [ApiController]
    [Route("/api/owners")]
    public class OwnerController : Controller
    {
        private PetDbContext _context;

        public OwnerController(PetDbContext context)
        {
            _context = context;
        }
        public record OwnerListDTO(int Id,string FirstName, string LastName, string? PhoneNumber, string? Email);


        [HttpGet()]
        public async Task<IActionResult> GettingOwners([FromQuery]string? search)
        {
            if (String.IsNullOrEmpty(search)) {
                search = "";
            }

            var owners = _context.Owners.Where(o=>o.FirstName.Contains(search) || o.LastName.Contains(search));

            var showing = owners.OrderBy(o => o.LastName).ThenBy(o => o.FirstName)
                .Select(o => new OwnerListDTO
                (
                    o.Id,
                    o.FirstName,
                    o.LastName,
                    o.Email,
                    o.PhoneNumber
                )).ToList();

            return Ok(showing);
        }

        public record OwnerCreateDTO(string FirstName, string LastName, string? Phone, string? Email);

        [HttpPost()]
        public async Task<IActionResult> AddOwners([FromBody]OwnerCreateDTO dto) {

            try
            {

                _context.Owners.Add(new Owner
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Email = dto.Email,
                    PhoneNumber = dto.Phone
                });

                await _context.SaveChangesAsync();

                return Created();
            }
            catch(Exception ex) {
                return BadRequest(ex);
            }
        }
        public record OwnerListPetsDTO(int Id, string FirstName, string LastName, string? PhoneNumber, string? Email, List<PetShowing> Pets);


        [HttpGet("{id}")]
        public async Task<IActionResult> GettingOwnerById(int id) {

            var owner = _context.Owners.Include(o => o.Pets).FirstOrDefault(o=>o.Id == id);

            if (owner is null) return NotFound();

            return Ok(new OwnerListPetsDTO(
                owner.Id, owner.FirstName, owner.LastName, owner.PhoneNumber, owner.Email,
                owner.Pets.Select(p =>
                new PetShowing(p.Id, p.Name, p.Species, p.Breed, p.BirthYear)
                ).ToList()));
           
        }


    }
}
