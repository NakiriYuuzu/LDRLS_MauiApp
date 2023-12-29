using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LDRLS_MauiApp.Models;
using LDRLS_MauiApp.Models.Response;
using LDRLS_MauiApp.Properties;
using LDRLS_MauiApp.Services;
using LDRLS_MauiApp.Views;
using Newtonsoft.Json;
using UraniumUI.Dialogs;

namespace LDRLS_MauiApp.ViewModels;

public partial class HomeViewModel(IDialogService dialogService, HttpClient httpClient) : ObservableObject
{
    [ObservableProperty] private bool _isLoading;
    [ObservableProperty] private bool _isEnabled = true;
    [ObservableProperty] private ObservableCollection<Room> _rooms;
    
    private void SetLoading(bool isLoading)
    {
        IsLoading = isLoading;
        IsEnabled = !isLoading;
    }
    
    public async Task GetRooms()
    {
        SetLoading(true);
        try
        {
            var response = await httpClient.GetStringAsync(DefaultConfig.ApiRoom);
            var data = JsonConvert.DeserializeObject<RoomResponse>(response);
            if (data == null)
            {
                SetLoading(false);
                await dialogService.ConfirmAsync("Error", "No Data here.");
                return;
            }

            SetLoading(false);
            if (data.Success)
            {
                Rooms = new ObservableCollection<Room>(data.Result);
            }
            else await dialogService.ConfirmAsync("Error", "Unable to get Data.");
        }
        catch (Exception e)
        {
            SetLoading(false);
            await dialogService.ConfirmAsync("Error", e.Message);
        }
    }

    [RelayCommand]
    private async Task NoImplementedOn()
    {
        await dialogService.ConfirmAsync("Error", "Not Implemented yet.");
    }
    
    [RelayCommand]
    private async Task GoToLending(Room selectedRoom)
    {
        await Shell.Current.Navigation.PushAsync(new LendingPage(selectedRoom));
    }
}