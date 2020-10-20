
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
    public class TrainingInfornationsController : ControllerBase
    {
        private readonly ResumeDbContext _context;

        public TrainingInfornationsController(ResumeDbContext context)
        {
            _context = context;
        }

        // GET: api/TrainingInfornations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrainingInfornation>>> GetTrainings()
        {
            return await _context.Trainings.ToListAsync();
        }

        // GET: api/TrainingInfornations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TrainingInfornation>> GetTrainingInfornation(int id)
        {
            var trainingInfornation = await _context.Trainings.FindAsync(id);

            if (trainingInfornation == null)
            {
                return NotFound();
            }

            return trainingInfornation;
        }

        // PUT: api/TrainingInfornations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrainingInfornation(int id, TrainingInfornation trainingInfornation)
        {
            if (id != trainingInfornation.Id)
            {
                return BadRequest();
            }

            _context.Entry(trainingInfornation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainingInfornationExists(id))
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

        // POST: api/TrainingInfornations
        [HttpPost]
        public async Task<ActionResult<TrainingInfornation>> PostTrainingInfornation(TrainingInfornation trainingInfornation)
        {
            _context.Trainings.Add(trainingInfornation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrainingInfornation", new { id = trainingInfornation.Id }, trainingInfornation);
        }

        // DELETE: api/TrainingInfornations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TrainingInfornation>> DeleteTrainingInfornation(int id)
        {
            var trainingInfornation = await _context.Trainings.FindAsync(id);
            if (trainingInfornation == null)
            {
                return NotFound();
            }

            _context.Trainings.Remove(trainingInfornation);
            await _context.SaveChangesAsync();

            return trainingInfornation;
        }

        private bool TrainingInfornationExists(int id)
        {
            return _context.Trainings.Any(e => e.Id == id);
        }
    }
}
