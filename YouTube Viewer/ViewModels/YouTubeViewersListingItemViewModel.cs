using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace YouTube_Viewer.ViewModels
{
    public class YouTubeViewersListingItemViewModel:ViewModelBase
    {
        public string? Username { get; }

        public ICommand? EditCommand { get;}

        public string? DeleteCommand { get;  }

        public YouTubeViewersListingItemViewModel(string username)
        {
            Username = username;
        }
    }
}
