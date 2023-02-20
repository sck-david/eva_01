using eva_webApp.Controllers.DTO;
using eva_webApp.Database;
using eva_webApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace eva_webApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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

        [Route("getAllWorkouts")]
        [HttpGet]
        public IEnumerable<Workout> GetWorkouts()
        {
            return _context.Workouts;
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

        [HttpGet("getStatistics/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> getStatistics(int userId)
        {
            var stats = _context.Statistics.Where(x => x.UserId == userId).ToList();
            if (stats is null)
            {
                return NotFound();
            }
            List<StatisticDTO> statsDTO = new List<StatisticDTO>();
            stats.ForEach(x => statsDTO.Add(new StatisticDTO(x.WorkoutId, _context.Workouts.FirstOrDefault(y => y.Id == x.WorkoutId).Name, x.Reps, x.Sets, x.Weight)));
            
            return Ok(statsDTO);
        }

        [HttpGet("getGoals/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> getGoals(int userId)
        {
            var goal = _context.Goals.Where(x=> x.UserId==userId).ToList();
            if (goal is null)
            {
                return NotFound();
            }
            List<GoalDTO> goalDTO = new List<GoalDTO>();
            goal.ForEach( y => goalDTO.Add(new GoalDTO(y.Name,y.Description,y.TargetDate)));
            return Ok(goalDTO);
        }

        [HttpGet("getBodyMeasurements/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> getBodyMeasurements(int userId)
        {
            var bm = _context.BodyMeasurements.FirstOrDefault(x => x.UserId == userId);
            if (bm is null)
            {
                return NotFound();
            }
            BmDTO bmDTO = new BmDTO(_context.Users.Find(userId).Username, bm.Weight,bm.Height,bm.BodyFatPercentage, bm.Date);
            return Ok(bmDTO);
        }


    }
}
