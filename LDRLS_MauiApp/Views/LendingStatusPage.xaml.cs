using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LDRLS_MauiApp.Services;
using LDRLS_MauiApp.ViewModels;
using UraniumUI.Pages;

namespace LDRLS_MauiApp.Views;

public partial class LendingStatusPage : UraniumContentPage
{
    private readonly LendingStatusViewModel _viewModel;
    public LendingStatusPage()
    {
        InitializeComponent();
        _viewModel = ServiceHelper.GetService<LendingStatusViewModel>();
        BindingContext = _viewModel;
    }
    
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.GetLending();
    }
}