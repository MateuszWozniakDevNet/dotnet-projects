using Microsoft.Extensions.Logging;

namespace AmazingWorldCup26PredictionApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp() =>
            MauiApp.CreateBuilder()
                .UseMauiApp<App>()
                .RegisterFonts()
                .AddMauiBlazorWebView()
                .AddDebug()
                .Build();

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
                builder.Services.AddBlazorWebViewDeveloperTools();
                builder.Logging.AddDebug();
            #endif
                return builder;
        }

        public static MauiAppBuilder AddMauiBlazorWebView(this MauiAppBuilder builder)
        {
            builder.Services.AddMauiBlazorWebView();
            return builder;
        }
    }
}
