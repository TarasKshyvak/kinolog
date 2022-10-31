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
            var creator = await _context.Creators
                .Include(c => c.Country)
                .Include(m => m.Movies)
                .FirstOrDefaultAsync(c => c.Id == id);

            ArgumentNullException.ThrowIfNull(creator);
            return creator;
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
            var creator = await GetByIdAsync(id);
            _context.Creators.Remove(creator);
        }

        public void Update(Creator creator)
        {
            _context.Creators.Update(creator);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
