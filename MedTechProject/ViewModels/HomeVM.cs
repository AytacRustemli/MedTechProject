using Entities;

namespace MedTechProject.ViewModels
{
    public class HomeVM
    {
        public List<About> About { get; set; }
        public List<Doctor> Doctor { get; set; }
        public List<Quality> Quality { get; set; }
        public List<Protect> Protect { get; set; }
        public List<Hospital> Hospital { get; set; }
        public List<Patient> Patient { get; set; }
        public List<New> New { get; set; }
        public List<App> App { get; set; }
        public List<Craft> Craft { get; set; }
        public List<Dental> Dental { get; set; }
        public List<Professional> Professional { get; set; }
    }
}
