using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularApiResume.Models
{
    public class Candidate
    {
        public Candidate()
        {
            this.CareerInformations = new HashSet<CareerInformation>();
            this.EducationalInfomations = new HashSet<EducationalInfomation>();
            this.PersonalInformations = new HashSet<PersonalInformation>();
            this.RefereeInformations = new HashSet<RefereeInformation>();
            this.TrainingInfornations = new HashSet<TrainingInfornation>();
        }

        public int CandidateId { get; set; }
        public Nullable<System.DateTime> Createdate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public string FirstEmail { get; set; }
        public string ContactMobileNo { get; set; }
        public virtual ICollection<CareerInformation> CareerInformations { get; set; }

        public virtual ICollection<EducationalInfomation> EducationalInfomations { get; set; }

        public virtual ICollection<PersonalInformation> PersonalInformations { get; set; }

        public virtual ICollection<RefereeInformation> RefereeInformations { get; set; }

        public virtual ICollection<TrainingInfornation> TrainingInfornations { get; set; }
    }
}

