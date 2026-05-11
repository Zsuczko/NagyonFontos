using CinemApi.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemApi.Controllers
{
    [ApiController]
    [Route("api/film")]
    public class FilmController : Controller
    {
        private readonly FilmDbContext _context;

        public FilmController(FilmDbContext context) {
            _context = context;
        }


        [HttpGet("")]
        public async Task<IActionResult> GetFilms() {

            var allFilm = _context.Films.Include(x => x.Rendezo).Select(x=>new { x.Id, x.Cim, x.Mufaj, x.Ev, x.Rendezo.Nev }).ToList();


            return Ok(allFilm);
        }
        public record FilmDto();

        [HttpPost("")]
        public async Task<IActionResult> PostFilms([FromBody]FilmDto body)
        {
            return Ok();
        }
    }
}
