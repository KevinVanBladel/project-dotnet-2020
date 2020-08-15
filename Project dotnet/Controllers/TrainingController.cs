using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project_dotnet.Data;
using Project_dotnet.Extensions;
using Project_dotnet.Models;

namespace Project_dotnet.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TrainingController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetTraining([FromRoute] int id)
        {
            var training = _context.Trainingen.Find(id);

            if (training == null)
                return NotFound();

            if (training.GebruikerId != User.GetUserId())
                return Unauthorized();

            return Ok(training);
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetTrainingen()
        {
            var trainingen = _context.Trainingen.Where(t => t.GebruikerId == User.GetUserId());
            return Ok(trainingen);
        }

        [HttpPost]
        public IActionResult AddTraining([FromBody] Training training)
        {
            training.GebruikerId = User.GetUserId();

            _context.Trainingen.Add(training);

            _context.SaveChanges();

            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteTraining([FromRoute] int id)
        {
            var training = _context.Trainingen.Find(id);
            if (training == null)
                return NotFound("Training met id '" + id + "' niet gevonden.");

            _context.Trainingen.Remove(training);
            _context.SaveChanges();

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTraining([FromRoute] int id, [FromBody] Training training)
        {
            var trainingToUpdate = _context.Trainingen.Find(id);
            training.GebruikerId = User.GetUserId();

            if (trainingToUpdate == null)
                return NotFound("Training met id '" + id + "' niet gevonden.");


            trainingToUpdate.updateTraining(training);

            _context.SaveChanges();

            return Ok();
        }
    }
}
