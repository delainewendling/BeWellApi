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
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;

namespace BeWellApi.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [EnableCors("AllowDevelopmentEnvironment")]
    [Route("[controller]")]
    public class UserAssessmentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserAssessmentsController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);


        // GET: /UserAssessments
        [HttpGet]
        public IEnumerable<UserAssessment> GetUserAssessment()
        {
            return _context.UserAssessment;
        }

        // GET: UserAssessments/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserAssessment([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            UserAssessment userAssessment = await _context.UserAssessment.SingleOrDefaultAsync(m => m.UserAssessmentId == id);

            if (userAssessment == null)
            {
                return NotFound();
            }

            return Ok(userAssessment);
        }

        //// PUT: UserAssessments/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutUserAssessment([FromRoute] int id, [FromBody] UserAssessment userAssessment)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != userAssessment.UserAssessmentId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(userAssessment).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!UserAssessmentExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: /UserAssessments
        [HttpPost]
        public async Task<IActionResult> PostUserAssessment([FromBody] UserAssessment userAssessment)
        {
            ModelState.Remove("User");

            if (ModelState.IsValid)
            {
                var user = await GetCurrentUserAsync();
                userAssessment.User = user;
                _context.UserAssessment.Add(userAssessment);
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
                if (UserAssessmentExists(userAssessment.UserAssessmentId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserAssessment", new { id = userAssessment.UserAssessmentId }, userAssessment);
        }

        // DELETE: /UserAssessments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserAssessment([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            UserAssessment userAssessment = await _context.UserAssessment.SingleOrDefaultAsync(m => m.UserAssessmentId == id);
            if (userAssessment == null)
            {
                return NotFound();
            }

            _context.UserAssessment.Remove(userAssessment);
            await _context.SaveChangesAsync();

            return Ok(userAssessment);
        }

        private bool UserAssessmentExists(int id)
        {
            return _context.UserAssessment.Any(e => e.UserAssessmentId == id);
        }
    }
}