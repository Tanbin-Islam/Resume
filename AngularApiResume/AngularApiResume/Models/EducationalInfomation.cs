using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularApiResume.Models
{
    public class EducationalInfomation
    {
        public int Id { get; set; }
        public int CandidateId { get; set; }
        public string LavelOfEducation { get; set; }
        public string ExamName { get; set; }
        public string MajorSubject { get; set; }
        public string InstituteName { get; set; }
        public string Result { get; set; }
        public string YearOfPassing { get; set; }
        public Nullable<int> Duration { get; set; }

        public virtual Candidate Candidate { get; set; }
    }
}
