using Microsoft.Maui.Controls.Compatibility.Hosting;

namespace MauiPane.Hosting
{
    public static class AppHostBuilderExtensions
    {
        public static MauiAppBuilder ConfigureMauiPane(this MauiAppBuilder builder)
        {
            builder 
                .UseMauiCompatibility();

            return builder;
        }
    }
}
