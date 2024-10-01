using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using YouTube_Viewer.Commands;
using YouTube_Viewer.Models;
using YouTube_Viewer.Stores;

namespace YouTube_Viewer.ViewModels
{
    public class YouTubeViewersListingViewModel:ViewModelBase
    {
        private readonly ObservableCollection<YouTubeViewersListingItemViewModel>? _youTubeViewersListingViewItemModels;
        private readonly YouTubeViewersStore? _youTubeViewersStore;
        private readonly SelectedYouTubeViewerStore? _selectedYouTubeViewerStore;
        private readonly ModalNavigationStore _modalNavigationStore;
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

        public YouTubeViewersListingViewModel(YouTubeViewersStore? youTubeViewersStore, SelectedYouTubeViewerStore? selectedYouTubeViewerStore, ModalNavigationStore modalNavigationStore)
        {
            _youTubeViewersListingViewItemModels = new ObservableCollection<YouTubeViewersListingItemViewModel>();
            _youTubeViewersStore = youTubeViewersStore;
            _selectedYouTubeViewerStore = selectedYouTubeViewerStore;
            _modalNavigationStore = modalNavigationStore;
            _youTubeViewersStore.YouTubeViewersAdded += _youTubeViewersStore_YouTubeViewersAdded;
            _youTubeViewersStore.YouTubeViewersUpdated += _youTubeViewersStore_YouTubeViewersUpdated;
                        
        }

        private void _youTubeViewersStore_YouTubeViewersUpdated(YouTubeViewer youTubeViewer)
        {
            YouTubeViewersListingItemViewModel youTubeViewersListingItemViewModel = _youTubeViewersListingViewItemModels.FirstOrDefault(y => y.YouTubeViewer.Id == youTubeViewer.Id);

            if (youTubeViewersListingItemViewModel!=null)
            {
                youTubeViewersListingItemViewModel.Update(youTubeViewer);
            }

        }

        protected override void Dispose()
        {
            _youTubeViewersStore.YouTubeViewersAdded -= _youTubeViewersStore_YouTubeViewersAdded;
            _youTubeViewersStore.YouTubeViewersUpdated -= _youTubeViewersStore_YouTubeViewersUpdated;

            base.Dispose();
        }
        private void _youTubeViewersStore_YouTubeViewersAdded(YouTubeViewer youTubeViewer)
        {
            AddYouTubeViewer(youTubeViewer);
        }

        private void AddYouTubeViewer(YouTubeViewer youTubeViewer)
        {
            YouTubeViewersListingItemViewModel itemViewModel = new YouTubeViewersListingItemViewModel(youTubeViewer, _youTubeViewersStore, _modalNavigationStore);
            _youTubeViewersListingViewItemModels?.Add(itemViewModel);
        }
    }
}
