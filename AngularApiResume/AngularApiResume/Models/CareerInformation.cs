using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularApiResume.Models
{
    public class CareerInformation
    {
        public int Id { get; set; }
        public Nullable<int> CandidateId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyBusiness { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public Nullable<System.DateTime> Startdate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }

        public virtual Candidate Candidate { get; set; }
    }
}
