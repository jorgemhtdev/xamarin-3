using FFImageLoading.Forms.Platform;

namespace AutofacDemo.iOS
{
    using Foundation;
    using UIKit;
    using Xamarin.Forms;

    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Forms.Init();
            CachedImageRenderer.Init();
            LoadApplication(new App());

            base.FinishedLaunching(app, options);


            UINavigationBar.Appearance.SetBackgroundImage(new UIImage(), UIBarMetrics.Default);
            UINavigationBar.Appearance.ShadowImage = new UIImage();
            UINavigationBar.Appearance.BackgroundColor = UIColor.Clear;
            UINavigationBar.Appearance.TintColor = UIColor.White;
            UINavigationBar.Appearance.BarTintColor = UIColor.Clear;
            UINavigationBar.Appearance.Translucent = true;

            return true;
        }
    }
}
