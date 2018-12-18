namespace Skor
{
    using System.Threading.Tasks;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class MainViewModel
    {
        public ICommand SecondPageCommand => new Command(async () => await SecondPage());

        private async Task SecondPage() =>  await App.Current.MainPage.Navigation.PushAsync(new SecondView());
    }
}

