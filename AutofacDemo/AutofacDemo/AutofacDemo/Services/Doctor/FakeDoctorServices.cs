namespace AutofacDemo.Services.Doctor
{
    using Model;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class FakeDoctorServices : IDoctorServices
    {
        private static List<DoctorModel> Doctors = new List<DoctorModel>
        {
            new DoctorModel
            {
                DoctorId = 1,
                Name = "Batman",
                Age = 79,
                Picture = string.Empty,
                Specialty = new SpecialityModel(){SpecialtiesId = 1, Name = "Dermatologists"}
            },
            new DoctorModel
            {
                DoctorId = 2,
                Name = "Hulk",
                Age = 43,
                Picture = string.Empty,
                Specialty = new SpecialityModel(){SpecialtiesId = 2, Name = "Cardiologists"}
            }
        };

        public async Task<IEnumerable<DoctorModel>> GetDoctorsAsync(string token = "")
        {
            await Task.Delay(500);
            return Doctors;
        }
    }
}
