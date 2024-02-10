using CommunityToolkit.Maui;
using CustomControls.MAUI.MessageBox.AppPresentations.CommonSource;
using CustomControls.MAUI.MessageBox.AppPresentations.Utilities;
using CustomControls.MAUI.MessageBox;
using Microsoft.Extensions.Logging;

namespace MauiAppCustomPopupExample
{
    public static class MauiProgram
    {
        [Obsolete]
        public static MauiApp CreateMauiApp()
        {
            try
            {
                //Initial setup for MAUI messagebox[Application Level declaration]
                ModalMessageBoxConfigurationSetup.SetupModalMessageBox(
                  customMessageBoxTextColor: Color.FromArgb("#FFFFFF"),
                  customMessageBoxHeightRequest: 350,
                  customMessageBoxWidthRequest: 300,
                  customMessageBoxBackgroundColor: Color.FromArgb("#0000FF"),
                  customMessageBoxTitlePosition: LayoutOptions.CenterAndExpand,
                  customMessageBoxButtonBackgroundColor: Color.FromArgb("#FFFFFF"),
                  CustomMessageBoxButtonTextColor: Color.FromArgb("#000000")
                  );
                var builder = MauiApp.CreateBuilder();
                builder.UseMauiApp<App>().ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
                RegisterEssentials(builder.Services);
                RegisterPages(builder.Services);
                RegisterViewModels(builder.Services);
                builder.UseMauiCommunityToolkit();//Registering for MAUI Popup
                var app = builder.Build();
                MauiServiceHandler.MauiAppBuilder = app;
                return app;
            }
            catch (Exception ex)
            {

                return null;
            }
        }
        static void RegisterPages(in IServiceCollection services)
        {
            services.AddTransient<MainPage>();
        }
        static void RegisterViewModels(in IServiceCollection services)
        {
            services.AddTransient<MainPageViewModel>();
            services.AddTransient<SelfModalMessageBoxViewModel>();
        }
        static void RegisterEssentials(in IServiceCollection services)
        {
            services.AddSingleton<IModalMessageBoxServiceHandler, ModalMessageBoxServiceHandler>();
        }
    }
}
