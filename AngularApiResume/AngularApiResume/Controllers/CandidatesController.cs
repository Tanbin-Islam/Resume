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
    public class CandidatesController : ControllerBase
    {
        private readonly ResumeDbContext _context;

        public CandidatesController(ResumeDbContext context)
        {
            _context = context;
        }

        // GET: api/Candidates
        [HttpGet]
        public async Task<IEnumerable<object>> GetCandidates()
        {
            return await _context.Candidates
             .Include(x => x.CareerInformations)
             .Include(x => x.EducationalInfomations)
             .Select(x => new
             {
                 x.CandidateId,
                 x.Createdate,
                 x.UpdateDate,
                 x.FirstEmail,
                 x.ContactMobileNo,
                 Educations = x.EducationalInfomations.Select(p => new {
                     p.ExamName,
                     p.InstituteName,
                     p.LavelOfEducation,
                     p.MajorSubject,
                     p.Result,
                     p.YearOfPassing,
                     p.Duration
                 }),

                 Trainings = x.TrainingInfornations.Select(p => new {
                     p.Institute,
                     p.Location,
                     p.TopicsCoverd,
                     p.TrainingYear,
                     p.TrainingTitle,
                     p.Duration,
                     p.Country
                 }),

                 Personal = x.PersonalInformations.Select(p => new
                 {
                     p.FirstName,
                     p.LastName,
                     p.MaritalStatus,
                     p.PermanentAddress,
                     p.PresentAddress,
                     p.Gender,
                     p.DateOfBirth,
                     p.FatherName,
                     p.MotherName

                 }),
                 Career = x.CareerInformations.Select(p => new
                 {
                     p.CompanyName,
                     p.Department,
                     p.Designation,
                     p.CompanyBusiness,
                     p.Startdate,
                     p.EndDate,
                 }),
                 Referee = x.RefereeInformations.Select(p => new
                 {
                     
                     p.Name,
                     p.Organization,
                     p.Designation,
                     p.Mobile,
                     p.Address,
                     p.Email,
                     p.Relation

                 })
             }).ToListAsync();

            //return await _context.Candidates.Include(a => a.CareerInformations).ToListAsync();

            //var model = _context.Candidates.Include(a => a.EducationalInfomations).Include(a=>a.PersonalInformations).ToListAsync();
            //return await model;



        }

        // GET: api/Candidates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<object>> GetCandidate(int id)
        {
            //var candidate = await _context
            //.Candidates.Include(a => a.CareerInformations).FirstOrDefaultAsync(opt => opt
            //.CandidateId == id);
            var candidate = await _context.Candidates
                .Include(a => a.TrainingInfornations)
                .Include(a => a.CareerInformations)
                .Include(a => a.EducationalInfomations)
                .Include(a => a.PersonalInformations)
                .Include(a => a.RefereeInformations)
                .FirstOrDefaultAsync(opt => opt.CandidateId == id);

            if (candidate == null)
            {
                return NotFound();
            }

            return candidate;
        }

        // PUT: api/Candidates/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCandidate(int id, Candidate candidate)
        {
            if (id != candidate.CandidateId)
            {
                return BadRequest();
            }

            _context.Entry(candidate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CandidateExists(id))
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

        // POST: api/Candidates
        [HttpPost]
        public async Task<ActionResult<Candidate>> PostCandidate(Candidate candidate)
        {
            _context.Candidates.Add(candidate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCandidate", new { id = candidate.CandidateId }, candidate);
        }

        // DELETE: api/Candidates/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Candidate>> DeleteCandidate(int id)
        {
            var candidate = await _context.Candidates.FindAsync(id);
            if (candidate == null)
            {
                return NotFound();
            }

            _context.Candidates.Remove(candidate);
            await _context.SaveChangesAsync();

            return candidate;
        }

        private bool CandidateExists(int id)
        {
            return _context.Candidates.Any(e => e.CandidateId == id);
        }
    }
}
