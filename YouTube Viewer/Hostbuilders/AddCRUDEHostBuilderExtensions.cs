using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using YouTubeViewers.Domain.Commands;
using YouTubeViewers.Domain.Queries;
using YouTubeViewers.EntityFramework.Command;
using YouTubeViewers.EntityFramework.Queries;

namespace YouTube_Viewer.Hostbuilders
{
    public static class AddCRUDEHostBuilderExtensions
    {
        public static IHostBuilder AddDbCRUDContext(this IHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddSingleton<IGetAllYouTubeViewersQuery, GetAllYouTubeViewersQuery>();
                services.AddSingleton<ICreateYouTubeViewerCommand, CreateYouTubeViewerCommand>();
                services.AddSingleton<IUpdateYouTubeViewerCommand, UpdateYouTubeViewerCommand>();
                services.AddSingleton<IDeleteYouTubeViewerCommand, DeleteYouTubeViewerCommand>();
            });
            return builder;
        }
    }
}
