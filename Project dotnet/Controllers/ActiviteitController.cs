using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_dotnet.Data;
using Project_dotnet.Models;
using System.Collections.Generic;
using System.Linq;

namespace Project_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActiviteitController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ActiviteitController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult GetActiviteit([FromRoute] int id)
        {
            var activiteit = _context.Activiteiten
                .Include(a => a.Wedstrijden)
                .Include(a => a.Trainingen)
                .SingleOrDefault(a => a.Id == id);

            if (activiteit == null)
                return NotFound();

            return Ok(activiteit);
        }

        [HttpGet]
        public IActionResult GetActiviteiten()
        {
            var activiteiten = _context.Activiteiten
                .Include(a => a.Wedstrijden)
                .Include(a => a.Trainingen)
                .ToList();

            return Ok(activiteiten);
        }

        [HttpPost]
        public IActionResult AddActiviteit([FromBody] Activiteit activiteit)
        {
            _context.Activiteiten.Add(activiteit);

            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteActiviteit([FromRoute] int id)
        {
            var activiteit = _context.Activiteiten.Find(id);

            if (activiteit == null)
                return NotFound("Activiteit met id '" + id + "' niet gevonden.");

            _context.Activiteiten.Remove(activiteit);
            _context.SaveChanges();

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateActiviteit([FromRoute] int id, [FromBody] Activiteit activiteit)
        {
            var activiteitToUpdate = _context.Activiteiten.Find(id);

            if (activiteitToUpdate == null)
                return NotFound("Activiteit met id '" + id + "' niet gevonden.");

            activiteitToUpdate.updateActiviteit(activiteit);

            _context.SaveChanges();

            return Ok();
        }
    }
}
