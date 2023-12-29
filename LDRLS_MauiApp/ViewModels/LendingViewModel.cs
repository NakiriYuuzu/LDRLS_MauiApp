using System.Collections.ObjectModel;
using System.Globalization;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LDRLS_MauiApp.Models;
using LDRLS_MauiApp.Models.Response;
using LDRLS_MauiApp.Properties;
using LDRLS_MauiApp.Services;
using UraniumUI.Dialogs;

namespace LDRLS_MauiApp.ViewModels;

public partial class LendingViewModel : ObservableObject
{
    public class LendingTimeTable
    {
        public string Time { get; set; }
        public bool IsAvailable { get; set; }
    }
    
    private readonly ApiService _apiService;
    private readonly HttpClient _httpClient;
    private readonly IDialogService _dialogService;
    
    private Room _selectedRoom;
    
    [ObservableProperty] private bool _isLoading;
    [ObservableProperty] private bool _isEnabled = true;
    [ObservableProperty] private DateTime _date = DateTime.Now;
    [ObservableProperty] private string _timeString = string.Empty;

    [ObservableProperty] private ObservableCollection<LendingTimeTable> _items = new();
    [ObservableProperty] private ObservableCollection<LendingTimeTable> _selectedItems = new();

    public LendingViewModel(HttpClient httpClient, ApiService apiService, IDialogService dialogService)
    {
        _httpClient = httpClient;
        _apiService = apiService;
        _dialogService = dialogService;
        for (var i = 8; i < 21; i++)
        {
            string formattedTime = i < 10 ? $"0{i}:00" : $"{i}:00";

            Items.Add(new LendingTimeTable
            {
                Time = formattedTime,
                IsAvailable = true
            });
        }

    }

    public void GetLending(Room selectedRoom)
    {
        _selectedRoom = selectedRoom;
    }

    [RelayCommand]
    private void OnDatePicker()
    {
        // TODO: Get Lending Data see what can i borrow.
    }

    [RelayCommand]
    private async Task OnSend()
    {
        var requestData = new
        {
            roomId = _selectedRoom.Id,
            adminId = "",
            startTime = ConvertDateToMil().Keys.First(),
            endTime = ConvertDateToMil().Values.First(),
            validator = true
        };
        try
        {
            var response = await _apiService.PostAsync<Response>(DefaultConfig.ApiLending, requestData);
            if (response.Success)
            {
                await _dialogService.ConfirmAsync("Lending Success", "Please wait for admin to validate");
                RouteService.PopAsync();
            }
            else
            {
                await _dialogService.ConfirmAsync("Lending Failed", "Borrowed by others or not available");
            }
        } catch (Exception e)
        {
            await _dialogService.ConfirmAsync("Lending Failed", e.Message);
        }
    }

    private Dictionary<long, long> ConvertDateToMil()
    {
        var pickerTime = SelectedItems.Select(x => x.Time).ToList();
        var startTime = $"{Date:MM/dd/yyyy} {pickerTime[0]}";
        var endTime = $"{Date:MM/dd/yyyy} {pickerTime[^1]}";
        Console.WriteLine($"startTime: {startTime}, endTime: {endTime}");
        DateTime convertStart = DateTime.ParseExact(startTime, "MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture);
        DateTime unixStart = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        DateTime convertEnd = DateTime.ParseExact(endTime, "MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture);
        DateTime unixEnd = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        long millisecondsSinceUnixStart = (long)(convertStart.ToUniversalTime() - unixStart).TotalMilliseconds;
        long millisecondsSinceUnixEnd = (long)(convertEnd.ToUniversalTime() - unixEnd).TotalMilliseconds;
        
        return new Dictionary<long, long>
        {
            {millisecondsSinceUnixStart, millisecondsSinceUnixEnd}
        };
    }
}