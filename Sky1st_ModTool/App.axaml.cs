using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using Sky1st_ModTool.Core.Services;
using Sky1st_ModTool.Services;
using Sky1st_ModTool.TBL.Handler;
using Sky1st_ModTool.ViewModels;
using Sky1st_ModTool.Views;

namespace Sky1st_ModTool
{
    public partial class App : Application
    {
        private ServiceProvider? _serviceProvider;

        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);

            var precompiler = new PrecompiledManager();
            precompiler.PrecompileAll();

            // ÅäÖÃÒÀÀµ×¢Èë
            var services = new ServiceCollection();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow
                {
                    DataContext = _serviceProvider?.GetService<MainWindowViewModel>(),
                };
            }

            base.OnFrameworkInitializationCompleted();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            // ×¢²á·þÎñ
            services.AddSingleton<ISettingsService, SettingsService>();
            services.AddSingleton<IPACProcessor, PACProcessor.Services.PACProcessor>();
            services.AddSingleton<IWindowService, WindowService>();

            // ×¢²áViewModels
            services.AddTransient<MainWindowViewModel>();
            services.AddTransient<SettingsWindowViewModel>();
            services.AddTransient<TblEditorViewModel>();
        }
    }
}