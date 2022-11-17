using AlohaKit.Layouts.Hosting;

namespace AlohaKit.Layouts.Gallery
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseAlohaKitLayouts();

            return builder.Build();
        }
    }
}