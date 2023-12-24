using Newtonsoft.Json;

namespace LDRLS_MauiApp.Models.Request;

public class UserRequest
{
    [JsonProperty("_id")] public string Id { get; set; } = string.Empty;
    [JsonProperty("name")] public string Name { get; set; } = string.Empty;
    [JsonProperty("email")] public string Email { get; set; } = string.Empty;
    [JsonProperty("phone")] public string Phone { get; set; } = string.Empty;
    [JsonProperty("grade")] public int Grade { get; set; }
    [JsonProperty("identity")] public int Identity { get; set; }
    [JsonProperty("validator")] public bool Validator { get; set; }
    [JsonProperty("account")] public string Account { get; set; } = string.Empty;
    [JsonProperty("password")] public string Password { get; set; } = string.Empty;
}