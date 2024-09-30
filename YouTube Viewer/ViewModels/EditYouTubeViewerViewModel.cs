using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using YouTube_Viewer.Models;
using YouTube_Viewer.Stores;

namespace YouTube_Viewer.ViewModels
{
    public class EditYouTubeViewerViewModel:ViewModelBase
    {
        public YouTubeViewerDetailsFormViewModel YouTubeViewerDetailsFormViewModel { get;}

        public EditYouTubeViewerViewModel(YouTubeViewer youTubeViewer, ModalNavigationStore modalNavigationStore)
        {
            //ICommand submitCommand = new EditYouTubeViewerCommand(this, modalNavigationStore);
           // ICommand cancelCommand = new CloseModalCommand(modalNavigationStore);
        }
    }
}
