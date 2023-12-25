using System.Net;
using System.Net.Http.Headers;
using LDRLS_MauiApp.Commons.Exceptions;
using LDRLS_MauiApp.Models.Response;
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
        var body = await response.Content.ReadAsStringAsync();   
        switch (response.StatusCode)
        {
            case HttpStatusCode.OK:
            {
                return JsonConvert.DeserializeObject<T>(body) ?? throw new Exception("Error for convert JSON.");
            }
            case HttpStatusCode.Unauthorized: // TODO: Fix this
            {
                throw new UnauthorizedAccessException("Unauthorized");
            }
            case HttpStatusCode.BadRequest:
            {
                var badRequestResponse = JsonConvert.DeserializeObject<Response>(body, _serializerSettings);
                if (badRequestResponse != null) throw new ApiException(badRequestResponse, "404");
                throw new InvalidOperationException();
            }
            case HttpStatusCode.Conflict:
            {
                var conflictResponse = JsonConvert.DeserializeObject<Response>(body, _serializerSettings);
                if (conflictResponse != null) throw new ApiException(conflictResponse, "409");
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
            await SetBearerTokenAsync();
            var response = await client.GetStringAsync(uri);
            return JsonConvert.DeserializeObject<T>(response) ?? throw new Exception("Error for convert JSON.");
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
            await SetBearerTokenAsync();
            var response = await client.GetStringAsync($"{uri}/{param}");
            return JsonConvert.DeserializeObject<T>(response) ?? throw new Exception("Error for convert JSON.");
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
            await SetBearerTokenAsync();
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
    
    public async Task<T> PutAsync<T>(string uri, object input)
    {
        try
        {
            await SetBearerTokenAsync();
            var serializedEntity = JsonConvert.SerializeObject(input, _serializerSettings);
            var content = new StringContent(serializedEntity, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PutAsync(uri, content);
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
            await SetBearerTokenAsync();
            await client.DeleteAsync(uri);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}