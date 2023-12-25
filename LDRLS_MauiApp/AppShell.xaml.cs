using LDRLS_MauiApp.Models;
using LDRLS_MauiApp.Models.Response;
using LDRLS_MauiApp.Properties;
using LDRLS_MauiApp.Services;
using LDRLS_MauiApp.Views;

namespace LDRLS_MauiApp;

public partial class AppShell : Shell
{
    private readonly ApiService _apiService;

    public AppShell()
    {
        InitializeComponent();
        _apiService = ServiceHelper.GetService<ApiService>();
        Routing.RegisterRoute(Routes.LoginPage.ToString(), typeof(LoginPage));
        Routing.RegisterRoute(Routes.SignUpPage.ToString(), typeof(SignUpPage));
        Routing.RegisterRoute(Routes.HomePage.ToString(), typeof(HomePage));
    }
}