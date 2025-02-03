using Microsoft.Extensions.Logging;

namespace AlarmTest1;

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

#if ANDROID
            builder.Services.AddSingleton<INotificationManagerService, AlarmTest1.Platforms.Android.NotificationManagerService>();
#elif IOS
            builder.Services.AddSingleton<INotificationManagerService, AlarmTest1.Platforms.iOS.NotificationManagerService>();
#endif
            builder.Services.AddSingleton<MainPage>();

		return builder.Build();
	}
}
