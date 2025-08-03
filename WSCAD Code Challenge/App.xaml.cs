using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using WSCAD.Core;
using WSCAD.Infrastructure;
using WSCAD_Code_Challenge.Drawing;
using WSCAD_Code_Challenge.ViewModel;

namespace WSCAD_Code_Challenge
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();

            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IShapeRenderer, CircleRenderer>();
            services.AddSingleton<IShapeRenderer, LineRenderer>();
            services.AddSingleton<IShapeRenderer, TriangleRenderer>();

            services.AddSingleton<IShapeDrawingService, ShapeDrawingService>();
            services.AddSingleton<IShapeParser, JsonShapeParser>();
            services.AddSingleton<IShapeLoaderService, ShapeLoaderService>();
            
            services.AddTransient<MainViewModel>();
            services.AddSingleton<MainWindow>();
        }
    }

}
