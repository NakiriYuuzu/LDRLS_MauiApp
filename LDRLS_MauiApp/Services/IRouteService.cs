using LDRLS_MauiApp.Models;

namespace LDRLS_MauiApp.Services;

public interface IRouteService
{
    void Push(Routes routes, object? parameter = null);
    void Pop();
}