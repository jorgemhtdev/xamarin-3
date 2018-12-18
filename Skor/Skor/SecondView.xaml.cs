namespace Skor
{
    using Xamarin.Forms;

    public partial class SecondView : ContentPage
    {
        public SecondView()
        {
            InitializeComponent();
            BindingContext = new SecondViewModel();
        }
    }
}
