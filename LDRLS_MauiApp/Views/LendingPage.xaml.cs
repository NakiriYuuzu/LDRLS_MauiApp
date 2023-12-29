using LDRLS_MauiApp.Models;
using LDRLS_MauiApp.Services;
using LDRLS_MauiApp.ViewModels;
using UraniumUI.Pages;

namespace LDRLS_MauiApp.Views;

public partial class LendingPage : UraniumContentPage
{
    private readonly LendingViewModel _viewModel;
    private readonly Room _selectedRoom;
    public LendingPage(Room selectedRoom)
    {
        InitializeComponent();
        _selectedRoom = selectedRoom;
        Console.WriteLine("Selected Room: " + selectedRoom.Name);
        _viewModel = ServiceHelper.GetService<LendingViewModel>();
        BindingContext = _viewModel;
    }
    
    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.GetLending(_selectedRoom);
    }
}