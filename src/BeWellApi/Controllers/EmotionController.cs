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
    public class EmotionController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public EmotionController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        [HttpGet]
        [Route("Emotions/{CategoryId}")]
        //The Emotions will be grouped by category and the data will be called to each component based on the Category Id.
        public async Task<IActionResult> GetEmotion(int CategoryId)
        {
            var emotions = await _context.Emotion.Where(e => e.EmotionCategoryId == CategoryId).ToListAsync();
            if (emotions == null)
            {
                return NotFound();
            }
            return Json(emotions);
        }

        // GET: api/Assessment/5
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetEmotion([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        
        //    Emotion emotion = await _context.Emotion.SingleOrDefaultAsync(m => m.EmotionId == id);

        //    if (emotion == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(emotion);
        //}

        // POST: /Emotion
        [HttpPost]
        [Route("Emotion")]
        public async Task<IActionResult> PostEmotion([FromBody] UserEmotion userEmotion)
        {
            ModelState.Remove("User");
            if (ModelState.IsValid)
            {
                var user = await GetCurrentUserAsync();
                userEmotion.User = user;
                _context.UserEmotion.Add(userEmotion);
            }
            else
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EmotionExists(userEmotion.UserEmotionId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEmotion", new { id = userEmotion.UserEmotionId }, userEmotion);
        }

        // DELETE: api/Assessment/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmotion([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Emotion emotion = await _context.Emotion.SingleOrDefaultAsync(m => m.EmotionId == id);
            if (emotion == null)
            {
                return NotFound();
            }

            _context.Emotion.Remove(emotion);
            await _context.SaveChangesAsync();

            return Ok(emotion);
        }

        private bool EmotionExists(int id)
        {
            return _context.Emotion.Any(e => e.EmotionId == id);
        }
    }
}