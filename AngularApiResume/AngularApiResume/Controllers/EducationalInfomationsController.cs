using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AngularApiResume.Models;

namespace AngularApiResume.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationalInfomationsController : ControllerBase
    {
        private readonly ResumeDbContext _context;

        public EducationalInfomationsController(ResumeDbContext context)
        {
            _context = context;
        }

        // GET: api/EducationalInfomations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EducationalInfomation>>> GetEducationals()
        {
            return await _context.Educationals.ToListAsync();
        }

        // GET: api/EducationalInfomations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EducationalInfomation>> GetEducationalInfomation(int id)
        {
            var educationalInfomation = await _context.Educationals.FindAsync(id);

            if (educationalInfomation == null)
            {
                return NotFound();
            }

            return educationalInfomation;
        }

        // PUT: api/EducationalInfomations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEducationalInfomation(int id, EducationalInfomation educationalInfomation)
        {
            if (id != educationalInfomation.Id)
            {
                return BadRequest();
            }

            _context.Entry(educationalInfomation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EducationalInfomationExists(id))
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

        // POST: api/EducationalInfomations
        [HttpPost]
        public async Task<ActionResult<EducationalInfomation>> PostEducationalInfomation(EducationalInfomation educationalInfomation)
        {
            _context.Educationals.Add(educationalInfomation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEducationalInfomation", new { id = educationalInfomation.Id }, educationalInfomation);
        }

        // DELETE: api/EducationalInfomations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EducationalInfomation>> DeleteEducationalInfomation(int id)
        {
            var educationalInfomation = await _context.Educationals.FindAsync(id);
            if (educationalInfomation == null)
            {
                return NotFound();
            }

            _context.Educationals.Remove(educationalInfomation);
            await _context.SaveChangesAsync();

            return educationalInfomation;
        }

        private bool EducationalInfomationExists(int id)
        {
            return _context.Educationals.Any(e => e.Id == id);
        }
    }
}
