using Newtonsoft.Json;

namespace LDRLS_MauiApp.Models;

public class Room
{
    [JsonProperty("_id")] public string Id { get; set; } = string.Empty;

    [JsonProperty("name")] public string Name { get; set; } = string.Empty;

    [JsonProperty("roomSize")] public int RoomSize { get; set; }

    [JsonProperty("roomType")] public string RoomType { get; set; } = string.Empty;

    [JsonProperty("roomAccess")] public int RoomAccess { get; set; }

    [JsonProperty("validator")] public bool Validator { get; set; }

    [JsonProperty("modifierTime")] public long ModifierTime { get; set; }
} 