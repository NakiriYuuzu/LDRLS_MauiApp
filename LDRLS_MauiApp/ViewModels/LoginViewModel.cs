using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LDRLS_MauiApp.Commons.Exceptions;
using LDRLS_MauiApp.Models.Requests;
using LDRLS_MauiApp.Models.Responses;
using LDRLS_MauiApp.Properties;
using LDRLS_MauiApp.Services;

namespace LDRLS_MauiApp.ViewModels;

public partial class LoginViewModel(ApiService apiService) : ObservableObject
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

    [RelayCommand]
    private async Task LoginOn()
    {
        Console.WriteLine("LoginRequest");
        if (String.IsNullOrEmpty(Acc) && String.IsNullOrEmpty(Pwd))
        {
            Console.WriteLine("Login Failed Because of Empty Account or Password");
            return;
        }

        SetLoading(true);

        try
        {
            var request = new LoginRequest { Account = Acc, Password = Pwd };
            var result = await apiService.PostAsync<LoginResponse>(DefaultConfig.ApiLogin, request);
            Console.WriteLine(result.Result.Token);
            if (result.Success) await SecureStorage.SetAsync(DefaultConfig.StorageToken, result.Result.Token);
            else Console.WriteLine("Login Failed, Unknown Error.");
            SetLoading(false);
        }
        catch (ConflictException e)
        {
            Console.WriteLine(e.ConflictResponse.Result);
            SetLoading(false);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            SetLoading(false);
        }
    }
    
    [RelayCommand]
    private void CreateAccountOn()
    {
        Console.WriteLine("CreateAccountOnClicked");
    }
}