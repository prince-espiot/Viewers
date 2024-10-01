using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTube_Viewer.Domain.Models;

namespace YouTube_Viewer.Stores
{
    public class YouTubeViewersStore
    {
        private readonly List<YouTubeViewer>? _youTubeViewers;
        public IEnumerable<YouTubeViewer> YouTubeViewers => _youTubeViewers;

        public event Action <YouTubeViewer>? YouTubeViewersAdded;
        public event Action<YouTubeViewer>? YouTubeViewersUpdated;

        public async Task Add(YouTubeViewer youTubeViewer)
        {
            YouTubeViewersAdded?.Invoke (youTubeViewer);
        }

        public async Task Update(YouTubeViewer youTubeViewer)
        {
            YouTubeViewersUpdated.Invoke(youTubeViewer);
        }
    }
}
