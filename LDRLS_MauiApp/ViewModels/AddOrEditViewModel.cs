using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LDRLS_MauiApp.Commons.Exceptions;
using LDRLS_MauiApp.Models.Response;
using LDRLS_MauiApp.Properties;
using LDRLS_MauiApp.Services;
using UraniumUI.Dialogs;

namespace LDRLS_MauiApp.ViewModels;

public partial class AddOrEditViewModel(ApiService apiService, IDialogService dialogService) : ObservableObject
{
    [ObservableProperty] private string _title = "Add";
    [ObservableProperty] private bool _isLoading;
    [ObservableProperty] private bool _isEnabled = true;

    [ObservableProperty] private string _name = string.Empty;
    [ObservableProperty] private int _roomSize;
    [ObservableProperty] private string _roomType = string.Empty;
    [ObservableProperty] private string[] _gradeChosen = ["BACHELOR", "MASTER"];
    [ObservableProperty] private int _grade;
    
    private void SetLoading(bool isLoading)
    {
        IsLoading = isLoading;
        IsEnabled = !isLoading;
    }

    public void IsAddOrEdit()
    {
        Title = "Add";
    }

    [RelayCommand]
    private async Task BackToRoot()
    {
        await RouteService.PopBackStackAsync();
    }

    [RelayCommand]
    private async Task AddOn()
    {
        Console.WriteLine("AddOn");
        SetLoading(true);
        try
        {
            var request = new 
            {
                name = Name,
                roomSize = RoomSize,
                roomType = RoomType,
                roomAccess = Grade
            };
            var result = await apiService.PostAsync<Response>(DefaultConfig.ApiRoom, request);
            SetLoading(false);
            if (result.Success)
            {
                await dialogService.ConfirmAsync("Success", "Navigation to Setting Page.");
                await RouteService.PopBackStackAsync();
            }
            else
            {
                await dialogService.ConfirmAsync("Failed", result.Result);
            }
        }
        catch (ApiException e)
        {
            SetLoading(false);
            await dialogService.ConfirmAsync("Failed", $"{e.Message}: {e.ApiResponse.Result}");
        }
        catch (Exception e)
        {
            SetLoading(false);
            await dialogService.ConfirmAsync("Failed", e.Message);
        }
    }
}