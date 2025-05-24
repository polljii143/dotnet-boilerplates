/// <summary>
/// Session class implementing the singleton pattern for database context management.
/// This class provides centralized access to database operations throughout the application.
/// Since this is a singleton, you can put here all types of services or data (not just db) you want to preserve in the lifecycle.
/// </summary>
public class Session
{ 
    // Private constructor prevents instantiation from outside the class
    private Session()
    {
    }

    /// <summary>
    /// Singleton instance of the Session class.
    /// Uses C# 6.0+ read-only auto-property initialization for thread-safe lazy initialization.
    /// </summary>
    public static Session Instance { get; } = new();

    /// <summary>
    /// Creates and returns a new database context with configured connection string.
    /// </summary>
    /// <returns>A configured instance of ApiAppContext ready for database operations.</returns>
    public ApiAppContext GetDbContext()
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApiAppContext>();
        optionsBuilder.UseSqlServer("ConnectionStringHere");
        // You can replace "ConnectionStringHere" with your actual connection string.
        return new ApiAppContext(optionsBuilder.Options);
    }
}

/// <summary>
/// Entity Framework DbContext implementation for the API application.
/// Manages database connection and entity sets for data operations.
/// </summary>
/// <param name="options">The options to be used by the DbContext.</param>
public class ApiAppContext(DbContextOptions<ApiAppContext> options)
    : DbContext(options)
{
    /// <summary>
    /// DbSet representing the ApiAppTable entity in the database.
    /// </summary>
    public DbSet<ApiAppTable> ApiAppTables { get; set; }

    /// <summary>
    /// Configures the model that was discovered by convention from the entity types.
    /// </summary>
    /// <param name="modelBuilder">The builder being used to construct the model for this context.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Additional model configuration can be added here
    }
}
