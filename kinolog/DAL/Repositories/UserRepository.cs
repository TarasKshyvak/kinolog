using DAL.Data;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly KinologDbContext _context;
        public UserRepository(KinologDbContext kinologDbContext)
        {
            _context = kinologDbContext;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            return (await _context.Users
                .Include(c => c.Gender)
                .Include(r => r.MoviesRatings)
                .FirstOrDefaultAsync(c => c.Id == id))!;
        }

        public async Task<User?> GetByUsername(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<User?> GetByUsername(string username)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);

            return user;
        }

        public async Task AddAsync(User user)
        {
            await _context.AddAsync(user);
        }

        public void Delete(User user)
        {
            _context.Users.Remove(user);
        }

        public async Task DeleteByIdAsync(Guid id)
        {
            var u = await GetByIdAsync(id);
            _context.Users.Remove(u);
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
