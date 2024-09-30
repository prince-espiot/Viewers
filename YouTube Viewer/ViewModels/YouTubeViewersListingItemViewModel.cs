using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using YouTube_Viewer.Models;

namespace YouTube_Viewer.ViewModels
{
    public class YouTubeViewersListingItemViewModel:ViewModelBase
    {
        public  YouTubeViewer YouTubeViewer { get; }

        public string? Username => YouTubeViewer.Username;

        public ICommand? EditCommand { get;}

        public string? DeleteCommand { get;  }

        

        public YouTubeViewersListingItemViewModel(YouTubeViewer youTubeViewer)
        {
            YouTubeViewer = youTubeViewer;
        }
    }
}
