using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTube_Viewer.Domain.Models;
using YouTubeViewers.Domain.Commands;
using YouTubeViewers.Domain.Queries;

namespace YouTube_Viewer.Stores
{
    public class YouTubeViewersStore
    {

        private readonly ICreateYouTubeViewerCommand? _createYouTubeViewerCommand;
        private readonly IUpdateYouTubeViewerCommand? _updateYouTubeViewerCommand;
        private readonly IDeleteYouTubeViewerCommand? _deleteYouTubeViewerCommand;
        private readonly IGetAllYouTubeViewersQuery? _getAllYouTubeViewersQuery;

        private readonly List<YouTubeViewer>? _youTubeViewers;
        public IEnumerable<YouTubeViewer>? YouTubeViewers => _youTubeViewers;


        public event Action YouTubeViewersLoaded;
        public event Action<YouTubeViewer>? YouTubeViewersAdded;
        public event Action<YouTubeViewer>? YouTubeViewersUpdated;
        public event Action<Guid>? YouTubeViewerDeleted;


        public YouTubeViewersStore(
        ICreateYouTubeViewerCommand createYouTubeViewerCommand,
        IUpdateYouTubeViewerCommand updateYouTubeViewerCommand,
        IDeleteYouTubeViewerCommand deleteYouTubeViewerCommand,
        IGetAllYouTubeViewersQuery getAllYouTubeViewersQuery)
        {
            _youTubeViewers = new List<YouTubeViewer>();
            _createYouTubeViewerCommand = createYouTubeViewerCommand;
            _updateYouTubeViewerCommand = updateYouTubeViewerCommand;
            _deleteYouTubeViewerCommand = deleteYouTubeViewerCommand;
            _getAllYouTubeViewersQuery = getAllYouTubeViewersQuery;
        }

        public async Task Load()
        {
            // Load all YouTube viewers from the database
            IEnumerable<YouTubeViewer> youTubeViewers = await _getAllYouTubeViewersQuery?.Execute();
            _youTubeViewers?.Clear();
            _youTubeViewers?.AddRange(youTubeViewers);
            YouTubeViewersLoaded?.Invoke();
        }
        public async Task Add(YouTubeViewer youTubeViewer)
        {
            // Add to the database
            await _createYouTubeViewerCommand?.Execute(youTubeViewer);

            // Add to the in-memory list and trigger event
            _youTubeViewers?.Add(youTubeViewer);
            YouTubeViewersAdded?.Invoke(youTubeViewer);
        }

        public async Task Update(YouTubeViewer youTubeViewer)
        {
            // Update the database
            await _updateYouTubeViewerCommand?.Execute(youTubeViewer);

            // Update the in-memory list and trigger event
            YouTubeViewer? existingViewer = _youTubeViewers?.FirstOrDefault(v => v.Id == youTubeViewer.Id);
            if (existingViewer != null)
            {
                int index = _youTubeViewers.IndexOf(existingViewer);
                if (index != -1)
                    _youTubeViewers[index] = youTubeViewer;
                else
                    _youTubeViewers?.Add(youTubeViewer);
            }

            YouTubeViewersUpdated?.Invoke(youTubeViewer);
        }

        public async Task Delete(Guid id)
        {
            // Delete from the database
            await _deleteYouTubeViewerCommand.Execute(id);

            // Remove from the in-memory list and trigger event
            YouTubeViewer? youTubeViewer = _youTubeViewers?.FirstOrDefault(v => v.Id == id);
            if (youTubeViewer != null)
            {
                _youTubeViewers.Remove(youTubeViewer);
                YouTubeViewerDeleted?.Invoke(id);
            }
        }
    }
}
