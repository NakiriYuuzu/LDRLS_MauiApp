using System.Diagnostics;
using LDRLS_MauiApp.Models;

namespace LDRLS_MauiApp.Services;

public static class RouteService
{
    // 重置堆栈并导航到指定路由
    public static async Task GoToAsyncResetStack(Routes route)
    {
        await Shell.Current.GoToAsync($"//{route.ToString()}", true);
    }

    // 导航到指定路由
    public static async Task GoToAsync(Routes route)
    {
        try
        {
            await Shell.Current.GoToAsync(route.ToString(), true);
        }
        catch (Exception ex)
        {
            // 处理导航错误
            Debug.WriteLine($"导航错误: {ex.Message}");
        }
    }

    // 带参数的导航
    public static async Task GoToAsync(Routes route, Dictionary<string, string> parameters)
    {
        var queryString = string.Join("&", parameters.Select(x => $"{Uri.EscapeDataString(x.Key)}={Uri.EscapeDataString(x.Value)}"));
        try
        {
            await Shell.Current.GoToAsync($"{route.ToString()}?{queryString}", true);
        }
        catch (Exception ex)
        {
            // 处理导航错误
            Debug.WriteLine($"导航错误: {ex.Message}");
        }
    }

    // 返回到根堆栈
    public static async Task PopBackStackAsync()
    {
        try
        {
            await Shell.Current.Navigation.PopToRootAsync();
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"弹出栈错误: {ex.Message}");
        }
    }

    // 弹出当前页面
    public static void PopAsync()
    {
        try
        {
            Shell.Current.Navigation.PopAsync();
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"弹出页面错误: {ex.Message}");
        }
    }
}
