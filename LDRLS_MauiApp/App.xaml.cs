using LDRLS_MauiApp.Services;

namespace LDRLS_MauiApp;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        MainPage = new AppShell();
    }
}