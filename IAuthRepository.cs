/// <summary>
/// Defines a repository interface for authentication-related data operations.
/// </summary>
/// <remarks>
/// This repository handles persistence operations related to user authentication,
/// particularly focused on refresh token management and employee retrieval.
/// It works with the Employee entity which contains authentication-related fields
/// such as Username and RefreshToken.
/// NOTE: The Employee entity is your User entity or any entity you want to retrieve after authentication/authorization.
/// </remarks>
public interface IAuthRepository
{
    /// <summary>
    /// Stores a refresh token for a specific user in the database.
    /// </summary>
    /// <param name="username">The username of the employee.</param>
    /// <param name="refreshToken">The refresh token to be stored.</param>
    /// <remarks>
    /// This method updates the RefreshToken field in the Employee record
    /// associated with the specified username.
    /// </remarks>
    void StoreRefreshToken(string username, string refreshToken);

    /// <summary>
    /// Retrieves an employee by their username and refresh token.
    /// </summary>
    /// <param name="username">The username of the employee to retrieve.</param>
    /// <param name="refreshToken">The refresh token to validate against the stored value.</param>
    /// <returns>The Employee entity if found with matching username and refresh token; otherwise, null.</returns>
    /// <remarks>
    /// This method is primarily used during token refresh operations to validate
    /// that a refresh token belongs to the specified user.
    /// </remarks>
    Employee? Retrieve(string username, string refreshToken);

    /// <summary>
    /// Retrieves an employee by their username.
    /// </summary>
    /// <param name="username">The username of the employee to retrieve.</param>
    /// <returns>The Employee entity if found; otherwise, null.</returns>
    /// <remarks>
    /// This method is commonly used during authentication to verify user credentials
    /// and retrieve user information such as role and permissions.
    /// </remarks>
    Employee? Retrieve(string username);
}
