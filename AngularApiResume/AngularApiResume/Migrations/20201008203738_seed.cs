using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AngularApiResume.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Candidates",
                columns: new[] { "CandidateId", "ContactMobileNo", "Createdate", "FirstEmail", "UpdateDate" },
                values: new object[] { 1, "01687260391", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "tanbinislam1996@gmail.com", new DateTime(2020, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Careers",
                columns: new[] { "Id", "CandidateId", "CompanyBusiness", "CompanyName", "Department", "Designation", "EndDate", "Startdate" },
                values: new object[] { 1, 1, "IT", "SA Ltd", "Management", "Senior", new DateTime(2019, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Educationals",
                columns: new[] { "Id", "CandidateId", "Duration", "ExamName", "InstituteName", "LavelOfEducation", "MajorSubject", "Result", "YearOfPassing" },
                values: new object[] { 1, 1, 4, "BBA", "Lalmatia Women's College", "BBA", "Mamagement", "3.12", "2017" });

            migrationBuilder.InsertData(
                table: "Personals",
                columns: new[] { "Id", "CandidateId", "DateOfBirth", "FatherName", "FirstName", "Gender", "LastName", "MaritalStatus", "MotherName", "PermanentAddress", "PresentAddress" },
                values: new object[] { 1, 1, new DateTime(1996, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Abdul Goni Serniabat", "TanBin", "Female", "Islam", "Single", "Rehana Begum", "West sujon khathi,Agailjhara,Borishal", "Mohammadpur,Dhaka" });

            migrationBuilder.InsertData(
                table: "Referees",
                columns: new[] { "Id", "Address", "CandidateId", "Designation", "Email", "Mobile", "Name", "Organization", "Relation" },
                values: new object[] { 1, "Dhaka", 1, "Instractor", "nishat@gmail.com", "012365478", "Nishat Sarmeen", "IsDB", "Teacher" });

            migrationBuilder.InsertData(
                table: "Trainings",
                columns: new[] { "Id", "CandidateId", "Country", "Duration", "Institute", "Location", "TopicsCoverd", "TrainingTitle", "TrainingYear" },
                values: new object[] { 1, 1, "Bangladesh", "1", "IsDB", "Dhaka", "CSharp", "IT", "2019" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Careers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Educationals",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Personals",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Referees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Trainings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Candidates",
                keyColumn: "CandidateId",
                keyValue: 1);
        }
    }
}
