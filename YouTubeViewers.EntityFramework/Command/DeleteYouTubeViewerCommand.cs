using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeViewers.Domain.Commands;

namespace YouTubeViewers.EntityFramework.Command
{
    public class DeleteYouTubeViewerCommand : IDeleteYouTubeViewerCommand
    {
        private readonly YouTubeViewersDbContextFactory? _youTubeViewersDbContextFactory;

        public DeleteYouTubeViewerCommand(YouTubeViewersDbContextFactory? youTubeViewersDbContextFactory)
        {
            _youTubeViewersDbContextFactory = youTubeViewersDbContextFactory;
        }

        public async Task Execute(Guid id)
        {
            using (YouTubeViewersDbContext context = _youTubeViewersDbContextFactory.Create())
            {
                //await Task.Delay(3000);
                // Find the YouTubeViewerDto by its ID
                var youTubeViewerDto = await context.YouTubeViewers
                    .FirstOrDefaultAsync(v => v.Id == id);

                if (youTubeViewerDto != null)
                {
                    // Remove the entity from the database context
                    context.YouTubeViewers.Remove(youTubeViewerDto);

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
