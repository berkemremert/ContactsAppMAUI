using Microsoft.Extensions.Logging;

namespace ContactsAppMAUI;

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
		builder.Services.AddSingleton<ContactsAppMAUI.ViewModels.ContactsViewModel>();
		builder.Services.AddTransient<ContactsAppMAUI.ViewModels.ContactDetailsPageViewModel>();
#endif

		return builder.Build();
	}
}
