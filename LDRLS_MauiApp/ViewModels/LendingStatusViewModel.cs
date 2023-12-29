using System.Collections.ObjectModel;
using System.Net.Http.Headers;
using CommunityToolkit.Mvvm.ComponentModel;
using LDRLS_MauiApp.Models;
using LDRLS_MauiApp.Models.Response;
using LDRLS_MauiApp.Properties;
using Newtonsoft.Json;
using UraniumUI.Dialogs;

namespace LDRLS_MauiApp.ViewModels;

public partial class LendingStatusViewModel(IDialogService dialogService, HttpClient httpClient) : ObservableObject
{
    [ObservableProperty] private bool _isLoading;
    [ObservableProperty] private bool _isEnabled = true;
    [ObservableProperty] private ObservableCollection<Lending> _lending;
    
    private void SetLoading(bool isLoading)
    {
        IsLoading = isLoading;
        IsEnabled = !isLoading;
    }

    public async Task GetLending()
    {
        // header token
        try
        {
            var token = await SecureStorage.GetAsync(DefaultConfig.StorageToken);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = httpClient.GetStringAsync(DefaultConfig.ApiLending);
            var result = JsonConvert.DeserializeObject<LendingResponse>(await response);
            Lending = new ObservableCollection<Lending>(result.Result);
            Console.WriteLine(Lending);
        }
        catch (Exception e)
        {
            await dialogService.ConfirmAsync("Error", e.Message);
        }
    }
}