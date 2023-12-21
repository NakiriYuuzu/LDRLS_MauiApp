using Newtonsoft.Json;

namespace LDRLS_MauiApp.Models.Responses;

public class LoginResponse
{
    [JsonProperty("result")] public LoginResult Result { get; set; }

    [JsonProperty("success")] public bool Success { get; set; }
}

public class LoginResult
{
    [JsonProperty("token")] public string Token { get; set; }
}