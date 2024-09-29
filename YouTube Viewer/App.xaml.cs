using System.Configuration;
using System.Data;
using System.Windows;
using YouTube_Viewer.ViewModels;

namespace YouTube_Viewer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow()
            {
                DataContext = new YouTubeViewersViewModel()
            };
            MainWindow.Show();
            base.OnStartup(e);
        }
    }

}
