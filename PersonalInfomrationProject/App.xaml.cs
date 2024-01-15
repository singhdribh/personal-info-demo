using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PersonalInfomrationProject.Data;
using PersonalInfomrationProject.Data.Repositories;
using System.Windows;

namespace PersonalInfomrationProject
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ServiceProvider serviceProvider;
        public App()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();

        }
        private void ConfigureServices(ServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>();
            services.AddSingleton<MainWindow>();
            services.AddTransient<MainWindowViewModel>();
            services.AddScoped<IPersonalInformationRepository, PersonalInformationRepository>();
        }

        private async void OnStartup(object sender, StartupEventArgs e)
        {
            var dbContext = serviceProvider.GetService<ApplicationDbContext>();
            await dbContext.DatabaseMigrateAsync();
            var mainWindow = serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }

    }
}
