using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SQLitePCL;

namespace YouTubeViewers.EntityFramework
{
    public class DesignTimeYouTubeViewersDbContextFactory : IDesignTimeDbContextFactory<YouTubeViewersDbContext>
    {
        public YouTubeViewersDbContext CreateDbContext(string[] args = null)
        {
            // Initialize SQLite provider
            Batteries.Init();

            var optionsBuilder = new DbContextOptionsBuilder<YouTubeViewersDbContext>();
            optionsBuilder.UseSqlite("Data Source=Project.db");

            return new YouTubeViewersDbContext(optionsBuilder.Options);
        }
    }
}
