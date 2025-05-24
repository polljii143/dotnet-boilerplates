/// <summary>
/// Defines a generic service interface for CRUD (Create, Retrieve, Update, Delete) operations.
/// </summary>
/// <typeparam name="T">The entity type this service operates on.</typeparam>
public interface ICrudService<T>
{
    /// <summary>
    /// Creates a new entity in the system.
    /// </summary>
    /// <param name="t">The entity to create.</param>
    void Create(T t);

    /// <summary>
    /// Retrieves an entity by its identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the entity.</param>
    /// <returns>The found entity or null if not found.</returns>
    T? Retrieve(long id);

    /// <summary>
    /// Updates an existing entity.
    /// </summary>
    /// <param name="id">The unique identifier of the entity to update.</param>
    /// <param name="t">The entity with updated values.</param>
    void Update(long id, T t);

    /// <summary>
    /// Deletes an entity from the system.
    /// </summary>
    /// <param name="id">The unique identifier of the entity to delete.</param>
    void Delete(long id);

    /// <summary>
    /// Retrieves a paginated list of entities.
    /// </summary>
    /// <param name="offset">The number of items to skip.</param>
    /// <param name="limit">The maximum number of items to return.</param>
    /// <returns>A list of entities based on pagination parameters.</returns>
    List<T> List(int offset, int limit);

    /// <summary>
    /// Searches for entities matching a keyword.
    /// </summary>
    /// <param name="keyword">The search term.</param>
    /// <returns>A list of entities matching the search criteria.</returns>
    List<T> Search(string keyword);
}
