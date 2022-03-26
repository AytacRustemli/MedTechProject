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
    public class PatientServices
    {
        private readonly MedTechDbContext _context;

        public PatientServices(MedTechDbContext context)
        {
            _context = context;
        }

        public List<Patient> GetAll()
        {
            var patient = _context.Patients.ToList();
            return patient;
        }

        public void CreatePatient(Patient patient)
        {
            _context.Patients.Add(patient);
            _context.SaveChanges();
        }

        public Patient GetPatientById(int id)
        {
            return _context.Patients.FirstOrDefault(x => x.ID == id);
        }

        public void EditPatient(Patient patient,string PhotoURL)
        {
            patient.PhotoURL = PhotoURL;
            var updatedEntity = _context.Entry(patient);
            updatedEntity.State = EntityState.Modified;
            _context.SaveChanges();
        }

        public Patient GetPatientDetailById(int id)
        {
            return _context.Patients.FirstOrDefault(x => x.ID == id);
        }

        public void DeletePatient(Patient patient)
        {
            _context.Patients.Remove(patient);
            _context.SaveChanges();
        }
    }
}
