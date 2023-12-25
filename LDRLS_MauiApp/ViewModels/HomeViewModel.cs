using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LDRLS_MauiApp.Models;
using LDRLS_MauiApp.Properties;
using LDRLS_MauiApp.Services;

namespace LDRLS_MauiApp.ViewModels;

public partial class HomeViewModel : ObservableObject
{
    [RelayCommand]
    private async Task LogoutOn()
    {
        SecureStorage.RemoveAll();
        Console.WriteLine(await SecureStorage.GetAsync(DefaultConfig.StorageToken));
        await RouteService.GoToAsyncResetStack(Routes.LoginPage);
    }
}