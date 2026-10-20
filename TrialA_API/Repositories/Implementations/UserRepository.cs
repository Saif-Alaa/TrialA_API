using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrialA_API.Data;
using TrialA_API.Models;
using TrialA_API.Repositories.Interfaces;

namespace TrialA_API.Repositories.Implementations
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> GetUser(string id)
        {
            var result = await _context.Users.Include(u => u.CandidateProfile).FirstOrDefaultAsync(u => Convert.ToString(u.Id) == id);

            return result;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var result = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

            return result;
        }

        public async Task<bool> IsEmailExist(string email)
        {
            var result = await _context.Users.AnyAsync(u => u.Email == email);

            return result;
        }
    }
}
