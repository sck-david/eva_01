using eva_webApp.Controllers.DTO;
using eva_webApp.Database;
using eva_webApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
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

        [Route("getAllStats")]
        [HttpGet]
        public IEnumerable<StatDTO> GetStats()
        {
            var stats = _context.Statistics;
            List<StatDTO> StatsDTO = new List<StatDTO>();
            stats.ForEachAsync(x=> StatsDTO.Add(new StatDTO(_context.Users.FirstOrDefault(y => y.Id == x.UserId).Username, _context.Workouts.FirstOrDefault(y => y.Id == x.WorkoutId).Name, (x.Sets*x.Weight*x.Reps))));
            return StatsDTO;
        }

        public record StatDTO( string username, string workoutname, int score );

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


        //Puts
        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser(User user)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            var existingUser =  _context.Users.Where(u => u.Id == user.Id).FirstOrDefault<User>();

                if (existingUser != null)
                {
                    existingUser.Email = user.Email;
                    existingUser.Username = user.Username;
                    existingUser.Password = user.Password;

                    _context.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            

            return Ok("Updated User with ID: "+user.Id);
        }

        [HttpPut("UpdateBodyMeasurement")]
        public async Task<IActionResult> UpdateBodyMeasurement(BodyMeasurement bm)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            var exBm = _context.BodyMeasurements.Where(x => x.Id == bm.Id).FirstOrDefault<BodyMeasurement>();

            if (exBm != null)
            {
                exBm.BodyFatPercentage = bm.BodyFatPercentage;
                exBm.Weight = bm.Weight;
                exBm.Date = DateTime.Now;
                exBm.Height = bm.Height;

                _context.SaveChanges();
            }
            else
            {
                return NotFound();
            }


            return Ok("Updated BodyMeasurements with ID: " + bm.Id);
        }

        [HttpPut("UpdateGoals")]
        public async Task<IActionResult> UpdateGoals(Goal g)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            var exG = _context.Goals.Where(x => x.Id == g.Id).FirstOrDefault<Goal>();

            if (exG != null &&_context.Users.Find(g.UserId) != null)
            {
                exG.TargetDate = g.TargetDate;
                exG.Name = g.Name;
                exG.Description = g.Description;
                exG.Status = g.Status;

                _context.SaveChanges();
            }
            else
            {
                return NotFound();
            }


            return Ok("Updated Goal with ID: " + g.Id + " From User: "+ _context.Users.Find(g.UserId).Username);
        }


        [HttpPut("UpdateStat")]
        public async Task<IActionResult> UpdateStat(Statistic s)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            var exS = _context.Statistics.Where(x => x.Id == s.Id).FirstOrDefault<Statistic>();

            if (exS != null && _context.Users.Find(s.UserId) != null && _context.Workouts.Find(s.WorkoutId) != null)
            {
                exS.Sets = s.Sets;
                exS.Reps = s.Reps;
                exS.Weight = s.Weight;

                _context.SaveChanges();
            }
            else
            {
                return NotFound();
            }


            return Ok("Updated Statistic with ID: " + s.Id + " From User: " + _context.Users.Find(s.UserId).Username);
        }

        [HttpPut("UpdateWorkout")]
        public async Task<IActionResult> UpdateWorkout(Workout w)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            var exW = _context.Workouts.Where(x => x.Id == w.Id).FirstOrDefault<Workout>();

            if (exW != null && _context.Users.Find(w.UserId) != null)
            {
                exW.Duration = w.Duration;
                exW.Date = w.Date;
                exW.Description = w.Description;
                exW.Name = w.Name;
                
                _context.SaveChanges();
            }
            else
            {
                return NotFound();
            }


            return Ok("Updated Workout with ID: " + w.Id + " From User: " + _context.Users.Find(w.UserId).Username);
        }
    }
}
