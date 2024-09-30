using System.Configuration;
using System.Data;
using System.Windows;
using YouTube_Viewer.Stores;
using YouTube_Viewer.ViewModels;

namespace YouTube_Viewer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ModalNavigationStore? _modalNavigationStore;
        private readonly SelectedYouTubeViewerStore? _selectedYouTubeViewerStore;

        public App()
        {
            _modalNavigationStore = new ModalNavigationStore();
            _selectedYouTubeViewerStore = new SelectedYouTubeViewerStore();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            YouTubeViewersViewModel youTubeViewersViewModel = new YouTubeViewersViewModel(_selectedYouTubeViewerStore);

            MainWindow = new MainWindow()
            {

                DataContext = new MainViewModel(_modalNavigationStore, youTubeViewersViewModel)
            };
            MainWindow.Show();
            base.OnStartup(e);
        }
    }

}
