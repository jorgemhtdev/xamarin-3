using AutofacDemo.Services.Speciality;
using AutofacDemo.ViewModel;
using AutofacDemo.ViewModel.Base;

namespace AutofacDemo.View
{
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeView : TabbedPage
    {
        public HomeView ()
        {
            InitializeComponent();

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    Children.Add(new DoctorView()
                    {
                        Title = "Doctor",
                        BindingContext = Locator.Instance.Resolve(typeof(DoctorViewModel))
                    });
                    Children.Add(new SpecialityView()
                    {
                        Title = "Especialidad",
                        BindingContext = Locator.Instance.Resolve(typeof(SpecialityViewModel))
                    });
                    break;
                case Device.Android:
                    Children.Add(new DoctorView() { Title = "Doctor" });
                    Children.Add(new SpecialityView() { Title = "Especialidad" });
                    break;
                default:
                    Children.Add(new DoctorView() { Title = "Doctor" });
                    Children.Add(new SpecialityView() { Title = "Especialidad" });
                    break;
            }
        }
    }
}