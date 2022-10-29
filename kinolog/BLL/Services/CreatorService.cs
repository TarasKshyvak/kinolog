using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using DAL.Data;

namespace BLL.Services
{
    public class CreatorService : ICreatorService
    {
        private readonly KinologDbContext context;
        private readonly IMapper mapper;

        public CreatorService(KinologDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public Task AddAsync(CreatorModel model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid modelId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CreatorModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CreatorModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(CreatorModel model)
        {
            throw new NotImplementedException();
        }
    }
}
