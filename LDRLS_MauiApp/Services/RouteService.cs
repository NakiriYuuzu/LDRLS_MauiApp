using LDRLS_MauiApp.Models;

namespace LDRLS_MauiApp.Services;

public static class RouteService
{
    public static async Task GoToAsync(Routes route)
    {
        await Shell.Current.GoToAsync(route.ToString(), true);
    }
    
    public static async Task GoToAsync(Routes route, Dictionary<string, string> parameters)
    {
        var queryString = string.Join("&", parameters.Select(x => $"{x.Key}={x.Value}"));
        await Shell.Current.GoToAsync($"{route.ToString()}?{queryString}", true);
    }
    
    public static void PopAsync()
    {
        Shell.Current.Navigation.PopAsync();
    }
}