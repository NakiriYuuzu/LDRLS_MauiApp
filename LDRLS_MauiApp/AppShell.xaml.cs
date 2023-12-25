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
        Routing.RegisterRoute(Routes.LendingPage.ToString(), typeof(LendingPage));
        Routing.RegisterRoute(Routes.LendingStatusPage.ToString(), typeof(LendingStatusPage));
        Routing.RegisterRoute(Routes.SettingPage.ToString(), typeof(SettingPage));
        Routing.RegisterRoute(Routes.RoomListPage.ToString(), typeof(RoomListPage));
        Routing.RegisterRoute(Routes.RoomAddOrEditPage.ToString(), typeof(RoomAddOrEditPage));
    }
}