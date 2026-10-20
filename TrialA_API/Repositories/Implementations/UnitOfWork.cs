using TrialA_API.Data;
using TrialA_API.Models;
using TrialA_API.Repositories.Interfaces;

namespace TrialA_API.Repositories.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {

        public IUserRepository UserRepository { get; }

        public IApplicationRepository ApplicationRepository { get; }

        public ICompanyRepository CompanyRepository { get; }

        public IJobRepository JobRepository { get; }

        public IGenericRepository<CandidateProfile> CandidateProfileRepository { get; }

        private readonly AppDbContext _context;

        public UnitOfWork(IUserRepository userRepository, IApplicationRepository applicationRepository, ICompanyRepository companyRepository, IJobRepository jobRepository, IGenericRepository<CandidateProfile> candidateProfileRepository, AppDbContext context)
        {
            UserRepository = userRepository;
            ApplicationRepository = applicationRepository;
            CompanyRepository = companyRepository;
            JobRepository = jobRepository;
            CandidateProfileRepository = candidateProfileRepository;
            _context = context;
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
