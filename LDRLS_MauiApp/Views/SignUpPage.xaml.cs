using LDRLS_MauiApp.Services;
using LDRLS_MauiApp.ViewModels;
using UraniumUI.Dialogs.CommunityToolkit;
using UraniumUI.Pages;

namespace LDRLS_MauiApp.Views;

public partial class SignUpPage : UraniumContentPage
{
    public SignUpPage()
    {
        InitializeComponent();
        BindingContext = ServiceHelper.GetService<SignUpViewModel>();
    }
}