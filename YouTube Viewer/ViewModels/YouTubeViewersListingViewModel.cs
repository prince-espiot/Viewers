using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using YouTube_Viewer.Commands;
using YouTube_Viewer.Domain.Models;
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

        
        //public ICommand LoadingYouTubeViewerCommand { get; }

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

           // LoadingYouTubeViewerCommand = new LoadYouTubeViewersCommand(youTubeViewersStore);

            _youTubeViewersStore.YouTubeViewersLoaded += _youTubeViewersStore_YouTubeViewersLoaded;
            _youTubeViewersStore.YouTubeViewersAdded += _youTubeViewersStore_YouTubeViewersAdded;
            _youTubeViewersStore.YouTubeViewersUpdated += _youTubeViewersStore_YouTubeViewersUpdated;
           _youTubeViewersStore.YouTubeViewerDeleted += _youTubeViewersStore_YouTubeViewerDeleted;

        }

        private void _youTubeViewersStore_YouTubeViewerDeleted(Guid id)
        {
            // Find the viewer in the current list by ID
            YouTubeViewersListingItemViewModel viewerToDelete = _youTubeViewersListingViewItemModels.FirstOrDefault(v => v.YouTubeViewer.Id == id);

            if (viewerToDelete != null)
            {
                // Remove the viewer from the list
                _youTubeViewersListingViewItemModels.Remove(viewerToDelete);

                // Optionally, trigger any UI updates, like refreshing the view
                //OnPropertyChanged(nameof(YouTubeViewers));
            }
        }

        private void _youTubeViewersStore_YouTubeViewersLoaded()
        {
            _youTubeViewersListingViewItemModels.Clear();

            foreach (YouTubeViewer youTubeViewer in _youTubeViewersStore.YouTubeViewers)
            {
                AddYouTubeViewer(youTubeViewer);
            }
        }

       /* public static YouTubeViewersListingViewModel LoadViewModel(YouTubeViewersStore youTubeViewersStore, SelectedYouTubeViewerStore selectedYouTubeViewerStore, ModalNavigationStore modalNavigationStore)
        {
            YouTubeViewersListingViewModel viewModel = new YouTubeViewersListingViewModel(youTubeViewersStore, selectedYouTubeViewerStore, modalNavigationStore);

            viewModel.LoadingYouTubeViewerCommand.Execute(viewModel);

            return viewModel;
        }*/
        private void _youTubeViewersStore_YouTubeViewersUpdated(YouTubeViewer youTubeViewer)
        {
            YouTubeViewersListingItemViewModel? youTubeViewersListingItemViewModel = _youTubeViewersListingViewItemModels?.FirstOrDefault(y => y.YouTubeViewer.Id == youTubeViewer.Id);

            if (youTubeViewersListingItemViewModel!=null)
            {
                youTubeViewersListingItemViewModel.Update(youTubeViewer);
            }

        }

        protected override void Dispose()
        {
            _youTubeViewersStore.YouTubeViewersLoaded -= _youTubeViewersStore_YouTubeViewersLoaded;
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
