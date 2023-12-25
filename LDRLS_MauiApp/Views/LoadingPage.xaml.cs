using LDRLS_MauiApp.Models;
using LDRLS_MauiApp.Models.Response;
using LDRLS_MauiApp.Properties;
using LDRLS_MauiApp.Services;
using UraniumUI.Pages;

namespace LDRLS_MauiApp.Views;

public partial class LoadingPage : UraniumContentPage
{
    private readonly ApiService _apiService;
    
    public LoadingPage()
    {
        InitializeComponent();
        _apiService = ServiceHelper.GetService<ApiService>();
    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        await RouteService.GoToAsyncResetStack(await IsUserLoggedIn() ? Routes.HomePage : Routes.LoginPage);
    }

    private async Task<bool> IsUserLoggedIn()
    {
        var token = await SecureStorage.GetAsync(DefaultConfig.StorageToken);
        if (token == null) return false;

        var response = await _apiService.GetAsync<UserResponse>(DefaultConfig.ApiLogin);
        await SecureStorage.SetAsync(DefaultConfig.StorageName, response.Result.Name);
        await SecureStorage.SetAsync(DefaultConfig.StorageIdentity, $"{response.Result.Identity}");
        return response.Success;
    }
}