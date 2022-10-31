using BLL.Interfaces;
using BLL.Models;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        public Task AddAsync(UserModel model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid modelId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserModel> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(UserModel model)
        {
            throw new NotImplementedException();
        }
    }
}
