using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using YouTube_Viewer.Stores;
using YouTube_Viewer.ViewModels;

namespace YouTube_Viewer.Commands
{
    public class LoadYouTubeViewersCommand : AsyncCommandBase
    {
        private readonly YouTubeViewersViewModel _youTubeViewersViewModel;
        private readonly YouTubeViewersStore _youTubeViewersStore;

        public LoadYouTubeViewersCommand( YouTubeViewersViewModel youTubeViewersViewModel, YouTubeViewersStore youTubeViewersStore)
        {
            _youTubeViewersViewModel = youTubeViewersViewModel;
            _youTubeViewersStore = youTubeViewersStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _youTubeViewersViewModel.ErrorMessage = null;
            _youTubeViewersViewModel.IsLoading = true;
            
            try
            {
                

                await _youTubeViewersStore.Load();
            }
            catch (Exception)
            {
                 _youTubeViewersViewModel.ErrorMessage = "Failed to load YouTube viewers. Please restart the application.";
            }
            finally
            {
                _youTubeViewersViewModel.IsLoading = false;
            }
        }
    }
}
