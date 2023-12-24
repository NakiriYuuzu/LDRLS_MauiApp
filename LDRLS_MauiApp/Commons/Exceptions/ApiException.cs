using LDRLS_MauiApp.Models.Response;

namespace LDRLS_MauiApp.Commons.Exceptions;

public class ApiException(Response response, string message) : Exception(message)
{
    public Response ApiResponse { get; } = response;
}