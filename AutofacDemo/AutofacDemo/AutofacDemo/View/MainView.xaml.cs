namespace AutofacDemo.View
{
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainView : MasterDetailPage
	{
		public MainView ()
		{
			InitializeComponent ();
		}
    }
}