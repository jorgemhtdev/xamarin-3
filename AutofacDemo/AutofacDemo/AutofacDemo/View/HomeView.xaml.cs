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
                    Children.Add(new DoctorView() { Title = "Doctor" });
                    Children.Add(new SpecialityView() { Title = "Especialidad" });
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