using AutoMapper;
using BLL.Authorization;
using BLL.Exceptions;
using BLL.Interfaces;
using BLL.Models;
using DAL.Data;
using DAL.Entities;
using DAL.Repositories;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IJwtUtils _jwtUtils;
        private readonly UserRepository _userRepository;

        public UserService(KinologDbContext context, IMapper mapper, IJwtUtils jwtUtils)
        {
            _mapper = mapper;
            _jwtUtils = jwtUtils;
            _userRepository = new UserRepository(context);
        }

        public async Task AddAsync(UserModel model)
        {
            ArgumentNullException.ThrowIfNull(model);

            var checkUser = await _userRepository.GetByUsernameAsync(model.Username);

            if (checkUser != null)
                throw new AppException($"Username \"{checkUser.Username}\" is not available");

            var entity = _mapper.Map<User>(model);

            entity.PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password);

            await _userRepository.AddAsync(entity);
            await _userRepository.SaveChangesAsync();
        }

        public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest model)
        {
            var user = await _userRepository.GetByUsernameAsync(model.Username);

            if (user == null || !BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash))
                throw new AppException("Username or password is incorrect");

            var jwtToken = _jwtUtils.GenerateJwtToken(user);

            return new AuthenticateResponse(user, jwtToken);
        }

        public async Task DeleteAsync(Guid modelId)
        {
            var entity = await _userRepository.GetByIdAsync(modelId);

            if (entity == null)
                throw new NotFoundException(modelId);

            await _userRepository.DeleteByIdAsync(modelId);
            await _userRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserModel>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<UserModel>>(await _userRepository.GetAllAsync());
        }

        public async Task<UserModel> GetByIdAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
                throw new NotFoundException(id);

            return _mapper.Map<UserModel>(user);
        }

        public async Task<UserModel> GetByUsernameAsync(string username)
        {
            var user = await _userRepository.GetByUsernameAsync(username);

            if (user == null)
                throw new NotFoundException($"User with username {username} is not found");

            return _mapper.Map<UserModel>(user);
        }

        public async Task UpdateAsync(UserModel model)
        {
            ArgumentNullException.ThrowIfNull(model);

            var entity = await _userRepository.GetByIdAsync(model.Id);
            _userRepository.Update(entity);
            await _userRepository.SaveChangesAsync();
        }
    }
}
