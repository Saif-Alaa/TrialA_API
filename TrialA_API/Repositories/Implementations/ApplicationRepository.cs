using Microsoft.EntityFrameworkCore;
using TrialA_API.Data;
using TrialA_API.Models;
using TrialA_API.Repositories.Interfaces;

namespace TrialA_API.Repositories.Implementations
{
    public class ApplicationRepository : GenericRepository<Application>, IApplicationRepository
    {
        private readonly AppDbContext _context;
        public ApplicationRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Application>> GetAllByCandidateId(int id)
        {
            var result = await _context.Applications.Include(a => a.CandidateProfile).Where(a => a.CandidateProfileId == id).ToListAsync();

            return result;
        }
    }
}
