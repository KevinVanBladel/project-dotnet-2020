using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project_dotnet.Data;
using Project_dotnet.Extensions;
using Project_dotnet.Models;

namespace Project_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TrainingController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet("{id}")]
        public IActionResult GetTraining([FromRoute] int id)
        {
            var training = _context.Trainingen.Find(id);

            if (training == null)
                return NotFound();

            return Ok(training);
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetTrainingen()
        {
            var trainingen = _context.Trainingen.ToList();
            return Ok(trainingen);
        }

        [HttpPost]
        public IActionResult AddTraining([FromBody] Training training)
        {
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

            if (trainingToUpdate == null)
                return NotFound("Training met id '" + id + "' niet gevonden.");

            trainingToUpdate.updateTraining(training);

            /*if (false)
                return BadRequest("Activiteit met id...");*/

            _context.SaveChanges();

            return Ok();
        }
    }
}
