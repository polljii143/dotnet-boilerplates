/// <summary>
/// Represents a request to refresh an expired access token using a refresh token.
/// </summary>
/// <remarks>
/// This class is part of the OAuth 2.0 token refresh flow, which allows clients to obtain 
/// new access tokens without requiring the user to re-authenticate. It's used by the
/// RefreshToken method in IAuthService to validate and process token refresh requests.
/// </remarks>
public class RefreshRequest
{
    /// <summary>
    /// Gets or sets the username of the user requesting a token refresh.
    /// </summary>
    /// <value>The identifier for the user whose token is being refreshed.</value>
    public string? Username { get; set; }

    /// <summary>
    /// Gets or sets the refresh token previously issued during authentication.
    /// </summary>
    /// <value>A valid refresh token that was provided in a previous authentication response.</value>
    public string? RefreshToken { get; set; }
}
