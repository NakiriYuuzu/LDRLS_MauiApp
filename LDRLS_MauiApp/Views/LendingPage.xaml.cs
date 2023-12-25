using LDRLS_MauiApp.Services;
using LDRLS_MauiApp.ViewModels;
using UraniumUI.Pages;

namespace LDRLS_MauiApp.Views;

public partial class LendingPage : UraniumContentPage
{
    private readonly LendingViewModel _viewModel;
    public LendingPage()
    {
        InitializeComponent();
        _viewModel = ServiceHelper.GetService<LendingViewModel>();
        BindingContext = _viewModel;
    }
}