using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LDRLS_MauiApp.Models;
using LDRLS_MauiApp.Properties;
using LDRLS_MauiApp.Services;
using UraniumUI.Dialogs;

namespace LDRLS_MauiApp.ViewModels;

public partial class SettingViewModel(IDialogService dialogService) : ObservableObject
{
    [ObservableProperty] private bool _identity;
    [ObservableProperty] private string _user = String.Empty;

    public void UpdateIdentity()
    {
        var identity = Task.Run(async () => await SecureStorage.GetAsync(DefaultConfig.StorageIdentity));
        var user = Task.Run(async () => await SecureStorage.GetAsync(DefaultConfig.StorageName));
        Console.WriteLine("Identity: " + identity.Result);
        Console.WriteLine("User: " + user.Result);
        Identity = identity.Result == "0";
        User = $"{user.Result}";
    }

    [RelayCommand]
    private async Task PushToRoomOn()
    {
        await RouteService.GoToAsync(Routes.RoomListPage);
    }

    [RelayCommand]
    private async Task NoImplementedOn()
    {
        await dialogService.ConfirmAsync("No Implemented", "No Implemented");
    }

    [RelayCommand]
    private async Task LogoutOn()
    {
        SecureStorage.Remove(DefaultConfig.StorageToken);
        SecureStorage.Remove(DefaultConfig.StorageIdentity);
        SecureStorage.RemoveAll();
        RouteService.PopAsync();
        await RouteService.GoToAsyncResetStack(Routes.LoginPage);
    }
}