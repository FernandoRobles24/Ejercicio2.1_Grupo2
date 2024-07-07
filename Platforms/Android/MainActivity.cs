using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Microsoft.Maui;
using Microsoft.Maui.Graphics;

namespace Ejercicio2._1_Grupo2;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
public class MainActivity : MauiAppCompatActivity
{
    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        SetStatusBarColor();
    }

    private void SetStatusBarColor()
    {
        if (Build.VERSION.SdkInt >= BuildVersionCodes.M)
        {
            var uiOptions = (int)Window.DecorView.SystemUiVisibility;
            bool isLightTheme = AppInfo.RequestedTheme == AppTheme.Light;

            if (isLightTheme)
            {
                Window.SetStatusBarColor(Android.Graphics.Color.ParseColor("#FFFFFF"));
                uiOptions |= (int)SystemUiFlags.LightStatusBar;
            }
            else
            {
                Window.SetStatusBarColor(Android.Graphics.Color.ParseColor("#000000"));
                uiOptions &= ~(int)SystemUiFlags.LightStatusBar;
            }

            Window.DecorView.SystemUiVisibility = (StatusBarVisibility)uiOptions;
        }
    }
}
