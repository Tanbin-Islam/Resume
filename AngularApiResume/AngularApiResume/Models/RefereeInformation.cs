using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularApiResume.Models
{
    public class RefereeInformation
    {
        public int Id { get; set; }
        public int CandidateId { get; set; }
        public string Name { get; set; }
        public string Organization { get; set; }
        public string Designation { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Relation { get; set; }

        public virtual Candidate Candidate { get; set; }
    }
}
