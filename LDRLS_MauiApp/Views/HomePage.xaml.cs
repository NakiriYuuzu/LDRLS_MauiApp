using LDRLS_MauiApp.ViewModels;
using UraniumUI.Pages;

namespace LDRLS_MauiApp.Views;

public partial class HomePage : UraniumContentPage
{
    public HomePage()
    {
        InitializeComponent();
        BindingContext = new HomeViewModel();
    }
}