﻿using Newtonsoft.Json;

namespace LDRLS_MauiApp.Models.Response;

public class LoginResponse
{
    [JsonProperty("result")] public required LoginResult Result { get; set; }

    [JsonProperty("success")] public bool Success { get; set; }
}

public class LoginResult
{
    [JsonProperty("token")] public string Token { get; set; } = string.Empty;
    [JsonProperty("identity")] public int Identity { get; set; }
    [JsonProperty("name")] public string Name { get; set; } = string.Empty;
}