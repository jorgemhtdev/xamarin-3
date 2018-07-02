namespace AutofacDemo.ViewModel.Base
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using Services.Navigation;
    using System.Threading.Tasks;

    public class ViewModelBase : INotifyPropertyChanged
    {
        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName]string propertyName = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        #endregion

        #region Attributes
        private bool isBusy;
        private bool isRunning;
        private bool isVisible;
        private bool isEnabled;
        private string title = string.Empty;
        #endregion

        #region Properties
        protected readonly INavigationService NavigationService;
        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }
        public bool IsRunning
        {
            get => isRunning;
            set => SetProperty(ref isRunning, value);
        }
        public bool IsEnabled
        {
            get => isEnabled;
            set => SetProperty(ref isEnabled, value);
        }
        public bool IsVisible
        {
            get => isVisible;
            set => SetProperty(ref isVisible, value);
        }
        public bool IsBusy
        {
            get => isBusy;
            set => SetProperty(ref isBusy, value);
        }
        #endregion

        protected ViewModelBase()
        {
            NavigationService = Locator.Instance.Resolve<INavigationService>();
        }

        public virtual Task InitializeAsync(object navigationData) => Task.FromResult(false);

        protected void CheckOnActivity()
        {
            IsBusy = true;
            IsRunning = true;
            IsVisible = true;
            IsEnabled = false;
        }
        protected void CheckOffActivity()
        {
            IsBusy = false;
            IsRunning = false;
            IsVisible = false;
            IsEnabled = true;
        }

        protected bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName]string propertyName = "", Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))  return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

    }
}
