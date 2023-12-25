using Newtonsoft.Json;

namespace LDRLS_MauiApp.Models;

public class User
{
    [JsonProperty("_id")] public string Id { get; set; }

    [JsonProperty("name")] public string Name { get; set; }

    [JsonProperty("email")] public string Email { get; set; }

    [JsonProperty("grade")] public int Grade { get; set; }

    [JsonProperty("phone")] public string Phone { get; set; }

    [JsonProperty("identity")] public int Identity { get; set; }

    [JsonProperty("validator")] public bool Validator { get; set; }

    [JsonProperty("account")] public string Account { get; set; }

    [JsonProperty("password")] public string Password { get; set; }

    [JsonProperty("salt")] public string Salt { get; set; }
}