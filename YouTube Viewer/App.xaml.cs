using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Data;
using System.Windows;
using YouTube_Viewer.Stores;
using YouTube_Viewer.ViewModels;
using YouTubeViewers.Domain.Commands;
using YouTubeViewers.Domain.Queries;
using YouTubeViewers.EntityFramework;
using YouTubeViewers.EntityFramework.Command;
using YouTubeViewers.EntityFramework.Queries;

namespace YouTube_Viewer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ModalNavigationStore? _modalNavigationStore;
        private readonly YouTubeViewersDbContextFactory _dbContextFactory;
        private readonly ICreateYouTubeViewerCommand? _createYouTubeViewerCommand;
        private readonly IUpdateYouTubeViewerCommand? _updateYouTubeViewerCommand;
        private readonly IDeleteYouTubeViewerCommand? _deleteYouTubeViewerCommand;
        private readonly IGetAllYouTubeViewersQuery? _getAllYouTubeViewersQuery;

        private readonly SelectedYouTubeViewerStore? _selectedYouTubeViewerStore;
        private readonly YouTubeViewersStore? _youTubeViewersStore;

        public App()
        {
            string connectionString = "Data Source=Project.db";
            _modalNavigationStore = new ModalNavigationStore();

            _dbContextFactory = new YouTubeViewersDbContextFactory(
                new DbContextOptionsBuilder().UseSqlite(connectionString).Options);
            _getAllYouTubeViewersQuery = new GetAllYouTubeViewersQuery(_dbContextFactory);
            _createYouTubeViewerCommand = new CreateYouTubeViewerCommand(_dbContextFactory);
            _updateYouTubeViewerCommand = new UpdateYouTubeViewerCommand(_dbContextFactory);
            _deleteYouTubeViewerCommand = new DeleteYouTubeViewerCommand(_dbContextFactory);
            _youTubeViewersStore = new YouTubeViewersStore(_createYouTubeViewerCommand, _updateYouTubeViewerCommand,
                _deleteYouTubeViewerCommand, _getAllYouTubeViewersQuery);
            _selectedYouTubeViewerStore = new SelectedYouTubeViewerStore(_youTubeViewersStore);
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            using (YouTubeViewersDbContext context = _dbContextFactory.Create()) 
            { 
                context.Database.Migrate();
            }

            YouTubeViewersViewModel youTubeViewersViewModel = YouTubeViewersViewModel.LoadViewModel(_youTubeViewersStore, _selectedYouTubeViewerStore, _modalNavigationStore);

            MainWindow = new MainWindow()
            {

                DataContext = new MainViewModel(_modalNavigationStore, youTubeViewersViewModel)
            };
            MainWindow.Show();
            base.OnStartup(e);
        }
    }

}
