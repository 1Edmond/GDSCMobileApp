using GDSCMobileApp.Services;

namespace GDSCMobileApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiApp<App>().UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        builder.Services.AddLocalization();



        builder.Services.AddTransient<MainPage>();
		builder.Services.AddSingleton<IDatabaseManager<Proprietaire>, FirebaseManager<Proprietaire>>();


#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
