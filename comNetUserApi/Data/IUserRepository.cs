using comNetUserApi.Models;

namespace comNetUserApi.Data
{
    public interface IUserRepository
    {
        public Task AddUser(User user);
        public User? GetUser(Guid id);
        public Task<List<User>> GetUsers();
        public User? Validate(UserLoginDto loginDto);
    }
}
