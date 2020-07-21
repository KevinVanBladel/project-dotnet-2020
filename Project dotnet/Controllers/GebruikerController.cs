using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project_dotnet.Data;
using Project_dotnet.Models;
using Project_dotnet.Services;
using System.Linq;

namespace Project_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GebruikerController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserService _userService;

        public GebruikerController(ApplicationDbContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Register([FromBody] RegisterUser user)
        {
            var gebruiker = new Gebruiker();

            gebruiker.UserName = user.UserName;
            //Nog niet gehashed
            gebruiker.PasswordHash = user.Password;
            gebruiker.Voornaam = user.FirstName;
            gebruiker.Achternaam = user.LastName;

            _context.Gebruikers.Add(gebruiker);

            _context.SaveChanges();

            return Ok();
        }

        [HttpGet]
        public IActionResult Login([FromBody] LoginUser user)
        {
            var gebruiker = _context.Gebruikers.SingleOrDefault(g => g.UserName == user.UserName && g.PasswordHash == user.Password);

            if (gebruiker == null)
                return NotFound();

            var token = _userService.Authenticate(gebruiker).Token;

            return Ok(token);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGebruiker([FromRoute] string id)
        {
            var gebruiker = _context.Gebruikers.Find(id);

            if (gebruiker == null)
                return NotFound("Gebruiker met id '" + id + "' niet gevonden.");

            _context.Gebruikers.Remove(gebruiker);
            _context.SaveChanges();

            return Ok();
        }
    }

    public class RegisterUser {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    } 

    public class LoginUser
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
