namespace AutofacDemo.View
{
    using Helper;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginView : ContentPage
	{
		public LoginView ()
		{
			InitializeComponent ();
        }

	    protected override void OnSizeAllocated(double width, double height)
	    {
	        base.OnSizeAllocated(width, height);

	        SignButtons.Orientation = width > height ? StackOrientation.Horizontal : StackOrientation.Vertical;
        }
    }
}