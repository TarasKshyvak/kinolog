using DAL.Entities;

namespace BLL.Authorization
{
    public interface IJwtUtils
    {
        public string GenerateJwtToken(User user);
        public Guid? ValidateJwtToken(string token);
    }
}
