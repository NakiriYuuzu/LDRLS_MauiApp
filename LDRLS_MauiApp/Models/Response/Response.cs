using Newtonsoft.Json;

namespace LDRLS_MauiApp.Models.Response;

public class Response
{
    [JsonProperty("result")] public string Result { get; set; } = string.Empty;

    [JsonProperty("success")] public bool Success { get; set; }
}