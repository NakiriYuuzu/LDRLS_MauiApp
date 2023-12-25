using LDRLS_MauiApp.Services;
using LDRLS_MauiApp.ViewModels;
using UraniumUI.Pages;

namespace LDRLS_MauiApp.Views;

public partial class RoomListPage : UraniumContentPage
{
    private readonly RoomListViewModel _viewModel;
    public RoomListPage()
    {
        InitializeComponent();
        _viewModel = ServiceHelper.GetService<RoomListViewModel>();
        BindingContext = _viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.GetRooms();
    }
}