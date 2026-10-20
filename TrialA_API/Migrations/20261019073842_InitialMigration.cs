using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TrialA_API.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CandidateProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResumeURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Skill = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    YearsOfExerience = table.Column<int>(type: "int", nullable: false),
                    CandidateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidateProfiles_Users_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Companies_Users_EmployerId",
                        column: x => x.EmployerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EmploymentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jobs_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoverLetter = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    CandidateProfileId = table.Column<int>(type: "int", nullable: false),
                    JobId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Applications_CandidateProfiles_CandidateProfileId",
                        column: x => x.CandidateProfileId,
                        principalTable: "CandidateProfiles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Applications_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "FullName", "Password", "Role" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ahmed@example.com", "Ahmed Hassan", "123456", "Candidate" },
                    { 2, new DateTime(2026, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "sara@example.com", "Sara Mohamed", "123456", "Employer" },
                    { 3, new DateTime(2026, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "omar@example.com", "Omar Ali", "123456", "Admin" },
                    { 4, new DateTime(2026, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "mohamed@example.com", "Mohamed Mostafa", "123456", "Candidate" },
                    { 5, new DateTime(2026, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "adel@example.com", "Adel Ali", "123456", "Candidate" }
                });

            migrationBuilder.InsertData(
                table: "CandidateProfiles",
                columns: new[] { "Id", "CandidateId", "Phone", "ResumeURL", "Skill", "YearsOfExerience" },
                values: new object[,]
                {
                    { 1, 1, "01012345678", "example.com/resume1", "ASP.NET Core", 3 },
                    { 2, 4, "01098765432", "example.com/resume2", "Java", 2 },
                    { 3, 5, "0105555667", "example.com/resume3", "Python", 1 }
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Description", "EmployerId", "Location", "Name", "Website" },
                values: new object[,]
                {
                    { 1, "Software development company", 2, "Cairo", "Tech solutions", "https://techsolutions.example.com" },
                    { 2, "IT consultion company", 2, "Gixa", "Future systems", "https://futuresystems.example.com" },
                    { 3, "Digital services company", 2, "Alexandria", "Digital works", "https://digitalworks.example.com" }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "CompanyId", "Deadline", "Description", "EmploymentType", "Location", "PostedDate", "Salary", "Status", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2026, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Develop APIs using ASP.NET Core", "FullTime", "Cairo", new DateTime(2026, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 30000m, "Open", "Backend Developer" },
                    { 2, 1, new DateTime(2026, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Develop wen interfaces", "FullTime", "Giza", new DateTime(2026, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 25000m, "Open", "Frontend Developer" },
                    { 3, 2, new DateTime(2026, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test sofware applications", "Contract", "Alexandria", new DateTime(2026, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 20000m, "Open", "Software Tester" }
                });

            migrationBuilder.InsertData(
                table: "Applications",
                columns: new[] { "Id", "ApplicationDate", "CandidateProfileId", "CoverLetter", "JobId", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Interested in backend development", 1, "Pending" },
                    { 2, new DateTime(2026, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Experienced in web technologies", 2, "UnderReview" },
                    { 3, new DateTime(2026, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Interested in software quality", 3, "Accepted" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Applications_CandidateProfileId",
                table: "Applications",
                column: "CandidateProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_JobId_CandidateProfileId",
                table: "Applications",
                columns: new[] { "JobId", "CandidateProfileId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CandidateProfiles_CandidateId",
                table: "CandidateProfiles",
                column: "CandidateId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Companies_EmployerId",
                table: "Companies",
                column: "EmployerId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_CompanyId",
                table: "Jobs",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropTable(
                name: "CandidateProfiles");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
