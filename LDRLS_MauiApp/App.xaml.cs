using LDRLS_MauiApp.Services;
using LDRLS_MauiApp.Views;

namespace LDRLS_MauiApp;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        MainPage = ServiceHelper.GetService<AppShell>();
    }
}