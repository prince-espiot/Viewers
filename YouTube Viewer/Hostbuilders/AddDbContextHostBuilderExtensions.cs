using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using YouTubeViewers.EntityFramework;

namespace YouTube_Viewer.Hostbuilders
{
    public static class AddDbContextHostBuilderExtensions
    {
        public static IHostBuilder AddDbContext(this IHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                string connectionString = context.Configuration.GetConnectionString("sqlite");

                services.AddDbContext<YouTubeViewersDbContext>(options =>
                    options.UseSqlite(connectionString));

                services.AddSingleton<YouTubeViewersDbContextFactory>();
            });

            return builder;
        }
    }

}
