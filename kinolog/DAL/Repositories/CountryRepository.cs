using DAL.Data;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly KinologDbContext _context;
        public CountryRepository(KinologDbContext kinologDbContext)
        {
            _context = kinologDbContext;
        }

        public async Task<IEnumerable<Country>> GetAllAsync()
        {
            return await _context.Countries.ToListAsync();
        }

        public async Task<Country> GetByIdAsync(Guid id)
        {
            return (await _context.Countries
                .Include(c => c.Creators)
                .FirstOrDefaultAsync(c => c.Id == id))!;
        }

        public async Task AddAsync(Country country)
        {
            await _context.AddAsync(country);
        }

        public void Delete(Country country)
        {
            _context.Countries.Remove(country);
        }

        public async Task DeleteByIdAsync(Guid id)
        {
            var c = await GetByIdAsync(id);
            _context.Countries.Remove(c);
        }

        public void Update(Country country)
        {
            _context.Countries.Update(country);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
