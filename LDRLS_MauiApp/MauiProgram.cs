using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;
using LDRLS_MauiApp.Services;
using Microsoft.Extensions.Logging;

namespace LDRLS_MauiApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .UseMauiCommunityToolkitCore()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif
        
        // Dependency Injection
        builder.Services.AddSingleton<HttpClient>();
        builder.Services.AddTransient<ApiService>();

        var app = builder.Build();
        ServiceHelper.Initialize(app.Services);
        
        return builder.Build();
    }
}