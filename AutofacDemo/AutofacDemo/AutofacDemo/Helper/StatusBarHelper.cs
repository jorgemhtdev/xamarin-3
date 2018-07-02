namespace AutofacDemo.Helper
{
    using Xamarin.Forms;

    public class StatusBarHelper
    {
        private static readonly StatusBarHelper _instance = new StatusBarHelper();
        public const string TranslucentStatusChangeMessage = "TranslucentStatusChange";

        public static StatusBarHelper Instance => _instance;

        public void MakeTranslucentStatusBar(bool translucent) => MessagingCenter.Send(this, TranslucentStatusChangeMessage, translucent);
    }
}

