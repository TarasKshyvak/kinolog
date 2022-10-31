using BLL.Interfaces;
using BLL.Models;

namespace BLL.Services
{
    public class CountryService : ICountryService
    {
        public Task AddAsync(CountryModel model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid modelId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CountryModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
        
        public Task<CountryModel> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(CountryModel model)
        {
            throw new NotImplementedException();
        }
    }
}
