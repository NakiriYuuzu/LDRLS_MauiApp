using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LDRLS_MauiApp.Commons.Exceptions;
using LDRLS_MauiApp.Models;
using LDRLS_MauiApp.Models.Request;
using LDRLS_MauiApp.Models.Response;
using LDRLS_MauiApp.Properties;
using LDRLS_MauiApp.Services;
using UraniumUI.Dialogs;

namespace LDRLS_MauiApp.ViewModels;

public partial class LoginViewModel(ApiService apiService, IDialogService dialogService) : ObservableObject 
{
    [ObservableProperty] private string _acc = string.Empty;
    [ObservableProperty] private string _pwd = string.Empty;
    [ObservableProperty] private bool _isLoading;
    [ObservableProperty] private bool _isEnabled = true;

    private void SetLoading(bool isLoading)
    {
        IsLoading = isLoading;
        IsEnabled = !isLoading;
    }

    private void Clear()
    {
        Acc = string.Empty;
        Pwd = string.Empty;
    }

    [RelayCommand]
    private async Task LoginOn()
    {
        SetLoading(true);
        if (String.IsNullOrEmpty(Acc) && String.IsNullOrEmpty(Pwd))
        {
            Console.WriteLine("Login Failed Because of Empty Account or Password");
            await dialogService.ConfirmAsync("Login Failed", "Empty Account or Password");
            SetLoading(false);
            return;
        }

        try
        {
            var request = new LoginRequest { Account = Acc, Password = Pwd };
            var result = await apiService.PostAsync<LoginResponse>(DefaultConfig.ApiLogin, request);
            if (result.Success) await SecureStorage.SetAsync(DefaultConfig.StorageToken, result.Result.Token);
            
            Clear();
            SetLoading(false);
            await RouteService.GoToAsyncResetStack(Routes.HomePage);
        }
        catch (ApiException e)
        {
            Clear();
            SetLoading(false);
            await dialogService.ConfirmAsync("Sign Up Failed", $"{e.Message}: {e.ApiResponse.Result}");
        }
        catch (Exception e)
        {
            Clear();
            SetLoading(false);
            await dialogService.ConfirmAsync("Login Failed", e.Message);
        }
    }

    [RelayCommand]
    private async Task CreateAccountOn()
    {
        await RouteService.GoToAsync(Routes.SignUpPage);
    }

    [RelayCommand]
    private async Task ForgotPasswordOn()
    {
        await dialogService.ConfirmAsync("Forgot Password", "Not Implemented Yet.");
    }
}