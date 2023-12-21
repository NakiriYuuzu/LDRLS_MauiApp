using System.Net;
using System.Net.Http.Headers;
using LDRLS_MauiApp.Commons.Exceptions;
using LDRLS_MauiApp.Models.Responses;
using Newtonsoft.Json;

namespace LDRLS_MauiApp.Services;

public class ApiService(HttpClient client)
{
    private readonly JsonSerializerSettings _serializerSettings = new()
    {
        NullValueHandling = NullValueHandling.Ignore
    };

    private async Task SetBearerTokenAsync()
    {
        var token = await SecureStorage.GetAsync("auth_token");
        if (!string.IsNullOrEmpty(token))
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
    }

    private async Task<T> ParseResponseAsync<T>(HttpResponseMessage response)
    {
        switch (response.StatusCode)
        {
            case HttpStatusCode.OK:
            {
                var body = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(body, _serializerSettings) ?? throw new InvalidOperationException();
            }
            case HttpStatusCode.Unauthorized: // TODO: Fix this
            {
                throw new UnauthorizedAccessException("Unauthorized");
            }
            case HttpStatusCode.Conflict:
            {
                var body = await response.Content.ReadAsStringAsync();
                var conflictResponse = JsonConvert.DeserializeObject<Response>(body, _serializerSettings);
                if (conflictResponse != null) throw new ConflictException(conflictResponse);
                throw new InvalidOperationException();
            }
            default:
                throw new HttpRequestException($"request failed with status code: {response.StatusCode}");
        }
    }

    public async Task<T> GetAsync<T>(string uri)
    {
        try
        {
            var response = await client.GetAsync(uri);
            return await ParseResponseAsync<T>(response);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<T> GetAsync<T>(string uri, string param)
    {
        try
        {
            var response = await client.GetAsync($"{uri}/{param}");
            return await ParseResponseAsync<T>(response);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<T> PostAsync<T>(string uri, object input)
    {
        try
        {
            var serializedEntity = JsonConvert.SerializeObject(input, _serializerSettings);
            var content = new StringContent(serializedEntity, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync(uri, content);
            return await ParseResponseAsync<T>(response);
        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR:" + e.Message);
            throw;
        }
    }

    public async Task DeleteAsync(string uri)
    {
        try
        {
            await client.DeleteAsync(uri);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}