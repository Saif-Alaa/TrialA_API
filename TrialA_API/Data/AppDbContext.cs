using Microsoft.EntityFrameworkCore;
using TrialA_API.Models;

namespace TrialA_API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions OP) :base(OP) 
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<CandidateProfile> CandidateProfiles { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Job> Jobs { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<Application>()
                .HasIndex(a => new { a.JobId, a.CandidateProfileId })
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasMany(U => U.EmpployerCompanies)
                .WithOne(c => c.Employer)
                .HasForeignKey(c => c.EmployerId); 
            
            
            modelBuilder.Entity<User>()
                .HasOne(U => U.CandidateProfile)
                .WithOne(c => c.Candidate)
                .HasForeignKey<CandidateProfile>(c => c.CandidateId);

            modelBuilder.Entity<Company>()
                .HasMany(c => c.Jobs)
                .WithOne(j => j.Company)
                .HasForeignKey(j => j.CompanyId);

            modelBuilder.Entity<CandidateProfile>()
                .HasMany(cp => cp.Applications)
                .WithOne(a => a.CandidateProfile)
                .HasForeignKey(a => a.CandidateProfileId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Job>()
                .HasMany(j => j.Applications)
                .WithOne(a => a.Job)
                .HasForeignKey(a => a.JobId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
                .HasData(
                    new User { Id = 1, FullName = "Ahmed Hassan", Email = "ahmed@example.com", Password = "123456", Role = "Candidate", CreatedAt = new DateTime(2026, 9, 1) ,},
                    new User { Id = 2, FullName = "Sara Mohamed", Email = "sara@example.com", Password = "123456", Role = "Employer", CreatedAt = new DateTime(2026, 9, 2) },
                    new User { Id = 3, FullName = "Omar Ali", Email = "omar@example.com", Password = "123456", Role = "Admin", CreatedAt = new DateTime(2026, 9, 3) },
                    new User { Id = 4, FullName = "Mohamed Mostafa", Email = "mohamed@example.com", Password = "123456", Role = "Candidate", CreatedAt = new DateTime(2026, 9, 4) },
                    new User { Id = 5, FullName = "Adel Ali", Email = "adel@example.com", Password = "123456", Role = "Candidate", CreatedAt = new DateTime(2026, 9, 5) }

                );

            modelBuilder.Entity<CandidateProfile>()
                .HasData(
                    new CandidateProfile { Id = 1, Phone = "01012345678", ResumeURL = "example.com/resume1", Skill = "ASP.NET Core", YearsOfExerience = 3, CandidateId = 1 ,},
                    new CandidateProfile { Id = 2, Phone = "01098765432", ResumeURL = "example.com/resume2", Skill = "Java", YearsOfExerience = 2, CandidateId = 4 },
                    new CandidateProfile { Id = 3, Phone = "0105555667", ResumeURL = "example.com/resume3", Skill = "Python", YearsOfExerience = 1, CandidateId = 5 }

                );

            modelBuilder.Entity<Company>()
                .HasData(
                    new Company { Id = 1, Name = "Tech solutions", Description = "Software development company", Website = "https://techsolutions.example.com", Location = "Cairo",EmployerId = 2, },
                    new Company { Id = 2, Name = "Future systems", Description = "IT consultion company", Website = "https://futuresystems.example.com", Location = "Gixa", EmployerId = 2 },
                    new Company { Id = 3, Name = "Digital works", Description = "Digital services company", Website = "https://digitalworks.example.com", Location = "Alexandria", EmployerId = 2 }
                );


            modelBuilder.Entity<Job>()
                .HasData(new Job { Id = 1, Title = "Backend Developer", Description = "Develop APIs using ASP.NET Core", Salary = 30000, Location = "Cairo", EmploymentType = "FullTime", PostedDate = new DateTime(2026, 10, 1), Deadline = new DateTime(2026, 11, 1), Status = "Open", CompanyId = 1, },
                new Job { Id = 2, Title = "Frontend Developer", Description = "Develop wen interfaces", Salary = 25000, Location = "Giza", EmploymentType = "FullTime", PostedDate = new DateTime(2026, 10, 2), Deadline = new DateTime(2026, 11, 2), Status = "Open", CompanyId = 1 },
                new Job { Id = 3, Title = "Software Tester", Description = "Test sofware applications", Salary = 20000, Location = "Alexandria", EmploymentType = "Contract", PostedDate = new DateTime(2026, 10, 3), Deadline = new DateTime(2026, 11, 3), Status = "Open", CompanyId = 2 }
                );

            modelBuilder.Entity<Application>()
                .HasData(
                    new Application { Id = 1, ApplicationDate = new DateTime(2026, 10, 5), Status = "Pending", CoverLetter = "Interested in backend development", CandidateProfileId = 1, JobId = 1, },
                    new Application { Id = 2, ApplicationDate = new DateTime(2026, 10, 6), Status = "UnderReview", CoverLetter = "Experienced in web technologies", CandidateProfileId = 2, JobId = 2 },
                    new Application { Id = 3, ApplicationDate = new DateTime(2026, 10, 7), Status = "Accepted", CoverLetter = "Interested in software quality", CandidateProfileId = 3, JobId = 3 }
                );
        }
    }
}
