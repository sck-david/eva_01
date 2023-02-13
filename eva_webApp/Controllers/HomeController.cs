using eva_webApp.Controllers.DTO;
using eva_webApp.Database;
using eva_webApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace eva_webApp.Controllers
{
    [ApiController]
    [Route("")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly FitnessAppContext _context;

        public HomeController(ILogger<HomeController> logger, FitnessAppContext context)
        {
            _logger = logger;
            _context = context;
        }

        [Route("getAllUsers")]
        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            return _context.Users;
        }

        [HttpGet("getUser/{email}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUser(string email)
        {
            var user = _context.Users.FirstOrDefault(x => x.Email.Equals(email));
            if (user is null)
            {
                return NotFound();
            }
            UserDTO dto = new UserDTO(user.Username, user.Email, user.Password);

            return Ok(dto);
        }

        //[HttpGet("getStatistics/{userId}")]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDTO))]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<IActionResult> getStatistics(int userId)
        //{
        //    var stats = _context.Statistics.FirstOrDefault(x => x.UserId.Equals(userId));
        //    if (stats is null)
        //    {
        //        return NotFound();
        //    }
           
        //    return Ok(stats);
        //}
    }
}
