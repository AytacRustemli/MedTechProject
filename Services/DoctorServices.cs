using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class DoctorServices
    {
        private readonly MedTechDbContext _context;

        public DoctorServices(MedTechDbContext context)
        {
            _context = context;
        }

        public List<Doctor> GetAll()
        {
            var doctor = _context.Doctors.ToList();
            return doctor;
        }

        public void CreateDoctor(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            _context.SaveChanges();
        }

        public List<Doctor> GetDoctorAll()
        {
            return _context.Doctors.Take(3).ToList();
        }

        public List<Doctor> GetContactDoctorAll()
        {
            return _context.Doctors.Take(4).ToList();
        }

        public List<Doctor> GetDoctorById(int id)
        {
            return _context.Doctors.Where(x => x.ID == id).ToList();
        }

        public void EditDoctor(Doctor doctor,string PhotoURL)
        {
            doctor.IconURL = PhotoURL;
            var updatedEntity = _context.Entry(doctor);
            updatedEntity.State = EntityState.Modified;
            _context.SaveChanges();
        }

        public List<Doctor> GetDoctorDetailById(int id)
        {
            return _context.Doctors.Where(x => x.ID == id).ToList();
        }

        public void DeleteDoctor(Doctor doctor)
        {
            _context.Doctors.Remove(doctor);
            _context.SaveChanges();
        }

    }
}
