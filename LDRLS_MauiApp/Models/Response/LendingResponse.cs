using Newtonsoft.Json;

namespace LDRLS_MauiApp.Models.Response;

public class LendingResponse
{
    [JsonProperty("result")] public List<Lending> Result { get; set; }

    [JsonProperty("success")] public bool Success { get; set; }
}