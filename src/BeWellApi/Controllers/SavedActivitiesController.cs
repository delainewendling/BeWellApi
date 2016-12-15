using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BeWellApi.Data;
using BeWellApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace BeWellApi.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("SavedActivities")]
    public class SavedActivitiesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public SavedActivitiesController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        //GET /SavedActivities
        [HttpGet]
        public async Task<IActionResult> GetSavedActivities()
        {
            var user = await GetCurrentUserAsync();
            List<SavedActivity> savedActivities = await _context.SavedActivity.Where(s => s.User == user).ToListAsync();
            if (savedActivities == null)
            {
                return NotFound();
            }
            return Json(savedActivities);
        }

        //GET /SavedActivities/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSavedActivity([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            SavedActivity savedActivity = await _context.SavedActivity.SingleOrDefaultAsync(m => m.SavedActivityId == id);

            if (savedActivity == null)
            {
                return NotFound();
            }

            return Ok(savedActivity);
        }

        //PUT /SavedActivities/4
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSavedActivity([FromRoute] int id, [FromBody] SavedActivity savedActivity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != savedActivity.SavedActivityId)
            {
                return BadRequest();
            }

            _context.Entry(savedActivity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SavedActivityExists(id))
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

        // POST: /SavedActivities
        [HttpPost]
        public async Task<IActionResult> PostSavedActivity([FromBody] SavedActivity savedActivity)
        {
            
            var user = await GetCurrentUserAsync();
            savedActivity.User = user;
           
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.SavedActivity.Add(savedActivity);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SavedActivityExists(savedActivity.SavedActivityId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSavedActivity", new { id = savedActivity.SavedActivityId }, savedActivity);
        }

        // DELETE: SavedActivities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSavedActivity([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            SavedActivity savedActivity = await _context.SavedActivity.SingleOrDefaultAsync(m => m.SavedActivityId == id);
            if (savedActivity == null)
            {
                return NotFound();
            }

            _context.SavedActivity.Remove(savedActivity);
            await _context.SaveChangesAsync();

            return Ok(savedActivity);
        }

        private bool SavedActivityExists(int id)
        {
            return _context.SavedActivity.Any(e => e.SavedActivityId == id);
        }
    }
}