using TrialA_API.Models;

namespace TrialA_API.Repositories.Interfaces
{
    public interface IApplicationRepository : IGenericRepository<Application>
    {
        Task<List<Application>> GetAllByCandidateId(int id);
    }
}
