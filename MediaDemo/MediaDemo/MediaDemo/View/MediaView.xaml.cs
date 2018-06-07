namespace MediaDemo.View
{
    using ViewModel;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MediaView : ContentPage
	{
		public MediaView ()
		{
			InitializeComponent ();

		    BindingContext = new MediaViewModel();
		}
    }
}