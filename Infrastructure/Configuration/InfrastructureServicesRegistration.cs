using Application.Interfaces.Repositories;
using Infrastructure.Configuration.Models;
using Infrastructure.Repositories.Mongo;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace Infrastructure.Configuration;

public static class InfrastructureServicesRegistration
{
    public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        var mongoSettingsSection = configuration.GetSection("MongoDbSettings");
        services.Configure<MongoDbSettings>(mongoSettingsSection);
        services.AddSingleton<IMongoClient>(_ => new MongoClient(mongoSettingsSection[nameof(MongoDbSettings.ConnectionString)]));
        services.AddSingleton<IMongoDatabase>(provider =>
        {
            var client = provider.GetRequiredService<IMongoClient>();
            return client.GetDatabase(mongoSettingsSection[nameof(MongoDbSettings.DatabaseName)]);
        });

        services.AddScoped<ITaskListsRepository, MongoTaskListsRepository>();

        return services;
    }
}