using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using DAL.Data;
using DAL.Entities;
using DAL.Repositories;

namespace BLL.Services
{
    public class CountryService : ICountryService
    {
        private readonly IMapper _mapper;
        private readonly CountryRepository _countryRepository;


        public CountryService(KinologDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _countryRepository = new CountryRepository(context);
        }

        public async Task AddAsync(CountryModel model)
        {
            ArgumentNullException.ThrowIfNull(model);
            var entity = _mapper.Map<Country>(model);

            await _countryRepository.AddAsync(entity);
            await _countryRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid modelId)
        {
            var entity = await _countryRepository.GetByIdAsync(modelId);
            ArgumentNullException.ThrowIfNull(entity);

            await _countryRepository.DeleteByIdAsync(modelId);
            await _countryRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<CountryModel>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<CountryModel>>(await _countryRepository.GetAllAsync());
        }

        public async Task<CountryModel> GetByIdAsync(Guid id)
        {
            return _mapper.Map<CountryModel>(await _countryRepository.GetByIdAsync(id));
        }

        public async Task UpdateAsync(CountryModel model)
        {
            ArgumentNullException.ThrowIfNull(model);

            var entity = await _countryRepository.GetByIdAsync(model.Id);
            _countryRepository.Update(entity);
            await _countryRepository.SaveChangesAsync();
        }
    }
}
