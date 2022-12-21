using Microsoft.Maui.LifecycleEvents;

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
			})
			.ConfigureLifecycleEvents(events =>
            {
#if ANDROID

                events.AddAndroid(
                    android => android.OnPause(
                        (activity) => activity.Window?.
                        SetFlags(Android.Views.WindowManagerFlags.BlurBehind, Android.Views.WindowManagerFlags.BlurBehind)));

                events.AddAndroid(
                    android => android.OnResume(
                        (activity) => activity.Window?.
                        ClearFlags(Android.Views.WindowManagerFlags.BlurBehind)));

#endif
            }); ;

        builder.Services.AddLocalization();



        builder.Services.AddTransient<MainPage>();
		builder.Services.AddSingleton<IDatabaseManager<Proprietaire>, FirebaseManager<Proprietaire>>();


#if DEBUG
		builder.Logging.AddDebug();
#endif
		

		return builder.Build();
	}
}
