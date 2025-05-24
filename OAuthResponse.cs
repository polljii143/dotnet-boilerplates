/// <summary>
/// Represents the OAuth 2.0 token response structure returned after successful authentication.
/// </summary>
/// <remarks>
/// This class follows standard OAuth 2.0 naming conventions for properties to ensure
/// compatibility with OAuth clients. It is used throughout the authentication flow
/// in both API and desktop applications.
/// </remarks>
public class OAuthResponse
{
    /// <summary>
    /// Gets or sets the access token used for authorization.
    /// </summary>
    /// <value>A JWT token string that provides access to protected resources.</value>
    public string? access_token { get; set; }
    
    /// <summary>
    /// Gets or sets the type of token issued.
    /// </summary>
    /// <value>Typically "Bearer" for JWT authentication.</value>
    public string? token_type { get; set; }
    
    /// <summary>
    /// Gets or sets the token expiration time in seconds.
    /// </summary>
    /// <value>Number of seconds until the access token expires.</value>
    public int? expires_in { get; set; }
    
    /// <summary>
    /// Gets or sets the refresh token used to obtain a new access token.
    /// </summary>
    /// <value>A token string used to request new access tokens when the current one expires.</value>
    public string? refresh_token { get; set; }
    
    /// <summary>
    /// Gets or sets the user's role in the system.
    /// </summary>
    /// <value>String representation of the authenticated user's role.</value>
    public string? role { get; set; }
    
    /// <summary>
    /// Gets or sets the permission scopes granted to this token.
    /// </summary>
    /// <value>List of string identifiers representing access permissions.</value>
    public List<string>? scopes { get; set; }
}
