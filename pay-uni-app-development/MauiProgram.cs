namespace PayUni;

using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using PayUni.Pages;
using PayUni.ViewModels;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder()
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            })
            .RegisterPages()
            .RegisterViewModels();

        return builder.Build();
    }

    public static MauiAppBuilder RegisterPages(this MauiAppBuilder builder)
    {
        builder
            .ConfigureRoutes(routes =>
            {
                routes.Add("login", typeof(LoginPage));
                routes.Add("dashboard", typeof(DashboardPage));
                routes.Add("fees", typeof(FeesPage));
                routes.Add("payment", typeof(PaymentPage));
                routes.Add("profile", typeof(ProfilePage));
                routes.Add("history", typeof(HistoryPage));
            });

        return builder;
    }

    public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder builder)
    {
        builder
            .Services.AddSingleton<LoginViewModel>()
            .AddSingleton<DashboardViewModel>()
            .AddSingleton<FeesViewModel>()
            .AddSingleton<PaymentViewModel>()
            .AddSingleton<ProfileViewModel>()
            .AddSingleton<HistoryViewModel>();

        return builder;
    }

    public static MauiAppBuilder ConfigureRoutes(this MauiAppBuilder builder, Action<RouteCollection> configureRoutes)
    {
        var routes = new RouteCollection();
        configureRoutes?.Invoke(routes);
        
        foreach (var route in routes.Routes)
        {
            Routing.RegisterRoute(route.Key, route.Value);
        }

        return builder;
    }
}

public class RouteCollection
{
    public Dictionary<string, Type> Routes { get; } = new();

    public void Add(string route, Type pageType)
    {
        Routes[route] = pageType;
    }
}
