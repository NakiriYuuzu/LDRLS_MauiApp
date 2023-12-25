namespace LDRLS_MauiApp.Properties;

public struct DefaultConfig
{
    // Routes
    internal const string ParametersKey = "parameters";
    
    // Storage
    internal const string StorageName = "auth_name";
    internal const string StorageToken = "auth_token";
    internal const string StorageIdentity = "auth_identity";
    
    // Api
    private const string ApiUrl = "http://192.168.31.74:8080/";
    internal const string ApiLogin = $"{ApiUrl}login";
    internal const string ApiUser = $"{ApiUrl}user";
}