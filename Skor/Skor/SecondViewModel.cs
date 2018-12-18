namespace Skor
{
    using System.Threading.Tasks;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class SecondViewModel
    {
        public ICommand BackCommand => new Command(async () => await Back());

        private async Task Back() => await App.Current.MainPage.Navigation.PopToRootAsync();
    }
}
