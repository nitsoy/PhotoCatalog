using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhotoCatalog.Core.Interfaces;
using PhotoCatalog.Infrastructure.Data;
using PhotoCatalog.Infrastructure.Data.Repositories;

namespace PhotoCatalog.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var dataPath = Environment.GetEnvironmentVariable("AZURE_DATA_PATH")
                      ?? Path.Combine(AppContext.BaseDirectory, "appdata");
        Directory.CreateDirectory(dataPath);
        var cs = configuration.GetConnectionString("Default")!
                 .Replace("appdata", dataPath.Replace("\\", "/"));

        services.AddDbContext<AppDbContext>(opt => opt.UseSqlite(cs));

        services.AddScoped<IPhotoRepository, PhotoRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
