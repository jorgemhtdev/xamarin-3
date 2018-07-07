using AutofacDemo.ViewModel.Base;

namespace AutofacDemo.View
{
    using ViewModel;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SpecialityView : ContentPage
	{
		public SpecialityView ()
		{
			InitializeComponent();
		}

	    protected override void OnAppearing()
	    {
	        base.OnAppearing();

	        (this.BindingContext as ViewModelBase)?.InitializeAsync(null);
	    }
	}
}