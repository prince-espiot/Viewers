using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTube_Viewer.Domain.Models;
using YouTubeViewers.Domain.Queries;
using YouTubeViewers.EntityFramework.DTOs;

namespace YouTubeViewers.EntityFramework.Queries
{
    public class GetAllYouTubeViewersQuery : IGetAllYouTubeViewersQuery
    {
        private readonly YouTubeViewersDbContextFactory? _youTubeViewersDbContextFactory;

        public GetAllYouTubeViewersQuery(YouTubeViewersDbContextFactory? youTubeViewersDbContextFactory)
        {
            _youTubeViewersDbContextFactory = youTubeViewersDbContextFactory;
        }

        public async Task<IEnumerable<YouTubeViewer>> Execute()
        {
            
                   
            using (YouTubeViewersDbContext? context = _youTubeViewersDbContextFactory?.Create())
            {
                IEnumerable<YouTubeViewerDto> youTubeViewerDtos = await context?.YouTubeViewers.ToListAsync();

                // Map the DTOs to domain models
                var youTubeViewers = youTubeViewerDtos.Select(dto => new YouTubeViewer
                (
                     dto.Id,
                     dto.Username,
                     dto.IsSubcribed,
                     dto.IsMember
                ));

                return youTubeViewers;
            }

             
        }
    }
}
