using Newtonsoft.Json;

namespace LDRLS_MauiApp.Models.Response;

public class RoomResponse
{
    [JsonProperty("result")] public List<Room> Result { get; set; }

    [JsonProperty("success")] public bool Success { get; set; }
}