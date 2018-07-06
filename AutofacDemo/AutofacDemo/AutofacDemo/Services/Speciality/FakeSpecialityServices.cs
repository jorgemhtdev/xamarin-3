using AutofacDemo.Extensions;

namespace AutofacDemo.Services.Speciality
{
    using Model;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class FakeSpecialityServices : ISpecialtyServices
    {
        private static readonly List<SpecialityModel> Specialities = new List<SpecialityModel>
        {
            new SpecialityModel
            {
                SpecialtiesId = 1,
                Name = "Dermatologists‎"
            },
            new SpecialityModel
            {
                SpecialtiesId = 2,
                Name = "Cardiologists‎"
            }
        };

        public async Task<IEnumerable<SpecialityModel>> GetSpecialitiesAsync()
        {
            await Task.Delay(500);

            return Specialities;
        }
    }
}
