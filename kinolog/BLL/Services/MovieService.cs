using AutoMapper;
using BLL.Exceptions;
using BLL.Interfaces;
using BLL.Models;
using DAL.Data;
using DAL.Entities;
using DAL.Repositories;

namespace BLL.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMapper _mapper;
        private readonly MovieRepository _movieRepository;

        public MovieService(KinologDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _movieRepository = new MovieRepository(context);
        }

        public async Task AddAsync(MovieModel model)
        {
            ArgumentNullException.ThrowIfNull(model);

            await _movieRepository.AddAsync(_mapper.Map<Movie>(model));
            await _movieRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid modelId)
        {
            var entity = _movieRepository.GetByIdAsync(modelId);
            if (entity == null)
                throw new NotFoundException(modelId);

            await _movieRepository.DeleteByIdAsync(modelId);
            await _movieRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<MovieModel>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<MovieModel>>(await _movieRepository.GetAllAsync());
        }

        public async Task<MovieModel> GetByIdAsync(Guid id)
        {
            var movie = await _movieRepository.GetByIdAsync(id);

            if (movie == null)
                throw new NotFoundException(id);

            return _mapper.Map<MovieModel>(movie);
        }

        public async Task UpdateAsync(MovieModel model)
        {
            ArgumentNullException.ThrowIfNull(model);

            var movie = await _movieRepository.GetByIdAsync(model.Id);
            _movieRepository.Update(movie);
            await _movieRepository.SaveChangesAsync();
        }
    }
}
