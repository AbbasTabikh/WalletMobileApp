using Android.App;
using Android.Runtime;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;

namespace EwalletMobileApp
{
    [Application]
    public class MainApplication : MauiApplication
    {
        public MainApplication(IntPtr handle, JniHandleOwnership ownership)
            : base(handle, ownership)
        {
        }

        protected override MauiApp CreateMauiApp()
        {
            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("NoUnderline", (h, v) =>
            {
                h.PlatformView.BackgroundTintList = Android.Content.Res.ColorStateList.ValueOf(Colors.Transparent.ToAndroid());
            });

            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("BackgroundColor", (h, v) =>
            {
                // Check if the value is a Color and apply it to the background
                if (v is Color color)
                {
                    h.PlatformView.SetBackgroundColor(color.ToAndroid());
                }
            });
            return MauiProgram.CreateMauiApp();
        }
    }
}
