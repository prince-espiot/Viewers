using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTube_Viewer.Domain.Models;
using YouTubeViewers.Domain.Commands;
using YouTubeViewers.EntityFramework.DTOs;

namespace YouTubeViewers.EntityFramework.Command
{
    public class CreateYouTubeViewerCommand : ICreateYouTubeViewerCommand
    {
        private readonly YouTubeViewersDbContextFactory? _youTubeViewersDbContextFactory;

        public CreateYouTubeViewerCommand(YouTubeViewersDbContextFactory? youTubeViewersDbContextFactory)
        {
            _youTubeViewersDbContextFactory = youTubeViewersDbContextFactory;
        }
        public async Task Execute(YouTubeViewer youTubeViewers)
        {
            using (YouTubeViewersDbContext context = _youTubeViewersDbContextFactory.Create())
            {
               // await Task.Delay(3000);
                YouTubeViewerDto youTubeViewerDto = new YouTubeViewerDto()
                {
                    Id = youTubeViewers.Id,
                    Username = youTubeViewers.Username,
                    IsSubcribed = youTubeViewers.IsSubcribed,
                    IsMember = youTubeViewers.IsMember,
                    
                };

                // Add the new YouTubeViewerDto to the database context
                context.YouTubeViewers.Add(youTubeViewerDto);

                // Save the changes to the database asynchronously
                await context.SaveChangesAsync();
            }
        }
    }
}
