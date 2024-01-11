using CommunityToolkit.Maui;
using EwalletMobileApp.Extenstions;
using EwalletMobileApp.MVVM.ViewModels;
using EwalletMobileApp.MVVM.Views;
using Microsoft.Extensions.Logging;
using UraniumUI;

namespace EwalletMobileApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseUraniumUI()
                .UseUraniumUIMaterial()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("icomoon.ttf", "Icons");
                });

            builder.Services.AddSqliteConnection();
            builder.Services.AddServices();

            builder.Services.AddTransient<BudgetsView>();
            builder.Services.AddTransient<BudgetsViewModel>();

            builder.Services.AddTransient<SingleBudgetView>();
            builder.Services.AddTransient<SingleBudgetViewModel>();



#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
