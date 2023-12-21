using Newtonsoft.Json;

namespace LDRLS_MauiApp.Models.Requests;

public class LoginRequest
{
    [JsonProperty("account")] public string Account { get; set; }
    [JsonProperty("password")] public string Password { get; set; }
}