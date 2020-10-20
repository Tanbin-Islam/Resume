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
    public class CareerInformationsController : ControllerBase
    {
        private readonly ResumeDbContext _context;

        public CareerInformationsController(ResumeDbContext context)
        {
            _context = context;
        }

        // GET: api/CareerInformations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CareerInformation>>> GetCareers()
        {
            return await _context.Careers.ToListAsync();
        }

        // GET: api/CareerInformations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CareerInformation>> GetCareerInformation(int id)
        {
            var careerInformation = await _context.Careers.FindAsync(id);

            if (careerInformation == null)
            {
                return NotFound();
            }

            return careerInformation;
        }

        // PUT: api/CareerInformations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCareerInformation(int id, CareerInformation careerInformation)
        {
            if (id != careerInformation.Id)
            {
                return BadRequest();
            }

            _context.Entry(careerInformation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CareerInformationExists(id))
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

        // POST: api/CareerInformations
        [HttpPost]
        public async Task<ActionResult<CareerInformation>> PostCareerInformation(CareerInformation careerInformation)
        {
            _context.Careers.Add(careerInformation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCareerInformation", new { id = careerInformation.Id }, careerInformation);
        }

        // DELETE: api/CareerInformations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CareerInformation>> DeleteCareerInformation(int id)
        {
            var careerInformation = await _context.Careers.FindAsync(id);
            if (careerInformation == null)
            {
                return NotFound();
            }

            _context.Careers.Remove(careerInformation);
            await _context.SaveChangesAsync();

            return careerInformation;
        }

        private bool CareerInformationExists(int id)
        {
            return _context.Careers.Any(e => e.Id == id);
        }
    }
}
