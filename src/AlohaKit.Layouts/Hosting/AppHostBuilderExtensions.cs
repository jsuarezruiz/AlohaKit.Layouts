using Microsoft.Maui.Controls.Compatibility.Hosting;

namespace AlohaKit.Layouts.Hosting
{
    public static class AppHostBuilderExtensions
    {
        public static MauiAppBuilder UseAlohaKitLayouts(this MauiAppBuilder builder)
        {
            builder 
                .UseMauiCompatibility();

            return builder;
        }
    }
}
