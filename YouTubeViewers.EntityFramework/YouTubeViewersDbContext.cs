using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeViewers.EntityFramework.DTOs;

namespace YouTubeViewers.EntityFramework
{
    public class YouTubeViewersDbContext :DbContext 
    {
       
        public DbSet<YouTubeViewerDto> YouTubeViewers { get; set; }

        public YouTubeViewersDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
