using TrialA_API.Models;

namespace TrialA_API.Repositories.Interfaces
{
    public interface IJobRepository : IGenericRepository<Job>
    {
        Task<Job> GetThirdHighestSalary();

        Task<IEnumerable<Job>> Search(string keyword);
    }
}
