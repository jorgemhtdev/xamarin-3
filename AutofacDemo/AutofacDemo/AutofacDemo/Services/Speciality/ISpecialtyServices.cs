namespace AutofacDemo.Services.Speciality
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Model;

    public interface ISpecialtyServices
    {
        Task<IEnumerable<SpecialityModel>> GetSpecialitiesAsync();
    }
}
