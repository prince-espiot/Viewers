using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTube_Viewer.Models;
using YouTube_Viewer.Stores;

namespace YouTube_Viewer.ViewModels
{
    public class YouTubeViewersListingViewModel:ViewModelBase
    {
        private readonly ObservableCollection<YouTubeViewersListingItemViewModel>? _youTubeViewersListingViewItemModels;
        private readonly SelectedYouTubeViewerStore? _selectedYouTubeViewerStore;
        private YouTubeViewersListingItemViewModel _selectedYouTubeViewerListingItemViewModel;

        public IEnumerable<YouTubeViewersListingItemViewModel>? YouTubeViewersListingItemViewModels => _youTubeViewersListingViewItemModels;

        

        public YouTubeViewersListingItemViewModel SelectedYouTubeViewerListingItemViewModel
        {
            get { return _selectedYouTubeViewerListingItemViewModel; }
            set 
            {
                _selectedYouTubeViewerListingItemViewModel = value;
                OnPropertyChanged(nameof(SelectedYouTubeViewerListingItemViewModel));
                _selectedYouTubeViewerStore.SelectedYouTubeViewer = _selectedYouTubeViewerListingItemViewModel?.YouTubeViewer;
            }
        }

        public YouTubeViewersListingViewModel(SelectedYouTubeViewerStore? selectedYouTubeViewerStore)
        {
            _youTubeViewersListingViewItemModels = new ObservableCollection<YouTubeViewersListingItemViewModel>();
            _youTubeViewersListingViewItemModels.Add(new YouTubeViewersListingItemViewModel(new YouTubeViewer("Prince", true, true)));
            _youTubeViewersListingViewItemModels.Add(new YouTubeViewersListingItemViewModel(new YouTubeViewer("Prosper", false, false)));
            _youTubeViewersListingViewItemModels.Add(new YouTubeViewersListingItemViewModel(new YouTubeViewer("Yaa", true, false)));
            _selectedYouTubeViewerStore = selectedYouTubeViewerStore;
        }
    }
}
