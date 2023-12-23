using LDRLS_MauiApp.Models;
using LDRLS_MauiApp.Properties;

namespace LDRLS_MauiApp.Services;

public class RouteService: IRouteService
{
    private readonly IList<Routes> _rootRoutes = Enum.GetValues(typeof(Routes)).Cast<Routes>().ToList();
    
    public async void Push(Routes routes, object? parameter = null)
    {
        if (parameter != null)
        {
            await Shell.Current.GoToAsync(GetRoutePath(routes), true, new Dictionary<string, object>
            {
                [DefaultConfig.ParametersKey] = parameter
            });
            return;
        }
        await Shell.Current.GoToAsync(GetRoutePath(routes), true);
    }

    public void Pop()
    {
        Shell.Current.Navigation.PopAsync();
    }

    private string GetRoutePath(Routes routes)
    {
        if (_rootRoutes.Contains(routes)) return $"///{routes.ToString()}";
        return routes.ToString();
    }
}