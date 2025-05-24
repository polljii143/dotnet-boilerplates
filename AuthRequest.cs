/// <summary>
/// Represents an authentication request containing user credentials.
/// </summary>
/// <remarks>
/// This class is used for authentication flows in both web API and desktop applications.
/// It serves as a data transfer object (DTO) for login operations through the IAuthService.
/// </remarks>
public class AuthRequest
{
    /// <summary>
    /// Gets or sets the username for authentication.
    /// </summary>
    /// <value>The user's identifier or email address.</value>
    public string? Username { get; set; }

    /// <summary>
    /// Gets or sets the password for authentication.
    /// </summary>
    /// <value>The user's password in plain text form.</value>
    public string? Password { get; set; }
}
