using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_dotnet.Data;
using Project_dotnet.Models;
using Project_dotnet.Services;
using System;
using System.Linq;
using System.Security.Claims;

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

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterUser user)
        {
            var gebruiker = new Gebruiker();

            gebruiker.UserName = user.UserName;
            gebruiker.PasswordHash = user.Password;
            gebruiker.Voornaam = user.Voornaam;
            gebruiker.Achternaam = user.Achternaam;

            _context.Gebruikers.Add(gebruiker);

            _context.SaveChanges();

            return Ok(gebruiker);
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginUser user)
        {
            var gebruiker = _context.Gebruikers.SingleOrDefault(g => g.UserName == user.UserName && g.PasswordHash == user.Password);

            if (gebruiker == null)
                return NotFound();

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, gebruiker.Id.ToString())
            };
            var token = _userService.Authenticate(gebruiker).Token;

            return Ok(gebruiker);
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
        [HttpPost("FindFirst")]
        public IActionResult FindFirst(string id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return Ok(userId);
        }
    }

    public class RegisterUser {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
    } 

    public class LoginUser
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
