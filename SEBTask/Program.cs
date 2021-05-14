using System;
using Microsoft.Extensions.DependencyInjection;
using SEBTask.Services;
using SEBTask.Services.Interfaces;

namespace SEBTask
{
    class Program
    {
        private static IServiceProvider _serviceProvider;
        static void Main(string[] args)
        {
            RegisterServices();
            IServiceScope scope = _serviceProvider.CreateScope();
            scope.ServiceProvider.GetRequiredService<Startup>().Run();

        }
        public static void RegisterServices()
        {
            var services = new ServiceCollection();
            services.AddSingleton<Startup>();
            services.AddSingleton<IIOService, IOService>();
            services.AddSingleton<ITextService, TextService>();
            _serviceProvider = services.BuildServiceProvider(true);
            
        }
    }
}
