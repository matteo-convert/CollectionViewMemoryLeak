using CollectionViewMemoryLeak.Pages;
using CollectionViewMemoryLeak.ViewModels;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using NodaMobileSales.Maui.Services;

namespace CollectionViewMemoryLeak;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .UseInfra()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}

}

public static class InfraHelpers
{

    public static MauiAppBuilder UseInfra(this MauiAppBuilder builder)
    {

        builder.Services.AddSingleton<NavigationService>();

        builder.Services.AddTransient<CollectionViewViewModel>();
        builder.Services.AddTransient<CollectionViewPage>();

        builder.Services.AddTransient<ListViewViewModel>();
        builder.Services.AddTransient<ListViewPage>();

        builder.Services.AddTransient<MainPageViewModel>();
        builder.Services.AddTransient<MainPage>();

        return builder;
    }

}
