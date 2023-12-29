using Newtonsoft.Json;

namespace LDRLS_MauiApp.Models;

public class Lending
{
    [JsonProperty("_id")] public string Id { get; set; }

    [JsonProperty("userId")] public string UserId { get; set; }

    [JsonProperty("roomId")] public string RoomId { get; set; }

    [JsonProperty("adminId")] public string AdminId { get; set; }

    [JsonProperty("startTime")] public object StartTime { get; set; }

    [JsonProperty("endTime")] public object EndTime { get; set; }

    [JsonProperty("validator")] public bool Validator { get; set; }

    [JsonProperty("modifierTime")] public object ModifierTime { get; set; }
}