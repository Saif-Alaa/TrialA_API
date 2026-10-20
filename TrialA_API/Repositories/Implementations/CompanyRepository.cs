using Microsoft.EntityFrameworkCore;
using TrialA_API.Data;
using TrialA_API.Models;
using TrialA_API.Repositories.Interfaces;

namespace TrialA_API.Repositories.Implementations
{
    public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
    {
        private readonly AppDbContext _context;
        public CompanyRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Company> GetMostJobs()
        {
            var result = await _context.Companies.Include(c => c.Jobs).OrderByDescending(c => c.Jobs.Count).FirstOrDefaultAsync();

            return result;
        }
    }
}
