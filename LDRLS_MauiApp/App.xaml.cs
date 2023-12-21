using LDRLS_MauiApp.Services;

namespace LDRLS_MauiApp;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
    }
    
    protected override void OnHandlerChanged()
    {
        base.OnHandlerChanged();
        MainPage = ServiceHelper.GetService<AppShell>();
    }
}