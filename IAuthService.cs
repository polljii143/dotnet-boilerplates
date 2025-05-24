/// <summary>
/// Defines a service interface for authentication and authorization operations.
/// </summary>
public interface IAuthService
{
    /// <summary>
    /// Authenticates a user and generates OAuth tokens.
    /// </summary>
    /// <param name="model">The authentication request containing username and password.</param>
    /// <returns>OAuth response with access token, refresh token, and other authentication data, or null if authentication fails.</returns>
    OAuthResponse? Login(AuthRequest model);
    
    /// <summary>
    /// Handles mobile-specific authentication flow.
    /// </summary>
    /// <param name="model">The authentication request containing username and password.</param>
    /// <returns>OAuth response with tokens configured for mobile clients.</returns>
    OAuthResponse Mobile(AuthRequest model);
    
    /// <summary>
    /// Refreshes an expired access token using a valid refresh token.
    /// </summary>
    /// <param name="model">The refresh request containing username and refresh token.</param>
    /// <returns>New OAuth response with updated tokens, or null if refresh token is invalid.</returns>
    OAuthResponse? RefreshToken(RefreshRequest model);
    
    /// <summary>
    /// Generates OAuth data for a specified user and role.
    /// </summary>
    /// <param name="username">The username to generate tokens for.</param>
    /// <param name="userRole">The role assigned to the user.</param>
    /// <returns>OAuth response containing the generated tokens and role information, or null if generation fails.</returns>
    OAuthResponse? GenerateOauthData(string username, string userRole);
    
    /// <summary>
    /// Generates a JWT access token for the specified user and role.
    /// </summary>
    /// <param name="username">The username to include in the token claims.</param>
    /// <param name="role">The role to include in the token claims.</param>
    /// <returns>The generated JWT token string.</returns>
    string GenerateJwtToken(string username, string role);
    
    /// <summary>
    /// Generates a new refresh token.
    /// </summary>
    /// <returns>A secure random refresh token string.</returns>
    string GenerateRefreshToken();
    
    /// <summary>
    /// Verifies if a refresh token is valid for the specified user.
    /// </summary>
    /// <param name="username">The username associated with the refresh token.</param>
    /// <param name="refreshToken">The refresh token to verify.</param>
    /// <returns>The user's role if valid, or throws an exception if invalid.</returns>
    string VerifyRefreshToken(string username, string refreshToken);
    
    /// <summary>
    /// Verifies user credentials and retrieves the user's role.
    /// </summary>
    /// <param name="username">The username to verify.</param>
    /// <param name="password">The password to verify.</param>
    /// <returns>The user's role if authentication succeeds, or throws an exception if authentication fails.</returns>
    string VerifyUser(string username, string password);
}
