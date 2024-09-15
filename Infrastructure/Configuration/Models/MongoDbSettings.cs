namespace Infrastructure.Configuration.Models;

public class MongoDbSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string TaskListsCollection { get; set; } = null!;
}