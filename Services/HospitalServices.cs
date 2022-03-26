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
    public class HospitalServices
    {
        private readonly MedTechDbContext _context;

        public HospitalServices(MedTechDbContext context)
        {
            _context = context;
        }

        public List<Hospital> GetAll()
        {
            var hospital = _context.Hospitals.ToList();
            return hospital;
        }

        public void CreateHospital(Hospital hospital)
        {
             _context.Hospitals.Add(hospital);
             _context.SaveChanges();
        }

        public List<Hospital> GetHospitalById(int id)
        {
            return _context.Hospitals.Where(x => x.ID == id).ToList();
        }

        public void EditHospital(Hospital hospital,string PhotoURL)
        {
            hospital.IconURL = PhotoURL;
            var updatedEntity = _context.Entry(hospital);
            updatedEntity.State = EntityState.Modified;
            _context.SaveChanges();
        }

        public List<Hospital> GetHospitalDetailById(int id)
        {
            return _context.Hospitals.Where(x => x.ID == id).ToList();
        }

        public void DeleteHospital(Hospital hospital)
        {
            _context.Hospitals.Remove(hospital);
            _context.SaveChanges();
        }
    }
}
