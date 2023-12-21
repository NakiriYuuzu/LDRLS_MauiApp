namespace LDRLS_MauiApp.Properties;

public struct DefaultConfig
{
    // Routes
    internal const string ParametersKey = "parameters";
    
    // Storage
    internal const string StorageToken = "auth_token";
    
    // Api
    private const string ApiUrl = "http://192.168.31.74:8080/";
    internal const string ApiLogin = $"{ApiUrl}login";
}