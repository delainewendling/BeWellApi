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
    [Produces("application/json")]
    public class AssessmentController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public AssessmentController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: api/Assessment
        [HttpGet]
        //[Authorize]
        [Route("api/Emotions/{CategoryId}")]
        //The Emotions will be grouped by category and the data will be called to each component based on the Category Id.
        public IEnumerable<Emotion> GetEmotion(int CategoryId)
        {
            var emotions = _context.Emotion.Where(e => e.EmotionCategoryId == CategoryId).ToList();
            return emotions;
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

        // PUT: api/Assessment/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmotion([FromRoute] int id, [FromBody] Emotion emotion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != emotion.EmotionId)
            {
                return BadRequest();
            }

            _context.Entry(emotion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmotionExists(id))
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

        // POST: api/Assessment
        [HttpPost]
        public async Task<IActionResult> PostEmotion([FromBody] Emotion emotion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Emotion.Add(emotion);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EmotionExists(emotion.EmotionId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEmotion", new { id = emotion.EmotionId }, emotion);
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