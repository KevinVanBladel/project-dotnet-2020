using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Project_dotnet.Data;
using Project_dotnet.Models;

namespace Project_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WedstrijdController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WedstrijdController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult GetWedstrijd([FromRoute] int id)
        {
            var wedstrijd = _context.Wedstrijden.Find(id);

            if (wedstrijd == null)
                return NotFound();

            return Ok(wedstrijd);
        }

        [HttpGet]
        public IActionResult GetWedstrijd()
        {
            var wedstrijden = _context.Wedstrijden.ToList();
            return Ok(wedstrijden);
        }

        [HttpPost]
        public IActionResult AddWedstrijd([FromBody] Wedstrijd wedstrijd)
        {
            _context.Wedstrijden.Add(wedstrijd);

            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteWedstrijd([FromRoute] int id)
        {
            var wedstrijd = _context.Wedstrijden.Find(id);

            if (wedstrijd == null)
                return NotFound("Wedstrijd met id '" + id + "' niet gevonden.");

            _context.Wedstrijden.Remove(wedstrijd);
            _context.SaveChanges();

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateWedstrijd([FromRoute] int id, [FromBody] Wedstrijd wedstrijd)
        {
            var wedstrijdToUpdate = _context.Wedstrijden.Find(id);

            if (wedstrijdToUpdate == null)
                return NotFound("Wedstrijd met id '" + id + "' niet gevonden.");

            wedstrijdToUpdate.updateWedstrijd(wedstrijd);

            /*if (false)
                return BadRequest("Wedstrijd met id...");*/

            _context.SaveChanges();

            return Ok();
        }
    }
}
