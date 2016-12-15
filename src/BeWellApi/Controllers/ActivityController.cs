using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BeWellApi.Data;
using BeWellApi.Models;
using BeWellApi.Models.ActivityViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

namespace BeWellApi.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [EnableCors("AllowDevelopmentEnvironment")]
    public class ActivityController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ActivityController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        [HttpGet]
        [Route("Activities/{IsMeditation}")]
        //If meditations are wanted then IsMeditation should be 1. If other activities are wanted then IsMeditation should be 0. This is for users to see all of the meditations and other activities on the menu.
        public async Task<IActionResult> GetActivities(int IsMeditation)
        {
            if (IsMeditation == 1)
            {
                var meditations = _context.Activity.Where(a => a.IsMeditation ==  true).ToList();
                return Json(meditations);
            }
            else if (IsMeditation == 0)
            {
                var user = await GetCurrentUserAsync();
                var activities = _context.Activity.Where(a => a.IsMeditation ==  false && (a.User == user || a.User == null)).ToList();
                return Json(activities);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        [Route("Activity/{id}")]
        //This will be utilized when an activity is needed as part of the three suggested activities
        public async Task<IActionResult> GetActivity([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Activity activity = await _context.Activity.SingleOrDefaultAsync(m => m.ActivityId == id);

            if (activity == null)
            {
                return NotFound();
            }

            return Json(activity);
        }

        [HttpPost]
        [Route("AddActivity")]
        public async Task<IActionResult> PostActivity([FromBody] NewActivityViewModel activity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = await GetCurrentUserAsync();
            Activity UserActivity = new Activity
            {
                Name = activity.Name,
                Description = activity.Description,
                PointValue = activity.PointValue,
                UserAdded = true,
                IsMeditation = false,
                PhysicalMax = 2,
                PhysicalMin = -2,
                User = user 
            };
            _context.Activity.Add(UserActivity);
            
            try
            {
                await _context.SaveChangesAsync();
                foreach (int e in activity.Emotions)
                {
                    EmotionActivity emotion = new EmotionActivity
                    {
                        ActivityId = _context.Activity.Single(a => a.ActivityId == UserActivity.ActivityId).ActivityId,
                        EmotionId = _context.Emotion.Single(s => s.EmotionId == e).EmotionId
                    };
                    _context.EmotionActivity.Add(emotion);
                }
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    throw;
                }
            }
            catch (DbUpdateException)
            {
                if (ActivityExists(UserActivity.ActivityId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetActivity", new { id = UserActivity.ActivityId }, activity);
        }

        // NEED TO IMPLEMENT
        [HttpPut("{id}")]
        [Route("EditActivity/{id}")]
        public async Task<IActionResult> PutActivity([FromRoute] int id, [FromBody]NewActivityViewModel activity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != activity.ActivityId)
            {
                return BadRequest();
            }

            _context.Entry(activity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActivityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Route("DeleteActivity/{id}")]
        public async Task<IActionResult> DeleteActivity([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Activity activity = await _context.Activity.SingleOrDefaultAsync(m => m.ActivityId == id);
            var EmotionActivities = await _context.EmotionActivity.Where(e => e.ActivityId == id).ToListAsync();

            if (activity == null)
            {
                return NotFound();
            }

            _context.Activity.Remove(activity);
            await _context.SaveChangesAsync();

            if (EmotionActivities.Count() != 0)
            {
                foreach (var e in EmotionActivities)
                {
                    _context.EmotionActivity.Remove(e);
                }
            }

            await _context.SaveChangesAsync();
            return Ok(activity);
        }

        [HttpPost]
        [Route("SaveActivity/{id}")]
        public async Task<IActionResult> SaveActivity([FromRoute] int id)
        {
            var activity = _context.Activity.Single(a => a.ActivityId == id);
            if (activity == null)
            {
                return BadRequest();
            }
            var user = await GetCurrentUserAsync();
            SavedActivity savedActivity = new SavedActivity
            {
                User = user,
                ActivityId = id
            };
            _context.SavedActivity.Add(savedActivity);
            await _context.SaveChangesAsync();
            return Ok(savedActivity);
        }


        private bool ActivityExists(int id)
        {
            return _context.Activity.Any(e => e.ActivityId == id);
        }
    }
}