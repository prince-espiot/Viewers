using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Configuration;
using System.Data;
using System.Windows;
using YouTube_Viewer.Stores;
using YouTube_Viewer.ViewModels;
using YouTube_Viewer.Hostbuilders;
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
        /*private readonly ModalNavigationStore? _modalNavigationStore;
        private readonly YouTubeViewersDbContextFactory _dbContextFactory;
        private readonly ICreateYouTubeViewerCommand? _createYouTubeViewerCommand;
        private readonly IUpdateYouTubeViewerCommand? _updateYouTubeViewerCommand;
        private readonly IDeleteYouTubeViewerCommand? _deleteYouTubeViewerCommand;
        private readonly IGetAllYouTubeViewersQuery? _getAllYouTubeViewersQuery;*/

        private readonly SelectedYouTubeViewerStore? _selectedYouTubeViewerStore;
        private readonly YouTubeViewersStore? _youTubeViewersStore;

        private readonly IHost _host;

        public App()
        {
            _host = Host.CreateDefaultBuilder()
                .AddDbContext()
                .AddDbCRUDContext()
                .ConfigureServices((context,services)=>
            {
                services.AddSingleton<ModalNavigationStore>();
                services.AddSingleton<YouTubeViewersStore>();
                services.AddSingleton<SelectedYouTubeViewerStore>();

                services.AddSingleton<MainViewModel>();
                

                services.AddSingleton<MainWindow>((services)=> new MainWindow()
                {
                    DataContext = services.GetRequiredService<MainViewModel>()
                });

                services.AddTransient<YouTubeViewersViewModel>(CreateYourViewerModel);
            }).Build();

            /*string connectionString = "Data Source=Project.db";
            _modalNavigationStore = new ModalNavigationStore();

            _dbContextFactory = new YouTubeViewersDbContextFactory(
                new DbContextOptionsBuilder().UseSqlite(connectionString).Options);
            _getAllYouTubeViewersQuery = new GetAllYouTubeViewersQuery(_dbContextFactory);
            _createYouTubeViewerCommand = new CreateYouTubeViewerCommand(_dbContextFactory);
            _updateYouTubeViewerCommand = new UpdateYouTubeViewerCommand(_dbContextFactory);
            _deleteYouTubeViewerCommand = new DeleteYouTubeViewerCommand(_dbContextFactory);
            _youTubeViewersStore = new YouTubeViewersStore(_createYouTubeViewerCommand, _updateYouTubeViewerCommand,
                _deleteYouTubeViewerCommand, _getAllYouTubeViewersQuery);
            _selectedYouTubeViewerStore = new SelectedYouTubeViewerStore(_youTubeViewersStore);*/
        }

       

        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();
            YouTubeViewersDbContextFactory youTubeViewersDbContextFactory = _host.Services.GetRequiredService<YouTubeViewersDbContextFactory>();

            using (YouTubeViewersDbContext context = youTubeViewersDbContextFactory.Create()) 
            { 
                context.Database.Migrate();
            }

           /* YouTubeViewersViewModel youTubeViewersViewModel = YouTubeViewersViewModel.LoadViewModel(_youTubeViewersStore, _selectedYouTubeViewerStore, _modalNavigationStore);

            MainWindow = new MainWindow()
            {

                DataContext = new MainViewModel(_modalNavigationStore, youTubeViewersViewModel)
            };*/
            MainWindow = _host.Services.GetRequiredService<MainWindow>();
            MainWindow.Show();
            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _host.StopAsync();
            _host.Dispose();
            base.OnExit(e);
        }

        private YouTubeViewersViewModel CreateYourViewerModel(IServiceProvider services)
        {
            return YouTubeViewersViewModel.LoadViewModel(
            services.GetRequiredService<YouTubeViewersStore>(),
            services.GetRequiredService<SelectedYouTubeViewerStore>(),
            services.GetRequiredService<ModalNavigationStore>());
        }
    }

}
