using TrialA_API.Models;

namespace TrialA_API.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IApplicationRepository ApplicationRepository { get; }
        ICompanyRepository CompanyRepository { get; }
        IJobRepository JobRepository { get; }
        IGenericRepository<CandidateProfile> CandidateProfileRepository { get; }

        Task SaveChanges();
    }
}
