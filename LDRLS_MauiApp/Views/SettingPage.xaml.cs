using LDRLS_MauiApp.Services;
using LDRLS_MauiApp.ViewModels;
using UraniumUI.Pages;

namespace LDRLS_MauiApp.Views;

public partial class SettingPage : UraniumContentPage
{
    private readonly SettingViewModel _viewModel;
    public SettingPage()
    {
        InitializeComponent();
        _viewModel = ServiceHelper.GetService<SettingViewModel>();
        BindingContext = _viewModel;
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        _viewModel.UpdateIdentity();
    }
}