using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace AutoParc.DataContext;

public class MainDbContextFactory : IDesignTimeDbContextFactory<MainDbContext>
{
    public MainDbContext CreateDbContext(string[] args)
    {
        var configurationBuilder = new ConfigurationBuilder();
        configurationBuilder.SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");
        var configuration = configurationBuilder.Build();
        
        DbContextOptionsBuilder<MainDbContext> builder = new DbContextOptionsBuilder<MainDbContext>();
        
        builder.UseSqlServer(configuration.GetConnectionString("AutoParcDb"));
            
        return new MainDbContext(builder.Options);
    }
}