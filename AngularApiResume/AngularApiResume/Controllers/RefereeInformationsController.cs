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
    public class RefereeInformationsController : ControllerBase
    {
        private readonly ResumeDbContext _context;

        public RefereeInformationsController(ResumeDbContext context)
        {
            _context = context;
        }

        // GET: api/RefereeInformations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RefereeInformation>>> GetReferees()
        {
            return await _context.Referees.ToListAsync();
        }

        // GET: api/RefereeInformations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RefereeInformation>> GetRefereeInformation(int id)
        {
            var refereeInformation = await _context.Referees.FindAsync(id);

            if (refereeInformation == null)
            {
                return NotFound();
            }

            return refereeInformation;
        }

        // PUT: api/RefereeInformations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRefereeInformation(int id, RefereeInformation refereeInformation)
        {
            if (id != refereeInformation.Id)
            {
                return BadRequest();
            }

            _context.Entry(refereeInformation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RefereeInformationExists(id))
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

        // POST: api/RefereeInformations
        [HttpPost]
        public async Task<ActionResult<RefereeInformation>> PostRefereeInformation(RefereeInformation refereeInformation)
        {
            _context.Referees.Add(refereeInformation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRefereeInformation", new { id = refereeInformation.Id }, refereeInformation);
        }

        // DELETE: api/RefereeInformations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RefereeInformation>> DeleteRefereeInformation(int id)
        {
            var refereeInformation = await _context.Referees.FindAsync(id);
            if (refereeInformation == null)
            {
                return NotFound();
            }

            _context.Referees.Remove(refereeInformation);
            await _context.SaveChangesAsync();

            return refereeInformation;
        }

        private bool RefereeInformationExists(int id)
        {
            return _context.Referees.Any(e => e.Id == id);
        }
    }
}
