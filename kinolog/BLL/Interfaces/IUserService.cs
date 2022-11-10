using BLL.Models;

namespace BLL.Interfaces
{
    public interface IUserService : ICrud<UserModel>
    {
        Task<AuthenticateResponse> Authenticate(AuthenticateRequest model);
        Task<UserModel> GetByUsernameAsync(string username);
    }
}
