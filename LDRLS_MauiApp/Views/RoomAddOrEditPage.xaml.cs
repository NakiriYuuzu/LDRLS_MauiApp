using LDRLS_MauiApp.Services;
using LDRLS_MauiApp.ViewModels;
using UraniumUI.Pages;

namespace LDRLS_MauiApp.Views;

public partial class RoomAddOrEditPage : UraniumContentPage
{
    private readonly AddOrEditViewModel _viewModel;
    public RoomAddOrEditPage()
    {
        InitializeComponent();
        _viewModel = ServiceHelper.GetService<AddOrEditViewModel>();
        BindingContext = _viewModel;
    }
}