using Microsoft.Extensions.Logging;
using WuxiaApp.Servs;
using WuxiaApp.ViewModels;
using WuxiaApp.Views;

namespace WuxiaApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<Services>();
            builder.Services.AddSingleton<LibraryViewModel>();
            builder.Services.AddSingleton<Library>();


            return builder.Build();
        }
    }
}