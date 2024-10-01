using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using YouTube_Viewer.Commands;
using YouTube_Viewer.Domain.Models;
using YouTube_Viewer.Stores;

namespace YouTube_Viewer.ViewModels
{
    public class YouTubeViewersViewModel:ViewModelBase
    {
        public YouTubeViewersListingViewModel? YouTubeViewersListingViewModel { get;  }

        public YouTubeViewersDetailsViewModel? YouTubeViewersDetailsViewModel { get;  }
        public ICommand? AddYouTubeViewersCommand {  get; }

        public YouTubeViewersViewModel(YouTubeViewersStore? youTubeViewersStore, SelectedYouTubeViewerStore selectedYouTubeViewerStore, ModalNavigationStore modalNavigationStore)
        {
            YouTubeViewersListingViewModel = new YouTubeViewersListingViewModel(youTubeViewersStore,selectedYouTubeViewerStore, modalNavigationStore);
            YouTubeViewersDetailsViewModel = new YouTubeViewersDetailsViewModel(selectedYouTubeViewerStore);

            AddYouTubeViewersCommand = new OpenAddYouTubeViewerCommand(youTubeViewersStore,modalNavigationStore);
        }

      
    }
}
