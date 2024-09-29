using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTube_Viewer.ViewModels
{
    public class YouTubeViewersListingViewModel:ViewModelBase
    {
        private readonly ObservableCollection<YouTubeViewersListingItemViewModel>? _youTubeViewersListingViewItemModels;
        public IEnumerable<YouTubeViewersListingItemViewModel>? YouTubeViewersListingItemViewModels => _youTubeViewersListingViewItemModels;

        public YouTubeViewersListingViewModel()
        {
            _youTubeViewersListingViewItemModels = new ObservableCollection<YouTubeViewersListingItemViewModel>();
            _youTubeViewersListingViewItemModels.Add(new YouTubeViewersListingItemViewModel("Prince"));
            _youTubeViewersListingViewItemModels.Add(new YouTubeViewersListingItemViewModel("Mina"));
            _youTubeViewersListingViewItemModels.Add(new YouTubeViewersListingItemViewModel("Liza"));
        }
    }
}
