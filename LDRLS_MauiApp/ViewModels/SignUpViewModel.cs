using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LDRLS_MauiApp.Commons.Exceptions;
using LDRLS_MauiApp.Models.Request;
using LDRLS_MauiApp.Models.Response;
using LDRLS_MauiApp.Properties;
using LDRLS_MauiApp.Services;
using UraniumUI.Dialogs;

namespace LDRLS_MauiApp.ViewModels;

public partial class SignUpViewModel(ApiService apiService, IDialogService dialogService) : ObservableObject
{
    [ObservableProperty] private string _name = string.Empty;
    [ObservableProperty] private string _email = string.Empty;
    [ObservableProperty] private string _phone = string.Empty;
    [ObservableProperty] private string _grade = string.Empty;
    [ObservableProperty] private string _acc = string.Empty;
    [ObservableProperty] private string _pwd = string.Empty;
    [ObservableProperty] private string _pwdConfirm = string.Empty;
    [ObservableProperty] private bool _isLoading;
    [ObservableProperty] private bool _isEnabled = true;

    [ObservableProperty] private String[] _gradeSelection;
    
    private void SetLoading(bool isLoading)
    {
        IsLoading = isLoading;
        IsEnabled = !isLoading;
    }
    
    private void Clear()
    {
        Name = string.Empty;
        Email = string.Empty;
        Phone = string.Empty;
        Grade = string.Empty;
        Acc = string.Empty;
        Pwd = string.Empty;
        PwdConfirm = string.Empty;
    }

    private string Validate()
    {
        if (String.IsNullOrEmpty(Name) || String.IsNullOrEmpty(Email) || String.IsNullOrEmpty(Phone) ||
            String.IsNullOrEmpty(Grade) || String.IsNullOrEmpty(Acc) || String.IsNullOrEmpty(Pwd) ||
            String.IsNullOrEmpty(PwdConfirm))
        {
            return "Please fill in all the blanks";
        }
        if (Phone.Length != 10)
        {
            return "Phone number must be 10 digits";
        }
        if (!Pwd.Equals(PwdConfirm))
        {
            return "Password and Confirm Password are not the same";
        }
        return string.Empty;
    }

    [RelayCommand]
    private async Task SignUpOn()
    {
        SetLoading(true);
        if (Validate() != string.Empty)
        {
            SetLoading(false);
            await dialogService.ConfirmAsync("Sign Up Failed", Validate());
            return;
        }
        try
        {
            var request = new UserRequest
            {
                Name = Name,
                Email = Email,
                Phone = Phone,
                Grade = Grade.Length,
                Account = Acc,
                Password = Pwd
            };
            var result = await apiService.PostAsync<Response>(DefaultConfig.ApiUser, request);
            Clear();
            SetLoading(false);
            if (result.Success)
            {
                await dialogService.ConfirmAsync("Sign Up Success", "Navigate to Login Page");
                RouteService.PopAsync();
            }
            else
            {
                await dialogService.ConfirmAsync("Sign Up Failed", result.Result);
            }
        }
        catch (ApiException e)
        {
            SetLoading(false);
            await dialogService.ConfirmAsync("Sign Up Failed", $"{e.Message}: {e.ApiResponse.Result}");
        }
        catch (Exception e)
        {
            SetLoading(false);
            await dialogService.ConfirmAsync("Sign Up Failed", e.Message);
        }
    }
}