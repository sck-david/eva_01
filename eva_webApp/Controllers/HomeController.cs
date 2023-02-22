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
        public async Task<IActionResult> GetStatistics(int userId)
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
        public async Task<IActionResult> GetGoals(int userId)
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
        public async Task<IActionResult> GetBodyMeasurements(int userId)
        {
            var bm = _context.BodyMeasurements.FirstOrDefault(x => x.UserId == userId);
            if (bm is null)
            {
                return NotFound();
            }
            BmDTO bmDTO = new BmDTO(_context.Users.Find(userId).Username, bm.Weight,bm.Height,bm.BodyFatPercentage, bm.Date);
            return Ok(bmDTO);
        }

        [HttpPost("addUser")]
        public async Task<ActionResult<User>> AddUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUser), new { email = user.Email }, user.Id);
        }

        [HttpPost("addGoal")]
        public async Task<ActionResult<Goal>> AddGoal(Goal goal)
        {
            _context.Goals.Add(goal);
            await _context.SaveChangesAsync();
        
            return CreatedAtAction(nameof(GetGoals), new { userId = goal.UserId }, goal.Id);
        }

        [HttpPost("addBodyMeasurements")]
        public async Task<ActionResult<BodyMeasurement>> AddBodyMeasurements(BodyMeasurement bm)
        {
            _context.BodyMeasurements.Add(bm);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBodyMeasurements), new { userId = bm.UserId }, bm.Id);
        }

        [HttpPost("addStatistic")]
        public async Task<ActionResult<Statistic>> AddStatistic(Statistic st)
        {
            _context.Statistics.Add(st);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStatistics), new { userId = st.UserId }, st.Id);
        }

        [HttpPost("addWorkout")]
        public async Task<ActionResult<Statistic>> AddWorkout(Workout w)
        {
            _context.Workouts.Add(w);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetWorkouts), w.Id);
        }



        //deletes 

        [HttpDelete("DeleteUserById/{userId}"), ActionName("Delete")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            if (_context.Users == null)
            {
                return Problem("Entity set 'FitnessAppContext.Users'  is null.");
            }

            var user = await _context.Users.FindAsync(userId);
            if(user == null)
            {
                NotFound();
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return Ok("deleted: "+ user.Username);
        }

        [HttpDelete("DeleteUserByEmail/{email}"), ActionName("Delete")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteUser(string email)
        {
            if (_context.Users == null)
            {
                return Problem("Entity set 'FitnessAppContext.Users'  is null.");
            }

            var user = _context.Users.FirstOrDefault(x => x.Email.Equals(email));
            if (user == null)
            {
                NotFound();
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return Ok("deleted: " + user.Username);
        }

        [HttpDelete("DeleteGoal/{id}"), ActionName("Delete")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteGoal(int id)
        {
            if (_context.Goals == null)
            {
                return Problem("Entity set 'FitnessAppContext.Goals'  is null.");
            }

            var goal = await _context.Goals.FindAsync(id);
            if (goal == null)
            {
                NotFound();
            }
            _context.Goals.Remove(goal);
            await _context.SaveChangesAsync();
            return Ok("deleted: " + id);
        }

        [HttpDelete("DeleteStatistic/{id}"), ActionName("Delete")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteStatistic(int id)
        {
            if (_context.Statistics == null)
            {
                return Problem("Entity set 'FitnessAppContext.Statistics'  is null.");
            }

            var statistic = await _context.Statistics.FindAsync(id);
            if (statistic == null)
            {
                NotFound();
            }
            _context.Statistics.Remove(statistic);
            await _context.SaveChangesAsync();
            return Ok("deleted: " + id);
        }

        [HttpDelete("DeleteWorkout/{id}"), ActionName("Delete")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteWorkout(int id)
        {
            if (_context.Workouts == null)
            {
                return Problem("Entity set 'FitnessAppContext.Workouts'  is null.");
            }

            var w = await _context.Workouts.FindAsync(id);
            if (w == null)
            {
                NotFound();
            }
            _context.Workouts.Remove(w);
            await _context.SaveChangesAsync();
            return Ok("deleted: " + id);
        }

    }
}
