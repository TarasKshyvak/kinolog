using DAL.Data;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class CreatorRepository : ICreatorRepository
    {
        private readonly KinologDbContext _context;
        public CreatorRepository(KinologDbContext kinologDbContext)
        {
            _context = kinologDbContext;
        }

        public async Task<IEnumerable<Creator>> GetAllAsync()
        {
            return await _context.Creators.ToListAsync();
        }

        public async Task<Creator> GetByIdAsync(Guid id)
        {
            return await _context.Creators
                .Include(c => c.Country)
                .Include(m => m.Movies)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
        
        public async Task AddAsync(Creator creator)
        {
            await _context.AddAsync(creator);
        }

        public void Delete(Creator creator)
        {
            _context.Creators.Remove(creator);
        }

        public async Task DeleteByIdAsync(Guid id)
        {
            var c = await GetByIdAsync(id);
            _context.Creators.Remove(c);
        }

        public void Update(Creator creator)
        {
            _context.Creators.Update(creator);
        }

    }
}
