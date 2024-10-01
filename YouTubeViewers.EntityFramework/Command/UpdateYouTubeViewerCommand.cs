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
    public class UpdateYouTubeViewerCommand : IUpdateYouTubeViewerCommand
    {
        private readonly YouTubeViewersDbContextFactory? _youTubeViewersDbContextFactory;

        public UpdateYouTubeViewerCommand(YouTubeViewersDbContextFactory? youTubeViewersDbContextFactory)
        {
            _youTubeViewersDbContextFactory = youTubeViewersDbContextFactory;
        }
        public async Task Execute(YouTubeViewer youTubeViewers)
        {
            using (YouTubeViewersDbContext context = _youTubeViewersDbContextFactory.Create())
            {
                //await Task.Delay(3000);
                // Find the existing entity from the database
                var existingYouTubeViewerDto = await context.YouTubeViewers
                    .FirstOrDefaultAsync(v => v.Id == youTubeViewers.Id);

                if (existingYouTubeViewerDto != null)
                {
                    // Update the properties
                    existingYouTubeViewerDto.Username = youTubeViewers.Username;
                    existingYouTubeViewerDto.IsSubcribed = youTubeViewers.IsSubcribed;  // Fixed the typo
                    existingYouTubeViewerDto.IsMember = youTubeViewers.IsMember;

                    // Save the changes to the database asynchronously
                    await context.SaveChangesAsync();
                }
                else
                {
                    // Handle the case where the entity was not found
                    throw new InvalidOperationException("YouTube viewer not found.");
                }
            }
        }
    }
}
