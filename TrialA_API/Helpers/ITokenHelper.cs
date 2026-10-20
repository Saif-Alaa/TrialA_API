using TrialA_API.Models;

namespace TrialA_API.Helpers
{
    public interface ITokenHelper
    {
        string GenerateToken(User user);
    }
}
