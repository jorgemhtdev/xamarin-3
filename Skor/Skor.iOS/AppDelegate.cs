namespace Skor.iOS
{
    using Foundation;
    using UIKit;
    using Skor.Controls.iOS;
    using Xamarin.Forms;
    using Xamarin.Forms.Platform.iOS;

    [Register("AppDelegate")]
    public partial class AppDelegate : FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Forms.Init();
            Controls.Init();

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
