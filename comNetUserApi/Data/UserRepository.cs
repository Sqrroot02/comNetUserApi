using comNetUserApi.Models;
using Npgsql;

namespace comNetUserApi.Data
{
    public class UserRepository : IUserRepository
    {
        public UserRepository()
        {
           
        }

        private readonly List<User> users = new()
        {
            new User()
            {
                Username = "alex",
                Key = "alexAlex123",
                Email = "alex.patola@mail.com"
            }     
        };
        
        public async Task AddUser(User user)
        {
            var sql = @"INSERT INTO users 
                (userid,username,key,surname,email,lastname)
                VALUES (@userid, @username, @key, @surname, @email, @lastname)";

            var command = new NpgsqlCommand(sql);
            command.Parameters.AddWithValue("@userid", user.UserId.ToString());
            command.Parameters.AddWithValue("@username", user.Username);
            command.Parameters.AddWithValue("@key", user.Key);
            command.Parameters.AddWithValue("@surname", user.Surname);
            command.Parameters.AddWithValue("@email", user.Email);
            command.Parameters.AddWithValue("@lastname", user.Lastname);

            await DbRequest.Insert(command);

            users.Add(user);
        }

        public User? GetUser(Guid id)
        {
            var result = users.Where(x => x.UserId == id).ToList();
            return result.FirstOrDefault();
        }

        public async Task<List<User>> GetUsers()
        {
            return await DbRequest.Query("SELECT * FROM users;", User.Mapper);
        }

        public User? Validate(UserLoginDto loginDto)
        {
            return users.FirstOrDefault(x => x.Key == loginDto.Key && x.Username == loginDto.Username);
        }
    }
}
