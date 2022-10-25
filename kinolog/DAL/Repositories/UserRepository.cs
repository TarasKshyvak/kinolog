using DAL.Data;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;


namespace DAL.Repositories
{
    public class UserRepository //: IUserRepository
    {
        private readonly KinologDbContext _context;
        public UserRepository(KinologDbContext kinologDbContext)
        {
            _context = kinologDbContext;
        }



        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);

        }

        public async Task UpdateAsync(int id, User user)
        {
            _context.Users.Update(user);

        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();

        }

        public async Task<User> GetByIdAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            return user;
        }

        public async Task DeleteByIdAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            _context.Users.Remove(entity);

        }


    }
}
