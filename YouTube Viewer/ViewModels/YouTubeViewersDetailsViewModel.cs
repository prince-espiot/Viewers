﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTube_Viewer.Domain.Models;
using YouTube_Viewer.Stores;

namespace YouTube_Viewer.ViewModels
{
    public class YouTubeViewersDetailsViewModel:ViewModelBase
    {
        private readonly SelectedYouTubeViewerStore? _selectedYouTubeViewerStore;
        private YouTubeViewer? SelectedYouTubeViewer => _selectedYouTubeViewerStore?.SelectedYouTubeViewer;


        public bool HasSelectedYouTubeViewer => SelectedYouTubeViewer != null;
        public string? Username => SelectedYouTubeViewer?.Username ?? "Unknown";

        public string? IsSubscribedDisplay => (SelectedYouTubeViewer?.IsSubcribed ?? false) ? "Yes" : "No";

        public string? IsMemberDisplay=> (SelectedYouTubeViewer?.IsMember ?? false) ? "Yes" : "No";

       

        public YouTubeViewersDetailsViewModel(SelectedYouTubeViewerStore? selectedYouTubeViewerStore)
        {
           
            _selectedYouTubeViewerStore = selectedYouTubeViewerStore;
            _selectedYouTubeViewerStore.SelectedYouTubeViewerChanged += _selectedYouTubeViewerStore_SelectedYouTubeViewerChanged;
        }

        protected override void Dispose()
        {
            _selectedYouTubeViewerStore.SelectedYouTubeViewerChanged -= _selectedYouTubeViewerStore_SelectedYouTubeViewerChanged;
            base.Dispose();
        }

        private void _selectedYouTubeViewerStore_SelectedYouTubeViewerChanged()
        {
            OnPropertyChanged(nameof(HasSelectedYouTubeViewer));
            OnPropertyChanged(nameof(Username));
            OnPropertyChanged(nameof(IsSubscribedDisplay));
            OnPropertyChanged(nameof(IsMemberDisplay));
        }
    }
}
