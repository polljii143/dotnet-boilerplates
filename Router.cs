/// <summary>
/// Router class providing a centralized API communication layer for the application.
/// Handles HTTP requests to various web service endpoints with appropriate authentication and payloads.
/// </summary>
public class Router
{
    /// <summary>
    /// Represents the available web service endpoints that can be accessed through the Router.
    /// NOTE: Change these are entirely up to you and how many web service endpoints you want to access.
    /// </summary>
    public enum WebServices
    {
        CreateRecord,
        RemoveRecord,
        UpdateRecord,
        ListRecords,
        SearchRecords
    }

    /// <summary>
    /// Base URL for all API requests. Should be configured for the appropriate environment.
    /// </summary>
    private const string BaseUrl = "ApiBaseUrlHere";

    /// <summary>
    /// Determines the appropriate HTTP method type based on the requested web service.
    /// </summary>
    /// <param name="webService">The web service to be accessed.</param>
    /// <returns>The corresponding HTTP method type (GET, POST, PUT, DELETE).</returns>
    private static MethodType RequestMethod(WebServices webService)
    {
        return webService switch
        {
            WebServices.CreateRecord => MethodType.Post,
            WebServices.RemoveRecord => MethodType.Delete,
            WebServices.UpdateRecord => MethodType.Put,
            _ => MethodType.Get
        };
    }

    /// <summary>
    /// Constructs the request URL path based on the web service and optional parameters.
    /// </summary>
    /// <param name="webService">The web service to be accessed.</param>
    /// <param name="parameters">Optional dictionary of parameters to include in the URL.</param>
    /// <returns>The constructed URL path string.</returns>
    private static string RequestUrl(WebServices webService,
        Dictionary<string, string>? parameters = null)
    {
        string urlRequest;
        switch (webService) 
        {
            case WebServices.CreateRecord:
                urlRequest = "/record";
                break;
            case WebServices.RemoveRecord:
                urlRequest = $"/record/remove?ids={parameters!["ids"]}";
                break;
            case WebServices.UpdateRecord:
                urlRequest = $"/record/{parameters!["id"]}";
                break;
            case WebServices.ListRecords:
                urlRequest =
                    $"/record/list?offset={parameters!["offset"]}&limit={parameters!["limit"]}";
                break;
            case WebServices.SearchRecords:
                urlRequest = $"/record/search?keyword={parameters!["keyword"]}";
                break;
            default:
                return "";
        }

        return urlRequest;
    }

    /// <summary>
    /// Executes an HTTP request to the specified web service endpoint.
    /// </summary>
    /// <param name="webService">The web service to be accessed.</param>
    /// <param name="closure">Callback action to handle the HTTP response.</param>
    /// <param name="payload">Optional object to be serialized and sent as the request body.</param>
    /// <param name="parameters">Optional dictionary of parameters to include in the URL.</param>
    /// <returns>An asynchronous task representing the HTTP request operation.</returns>
    public static async Task Request(WebServices webService,
        Action<HttpResponseMessage> closure,
        object? payload = null, Dictionary<string, string>? parameters = null)
    {
        var client = new HttpClient();
        var uri = new Uri(BaseUrl + RequestUrl(webService, parameters));
        
        // Configure request headers based on the web service
        switch (webService)
        {
            default:
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer",
                        "AccessTokenHere");
                client.DefaultRequestHeaders.Add("User-Agent",
                    "CurrentUserHere");
                break;
        }

        // Execute the appropriate HTTP method based on the request type
        var httpMethod = RequestMethod(webService);
        HttpResponseMessage? response;
        string jsonObject;
        StringContent objectParams;
        
        switch (httpMethod)
        {
            case MethodType.Put:
                jsonObject = JsonConvert.SerializeObject(payload);
                objectParams = new StringContent(jsonObject, Encoding.UTF8,
                    "application/json");
                response = await client.PutAsync(uri, objectParams);
                break;
            case MethodType.Delete:
                response = await client.DeleteAsync(uri);
                break;
            case MethodType.Post:
                jsonObject = JsonConvert.SerializeObject(payload);
                objectParams = new StringContent(jsonObject, Encoding.UTF8,
                    "application/json");
                response = await client.PostAsync(uri, objectParams);
                break;
            default:
                response = await client.GetAsync(uri);
                break;
        }

        // Invoke the callback with the response
        closure(response);
    }

    /// <summary>
    /// Represents the supported HTTP method types.
    /// </summary>
    private enum MethodType
    {
        Get,
        Post,
        Put,
        Delete
    }
}
