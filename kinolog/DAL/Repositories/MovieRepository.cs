using DAL.Data;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly KinologDbContext _context;
        public MovieRepository(KinologDbContext kinologDbContext)
        {
            _context = kinologDbContext;
        }


        public async Task<IEnumerable<Movie>> GetAllAsync()
        {
            return await _context.Movies.ToListAsync();
        }

        public async Task<Movie> GetByIdAsync(Guid id)
        {
            return await _context.Movies
                .Include(m => m.Genres)
                .Include(m => m.UsersRatings)
                .Include(m => m.Creators)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddAsync(Movie movie)
        {
            await _context.AddAsync(movie);
        }

        public void Delete(Movie movie)
        {
            _context.Movies.Remove(movie);
        }

        public async Task DeleteByIdAsync(Guid id)
        {
            var m = await GetByIdAsync(id);
            _context.Movies.Remove(m);
        }

        public void Update(Movie movie)
        {
            _context.Movies.Update(movie);
        }

    }
}
