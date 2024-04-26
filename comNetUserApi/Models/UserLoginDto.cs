using System.Text.Json.Serialization;

namespace comNetUserApi.Models;

public class UserLoginDto
{
    [JsonPropertyName("username")]
    public string Username { get; set; }

    [JsonPropertyName("key")]
    public string Key { get; set; }

    [JsonPropertyName("remember")]
    public string Remember { get; set; } 
}