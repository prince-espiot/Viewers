using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeViewers.EntityFramework.DTOs
{
    public class YouTubeViewerDto
    {
        public Guid Id { get; set; }
        public required string? Username { get; set; }
        public bool IsSubcribed { get; set; }
        public bool IsMember { get; set; }
    }
}
