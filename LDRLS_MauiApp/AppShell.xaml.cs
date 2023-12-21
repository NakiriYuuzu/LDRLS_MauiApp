using LDRLS_MauiApp.Models;
using LDRLS_MauiApp.Views;

namespace LDRLS_MauiApp;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(Routes.LoginPage.ToString(), typeof(LoginPage));
        Routing.RegisterRoute(Routes.SignUpPage.ToString(), typeof(SignUpPage));
        Routing.RegisterRoute(Routes.HomePage.ToString(), typeof(HomePage));
    }
}