using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularApiResume.Models
{
    public class ResumeDbContext: IdentityDbContext
    {
        public ResumeDbContext(DbContextOptions<ResumeDbContext> options) : base(options)
        {

        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<CareerInformation> Careers { get; set; }
        public DbSet<EducationalInfomation> Educationals { get; set; }
        public DbSet<PersonalInformation> Personals { get; set; }
        public DbSet<RefereeInformation> Referees { get; set; }
        public DbSet<TrainingInfornation> Trainings { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Candidate>().HasData(
            new Candidate() { CandidateId = 1, Createdate = DateTime.Parse("01/01/2020"), UpdateDate = DateTime.Parse("01/02/2020"),FirstEmail = "tanbinislam1996@gmail.com", ContactMobileNo="01687260391" });

            builder.Entity<CareerInformation>().HasData(
            new CareerInformation() {Id = 1, CandidateId = 1, CompanyName ="SA Ltd",
                CompanyBusiness ="IT", Designation = "Senior",
                Department = "Management",
                Startdate = DateTime.Parse("01/01/2019"),
                EndDate= DateTime.Parse("01/12/2019")
            });

            builder.Entity<EducationalInfomation>().HasData(
            new EducationalInfomation()
            {
                Id = 1,
                CandidateId = 1,
                LavelOfEducation = "BBA",
                ExamName = "BBA",
                MajorSubject = "Mamagement",
                InstituteName = "Lalmatia Women's College",
                Result ="3.12",
                YearOfPassing = "2017",
                Duration=4
            });
            builder.Entity<PersonalInformation>().HasData(
           new PersonalInformation()
           {
               Id = 1,
               CandidateId = 1,
               FirstName = "TanBin",
               LastName = "Islam",
               FatherName = "Abdul Goni Serniabat",
               MotherName = "Rehana Begum",
               DateOfBirth = DateTime.Parse("12/24/1996"),
               Gender = "Female",
               MaritalStatus = "Single",
               PermanentAddress ="West sujon khathi,Agailjhara,Borishal",
               PresentAddress = "Mohammadpur,Dhaka"
           });

            builder.Entity<TrainingInfornation>().HasData(
        new TrainingInfornation()
        {
            Id = 1,
            CandidateId = 1,
            TrainingTitle = "IT",
            TopicsCoverd = "CSharp",
            Institute = "IsDB",
            Location = "Dhaka",
            Country = "Bangladesh",
            TrainingYear = "2019",
            Duration = "1"
          
         });
            builder.Entity<RefereeInformation>().HasData(
          new RefereeInformation()
          {
             Id = 1,
             CandidateId = 1,
             Name = "Nishat Sarmeen",
             Organization = "IsDB",
             Designation = "Instractor",
             Mobile = "012365478",
              Email = "nishat@gmail.com",
              Address = "Dhaka",
              Relation = "Teacher"

           });

            base.OnModelCreating(builder);
        }

    }
}
