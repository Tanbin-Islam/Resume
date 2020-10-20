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
    public class PersonalInformationsController : ControllerBase
    {
        private readonly ResumeDbContext _context;

        public PersonalInformationsController(ResumeDbContext context)
        {
            _context = context;
        }

        // GET: api/PersonalInformations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonalInformation>>> GetPersonals()
        {
            return await _context.Personals.ToListAsync();
        }

        // GET: api/PersonalInformations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonalInformation>> GetPersonalInformation(int id)
        {
            var personalInformation = await _context.Personals.FindAsync(id);

            if (personalInformation == null)
            {
                return NotFound();
            }

            return personalInformation;
        }

        // PUT: api/PersonalInformations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonalInformation(int id, PersonalInformation personalInformation)
        {
            if (id != personalInformation.Id)
            {
                return BadRequest();
            }

            _context.Entry(personalInformation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonalInformationExists(id))
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

        // POST: api/PersonalInformations
        [HttpPost]
        public async Task<ActionResult<PersonalInformation>> PostPersonalInformation(PersonalInformation personalInformation)
        {
            _context.Personals.Add(personalInformation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonalInformation", new { id = personalInformation.Id }, personalInformation);
        }

        // DELETE: api/PersonalInformations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PersonalInformation>> DeletePersonalInformation(int id)
        {
            var personalInformation = await _context.Personals.FindAsync(id);
            if (personalInformation == null)
            {
                return NotFound();
            }

            _context.Personals.Remove(personalInformation);
            await _context.SaveChangesAsync();

            return personalInformation;
        }

        private bool PersonalInformationExists(int id)
        {
            return _context.Personals.Any(e => e.Id == id);
        }
    }
}
