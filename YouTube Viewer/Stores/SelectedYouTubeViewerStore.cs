using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTube_Viewer.Models;

namespace YouTube_Viewer.Stores
{
    public class SelectedYouTubeViewerStore
    {
		private YouTubeViewer? _selectedYouTubeViewer;

		public YouTubeViewer SelectedYouTubeViewer
        {
			get { 

				return _selectedYouTubeViewer;
			}
			set {

                _selectedYouTubeViewer = value;
				SelectedYouTubeViewerChanged?.Invoke();

			
			}
		}

		public event Action? SelectedYouTubeViewerChanged;	

	}
}
