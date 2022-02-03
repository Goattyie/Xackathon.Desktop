using Microsoft.Extensions.DependencyInjection;
using System.Windows.Controls;
using Xackathon.WPF.Pages;
using Xackathon.WPF.ViewModels;

namespace Xackathon.WPF.DI
{
    public class IoC
    {
        private static ServiceProvider _provider;
        
        static IoC()
        {
            var services = new ServiceCollection();

            services.AddTransient<Page, AutorizationPage>();
            services.AddSingleton<MainWindowViewModel>();
            services.AddTransient<CreateRequestViewModel>();
            services.AddTransient<ProblemCategoryViewModel>();

            _provider = services.BuildServiceProvider();
        }

        public static T Resolve<T>() => _provider.GetRequiredService<T>();
    }
}
