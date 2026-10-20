using TrialA_API.Models;

namespace TrialA_API.Repositories.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetUserByEmail(string email);

        Task<bool> IsEmailExist(string email);

        Task<User> GetUser(string id);
    }
}
