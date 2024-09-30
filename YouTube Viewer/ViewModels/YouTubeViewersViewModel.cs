using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using YouTube_Viewer.Commands;
using YouTube_Viewer.Stores;

namespace YouTube_Viewer.ViewModels
{
    public class YouTubeViewersViewModel:ViewModelBase
    {
        public YouTubeViewersListingViewModel? YouTubeViewersListingViewModel { get;  }

        public YouTubeViewersDetailsViewModel? YouTubeViewersDetailsViewModel { get;  }
        public ICommand? AddYoutubeViewcommand {  get; }

        public YouTubeViewersViewModel(SelectedYouTubeViewerStore _selectedYouTubeViewerStore, ModalNavigationStore modalNavigationStore)
        {
            YouTubeViewersListingViewModel = new YouTubeViewersListingViewModel(_selectedYouTubeViewerStore);
            YouTubeViewersDetailsViewModel = new YouTubeViewersDetailsViewModel(_selectedYouTubeViewerStore);

            AddYoutubeViewcommand = new OpenAddYouTubeViewerCommand(modalNavigationStore);
        }
    }
}
