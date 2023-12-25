using Newtonsoft.Json;

namespace LDRLS_MauiApp.Models.Response;

public class UserResponse
{
    [JsonProperty("result")] public required User Result { get; set; }

    [JsonProperty("success")] public bool Success { get; set; }
}