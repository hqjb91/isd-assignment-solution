using System.Text.Json.Serialization;

namespace Domain.Entities;
public class User : IEntity
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = "";

    [JsonPropertyName("username")]
    public string UserName { get; set; } = "";

    [JsonPropertyName("email")]
    public string Email { get; set; } = "";

    [JsonPropertyName("address")]
    public Address Address { get; set; } = new();

    [JsonPropertyName("phone")]
    public string Phone { get; set; } = "";

    [JsonPropertyName("website")]
    public string Website { get; set; } = "";

    [JsonPropertyName("company")]
    public Company Company { get; set; } = new();
}
