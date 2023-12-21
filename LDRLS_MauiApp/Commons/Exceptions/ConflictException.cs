using LDRLS_MauiApp.Models.Response;

namespace LDRLS_MauiApp.Commons.Exceptions;

public class ConflictException(Response response) : Exception("A conflict occurred.")
{
    public Response ConflictResponse { get; } = response;
}