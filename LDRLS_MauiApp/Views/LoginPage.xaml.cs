using LDRLS_MauiApp.Services;
using LDRLS_MauiApp.ViewModels;

namespace LDRLS_MauiApp.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
        BindingContext = new LoginViewModel(ServiceHelper.GetService<ApiService>());
    }
}