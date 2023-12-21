using LDRLS_MauiApp.Services;
using LDRLS_MauiApp.ViewModels;
using UraniumUI.Dialogs.CommunityToolkit;
using UraniumUI.Pages;

namespace LDRLS_MauiApp.Views;

public partial class LoginPage : UraniumContentPage
{
    public LoginPage()
    {
        InitializeComponent();
        BindingContext = new LoginViewModel(
            ServiceHelper.GetService<ApiService>(),
            ServiceHelper.GetService<CommunityToolkitDialogService>()
        );
    }
}