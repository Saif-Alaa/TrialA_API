using TrialA_API.Models;

namespace TrialA_API.Repositories.Interfaces
{
    public interface ICompanyRepository : IGenericRepository<Company>
    {
        Task<Company> GetMostJobs();
    }
}
