namespace AutofacDemo.Model
{
    public class DoctorModel
    {
        public int DoctorId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Picture { get; set; }
        public SpecialityModel Specialty { get; set; }
    }
}
