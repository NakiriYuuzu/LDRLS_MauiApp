using LDRLS_MauiApp.Services;
using LDRLS_MauiApp.ViewModels;
using UraniumUI.Pages;

namespace LDRLS_MauiApp.Views;

public partial class HomePage : UraniumContentPage
{
    private readonly HomeViewModel _viewModel;
    public HomePage()
    {
        InitializeComponent();
        _viewModel = ServiceHelper.GetService<HomeViewModel>();
    }
    
    protected override void OnAppearing()
    {
        base.OnAppearing();
        BindingContext = _viewModel;
        Task.Run(async () => await _viewModel.GetRooms());
    }
}