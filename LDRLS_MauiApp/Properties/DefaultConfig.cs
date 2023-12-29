namespace LDRLS_MauiApp.Properties;

public struct DefaultConfig
{
    // Storage
    internal const string StorageName = "auth_name";
    internal const string StorageToken = "auth_token";
    internal const string StorageIdentity = "auth_identity";
    internal const string StorageLendingData = "data_lending";
    
    // Api
    private const string ApiUrl = "https://0bcb-1-170-39-242.ngrok-free.app/";
    internal const string ApiLogin = $"{ApiUrl}login";
    internal const string ApiUser = $"{ApiUrl}user";
    internal const string ApiLending = $"{ApiUrl}lending";
    internal const string ApiRoom = $"{ApiUrl}room";
}