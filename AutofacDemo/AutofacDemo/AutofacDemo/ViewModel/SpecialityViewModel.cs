namespace AutofacDemo.ViewModel
{
    using Extensions;
    using Model;
    using Base;
    using Services.Speciality;
    using System;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Threading.Tasks;

    public class SpecialityViewModel : ViewModelBase
    {
        private ObservableCollection<SpecialityModel> speciality;

        private readonly ISpecialtyServices SpecialtyServices;

        public SpecialityViewModel(ISpecialtyServices SpecialtyServices)
        {
            this.SpecialtyServices = SpecialtyServices;
        }

        public ObservableCollection<SpecialityModel> Speciality
        {
            get => speciality;
            set => SetProperty(ref speciality, value);
        }

        public override async Task InitializeAsync(object navigationData)
        {
            try
            {
                IsBusy = true;

                var specialities = await SpecialtyServices.GetSpecialitiesAsync();

                Speciality = specialities.ToObservableCollection();


            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[Home] Error: {ex}");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
