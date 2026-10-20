using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.MicrosoftExtensions;
using TrialA_API.Data;
using TrialA_API.Models;
using TrialA_API.Repositories.Interfaces;

namespace TrialA_API.Repositories.Implementations
{
    public class JobRepository : GenericRepository<Job>, IJobRepository
    {
        //saifalaasayedalaa
        private readonly AppDbContext _context;
        public JobRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Job> GetThirdHighestSalary()
        {
            var result = await _context.Jobs.OrderByDescending(x => x.Salary).Skip(2).ToListAsync();

            var newResult = result.DistinctBy(r => r.Salary).FirstOrDefault();

            return newResult;
        }

        public override async Task<Job> GetById(int id)
        {
            var result = await _context.Jobs.Include(j => j.Company).Include(J => J.Applications).FirstOrDefaultAsync(j => j.Id == id);

            return result;

        }

        public async Task<IEnumerable<Job>> Search(string keyword)
        {
            var result = await _context.Jobs.Include(j => j.Company).Where(j => j.Title.ToLower().Contains(keyword.ToLower()) || j.Description.ToLower().Contains(keyword.ToLower())).ToListAsync();

            return result;
        }
    }
}
