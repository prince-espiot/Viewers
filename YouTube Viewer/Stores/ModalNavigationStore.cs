using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTube_Viewer.ViewModels;

namespace YouTube_Viewer.Stores
{
    public class ModalNavigationStore
    {
		private ViewModelBase? _currentViewModel;

		public ViewModelBase? CurrentViewModel
        {
			get { return  _currentViewModel; }
			set {
                //_currentViewModel.Dispose(disposing: true);
				_currentViewModel = value;
                CurrentViewModelChanged?.Invoke();

            }
		}

        public bool IsOpen => CurrentViewModel != null;
        public event Action? CurrentViewModelChanged;

        public void Close()
        {
            CurrentViewModel = null;
        }
    }
}
