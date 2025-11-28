using Microsoft.Extensions.DependencyInjection;
using nonsense.Core.Features.Common.Events;
using nonsense.Core.Features.Common.Interfaces;
using nonsense.Core.Features.UI.Interfaces;
using nonsense.Infrastructure.Features.UI.Services;
using nonsense.WPF.Features.Common.Interfaces;
using nonsense.WPF.Features.Common.Resources.Theme;
using nonsense.WPF.Features.Common.Services;

namespace nonsense.WPF.Features.Common.Extensions.DI
{
    public static class UIServicesExtensions
    {
        public static IServiceCollection AddUIServices(this IServiceCollection services)
        {
            return services
                .AddUIInfrastructureServices()
                .AddUICoordinationServices()
                .AddDialogServices()
                .CompleteSystemServicesRegistration();
        }

        public static IServiceCollection AddUIInfrastructureServices(this IServiceCollection services)
        {
            services.AddSingleton<IThemeManager>(provider => new ThemeManager(
                provider.GetRequiredService<INavigationService>(),
                provider.GetRequiredService<IWindowsThemeQueryService>()
            ));

            services.AddSingleton<IApplicationCloseService, ApplicationCloseService>();

            services.AddSingleton<WindowInitializationService>();
            services.AddSingleton<IWindowManagementService, WindowManagementService>();
            services.AddSingleton<IFlyoutManagementService, FlyoutManagementService>();

            services.AddSingleton<InonsenseNotificationService, nonsenseNotificationService>();

            services.AddSingleton<IStartupNotificationService, StartupNotificationService>();

            services.AddSingleton<UserPreferencesService>(provider => new UserPreferencesService(
                provider.GetRequiredService<ILogService>()
            ));
            services.AddSingleton<IUserPreferencesService>(provider =>
                provider.GetRequiredService<UserPreferencesService>()
            );

            services.AddSingleton<IViewPoolService>(provider =>
            {
                var config = ViewPoolConfiguration.CreateDefault();
                return new Infrastructure.Features.Common.Services.ViewPoolService(
                    provider.GetRequiredService<ILogService>(),
                    config.PoolSizes
                );
            });

            return services;
        }

        public static IServiceCollection AddUICoordinationServices(this IServiceCollection services)
        {
            services.AddTransient<ISettingsConfirmationService, SettingsConfirmationService>();

            services.AddSingleton<IConfigurationService, ConfigurationService>();

            services.AddSingleton<nonsense.Core.Features.AdvancedTools.Interfaces.IAutounattendXmlGeneratorService,
                nonsense.WPF.Features.AdvancedTools.Services.AutounattendXmlGeneratorService>();

            services.AddSingleton<Infrastructure.Features.Common.EventHandlers.TooltipRefreshEventHandler>();

            services.AddScoped<ISettingApplicationService>(sp =>
                new Infrastructure.Features.Common.Services.SettingApplicationService(
                    sp.GetRequiredService<IDomainServiceRouter>(),
                    sp.GetRequiredService<IWindowsRegistryService>(),
                    sp.GetRequiredService<IComboBoxResolver>(),
                    sp.GetRequiredService<ICommandService>(),
                    sp.GetRequiredService<ILogService>(),
                    sp.GetRequiredService<IDependencyManager>(),
                    sp.GetRequiredService<IGlobalSettingsRegistry>(),
                    sp.GetRequiredService<IEventBus>(),
                    sp.GetRequiredService<ISystemSettingsDiscoveryService>(),
                    sp.GetRequiredService<IRecommendedSettingsService>(),
                    sp.GetRequiredService<IWindowsUIManagementService>(),
                    sp.GetRequiredService<IPowerCfgQueryService>(),
                    sp.GetRequiredService<IHardwareDetectionService>(),
                    sp.GetRequiredService<IPowerShellExecutionService>(),
                    sp.GetRequiredService<IWindowsCompatibilityFilter>()

                ));

            return services;
        }

        public static IServiceCollection AddDialogServices(this IServiceCollection services)
        {
            services.AddTransient<IDialogService, DialogService>();
            services.AddTransient<ISettingsConfirmationService, SettingsConfirmationService>();

            return services;
        }

        public static IServiceCollection AddNavigationServices(this IServiceCollection services)
        {
            return services;
        }
    }
}
