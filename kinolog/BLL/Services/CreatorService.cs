using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using DAL.Data;
using DAL.Entities;
using DAL.Repositories;

namespace BLL.Services
{
    public class CreatorService : ICreatorService
    {
        private readonly IMapper _mapper;
        private readonly CreatorRepository _creatorRepository;

        public CreatorService(KinologDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _creatorRepository = new CreatorRepository(context);
        }

        public async Task AddAsync(CreatorModel model)
        {
            ArgumentNullException.ThrowIfNull(model);
            var entity = _mapper.Map<Creator>(model);

            await _creatorRepository.AddAsync(entity);
            await _creatorRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid modelId)
        {
            var entity = await _creatorRepository.GetByIdAsync(modelId);
            ArgumentNullException.ThrowIfNull(entity);

            await _creatorRepository.DeleteByIdAsync(modelId);
            await _creatorRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<CreatorModel>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<CreatorModel>>(await _creatorRepository.GetAllAsync());
        }

        public async Task<CreatorModel> GetByIdAsync(Guid id)
        {
            return _mapper.Map<CreatorModel>(await _creatorRepository.GetByIdAsync(id));
        }

        public async Task UpdateAsync(CreatorModel model)
        {
            ArgumentNullException.ThrowIfNull(model);

            var entity = await _creatorRepository.GetByIdAsync(model.Id);
            _creatorRepository.Update(entity);
            await _creatorRepository.SaveChangesAsync();
        }
    }
}
