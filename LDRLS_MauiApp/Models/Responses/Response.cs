using Newtonsoft.Json;

namespace LDRLS_MauiApp.Models.Responses;

public class Response
{
    [JsonProperty("result")] public string Result { get; set; }

    [JsonProperty("success")] public bool Success { get; set; }
}