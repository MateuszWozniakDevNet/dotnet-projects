using EventPingApp.Application.Navigation;
using EventPingApp.Application.Repositories;
using EventPingApp.Application.UseCases.DeleteCalendarEvent;
using EventPingApp.Application.UseCases.GetAllCalendarEvents;
using EventPingApp.Application.UseCases.GetCalendarEvent;
using EventPingApp.Application.UseCases.SaveCalendarEvent;
using INotificationService = EventPingApp.Application.Notification.INotificationService;
using EventPingApp.Infrastructure.Factories;
using EventPingApp.Infrastructure.Navigation;
using EventPingApp.Infrastructure.Notification;
using EventPingApp.Infrastructure.Persistence;
using EventPingApp.Infrastructure.Repositories;
using EventPingApp.Presentation.Factories;
using EventPingApp.Presentation.ViewModels;
using EventPingApp.Presentation.Views;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Plugin.LocalNotification;
using EventPingApp.Application.Notification;

namespace EventPingApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp() 
            => MauiApp.CreateBuilder()
                .UseMauiApp<App>()
                .UseLocalNotification()
                .RegisterConfiguration()
                .RegisterFonts()
                .RegisterApplication()
                .RegisterInfrastructure()
                .RegisterPresentation()
                .AddDebug()
                .Build();

        public static MauiAppBuilder RegisterConfiguration(this MauiAppBuilder builder)
        {
            builder.Configuration.AddJsonFile("appsettings.json", optional: true);
            return builder;
        }

        public static MauiAppBuilder RegisterApplication(this MauiAppBuilder builder)
        {
            builder.Services.AddTransient<ISaveCalendarEventUseCase, SaveCalendarEventUseCase>();
            builder.Services.AddTransient<IGetCalendarEventUseCase, GetCalendarEventUseCase>();
            builder.Services.AddTransient<IGetAllCalendarEventsUseCase, GetAllCalendarEventsUseCase>();
            builder.Services.AddTransient<IDeleteCalendarEventUseCase, DeleteCalendarEventUseCase>();
            builder.Services.AddSingleton<INotificationTimeCalculator, NotificationTimeCalculator>();
            builder.Services.AddSingleton<INotificationIdProvider, NotificationIdProvider>();
            builder.Services.AddSingleton<INotificationManager, NotificationManager>();
            return builder;
        }

        public static MauiAppBuilder RegisterInfrastructure(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<IDatabaseProvider, SqliteDatabaseProvider>();
            builder.Services.AddSingleton<ICalendarEventRepository, CalendarEventRepository>();
            builder.Services.AddSingleton<INavigationService, NavigationService>();
            builder.Services.AddSingleton<INotificationService, NotificationService>();
            return builder;
        }

        public static MauiAppBuilder RegisterPresentation(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<AppShell>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddTransient<EventDetailPage>();
            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddSingleton<IEventItemViewModelFactory, EventItemViewModelFactory>();
            builder.Services.AddTransient<EventDetailViewModel>();
            return builder;
        }

        public static MauiAppBuilder RegisterFonts(this MauiAppBuilder builder)
        {
            builder.ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });
            return builder;
        }

        public static MauiAppBuilder AddDebug(this MauiAppBuilder builder)
        {
            #if DEBUG
                builder.Logging.AddDebug();
            #endif
            return builder;
        }
    }
}
