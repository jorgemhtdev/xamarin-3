using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace AutofacDemo
{
    using ViewModel;
    using Services.Navigation;
    using ViewModel.Base;
    using System.Threading.Tasks;
    using Xamarin.Forms;

    public partial class App : Application
	{
	    public static void BuildDependencies() => Locator.Instance.Build();

        public App ()
		{
		    BuildDependencies();
		    InitializeComponent();
		    InitNavigation();
        }

	    private Task InitNavigation()
	    {
	        var navigationService = Locator.Instance.Resolve<INavigationService>();
	        return navigationService.NavigateToAsync<ExtendedSplashViewModel>();
	    }

        protected override void OnStart () { }

		protected override void OnSleep () { }

        protected override void OnResume () { }
    }
}
