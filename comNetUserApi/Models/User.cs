using Npgsql;

namespace comNetUserApi.Models
{
    public class User
    {
        public Guid UserId { get; set; } = Guid.NewGuid();
        public string? Username { get; set; }
        public string? Key { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? Lastname { get; set; }

        public static User Mapper(NpgsqlDataReader reader)
        {
            var user = new User();
            var conv = Guid.TryParse(reader[0].ToString(), out Guid id);

            user.UserId = id;
            user.Username = reader[1].ToString() ?? "";
            user.Key = reader[2].ToString() ?? "";
            user.Surname = reader[3].ToString() ?? "";
            user.Email = reader[4].ToString() ?? "";
            user.Lastname = reader[5].ToString() ?? "";

            return user;
        }
    }
}
