namespace LDRLS_MauiApp.Properties;

public struct DefaultConfig
{
    // Storage
    internal const string StorageName = "auth_name";
    internal const string StorageToken = "auth_token";
    internal const string StorageIdentity = "auth_identity";
    
    // Api
    private const string ApiUrl = "https://b3e8-1-165-71-146.ngrok-free.app/";
    internal const string ApiLogin = $"{ApiUrl}login";
    internal const string ApiUser = $"{ApiUrl}user";
    internal const string ApiRoom = $"{ApiUrl}room";
}