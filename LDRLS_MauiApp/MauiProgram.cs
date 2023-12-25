using CommunityToolkit.Maui;
using LDRLS_MauiApp.Services;
using LDRLS_MauiApp.ViewModels;
using Microsoft.Extensions.Logging;
using UraniumUI;
using UraniumUI.Dialogs;
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
        builder.Services.AddSingleton<AppShell>();
        builder.Services.AddSingleton<HttpClient>();
        builder.Services.AddSingleton<ApiService>();
        builder.Services.AddSingleton<IDialogService, CommunityToolkitDialogService>();

        builder.Services.AddTransient<LoginViewModel>();
        builder.Services.AddTransient<SignUpViewModel>();
        builder.Services.AddTransient<HomeViewModel>();
        builder.Services.AddTransient<SettingViewModel>();
        builder.Services.AddTransient<LendingViewModel>();
        builder.Services.AddTransient<LendingStatusViewModel>();
        builder.Services.AddTransient<AddOrEditViewModel>();
        builder.Services.AddTransient<RoomListViewModel>();

        var app = builder.Build();
        ServiceHelper.Initialize(app.Services);

        return app;
    }
}