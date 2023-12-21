using CommunityToolkit.Maui;
using LDRLS_MauiApp.Services;
using Microsoft.Extensions.Logging;
using UraniumUI;
using UraniumUI.Dialogs.CommunityToolkit;

namespace LDRLS_MauiApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .UseUraniumUI()
            .UseUraniumUIMaterial()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddMaterialIconFonts(); 
            });
        
#if DEBUG
        builder.Logging.AddDebug();
#endif
        // Components
        builder.Services.AddCommunityToolkitDialogs();
        
        // Dependency Injection
        builder.Services.AddTransient<AppShell>();
        builder.Services.AddSingleton<HttpClient>();
        
        builder.Services.AddTransient<CommunityToolkitDialogService>();
        builder.Services.AddTransient<ApiService>();

        var app = builder.Build();
        ServiceHelper.Initialize(app.Services);

        return app;
    }
}