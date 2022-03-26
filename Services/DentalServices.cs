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
    public class DentalServices
    {
        private readonly MedTechDbContext _context;

        public DentalServices(MedTechDbContext context)
        {
            _context = context;
        }

        public List<Dental> GetAll()
        {
            var dental = _context.Dentals.ToList();
            return dental;
        }

        public void CreateDental(Dental dental)
        {
            _context.Dentals.Add(dental);
            _context.SaveChanges();
        }

        public Dental GetDentalById(int id)
        {
            return _context.Dentals.FirstOrDefault(x => x.ID == id);
        }

        public void EditDental(Dental dental, string PhotoURL)
        {
            dental.PhotoURL = PhotoURL;
            var updatedEntity = _context.Entry(dental);
            updatedEntity.State = EntityState.Modified;
            _context.SaveChanges();
        }

        public Dental GetDentalDetailById(int id)
        {
            return _context.Dentals.FirstOrDefault(x => x.ID == id);
        }

        public void DeleteDental(Dental dental)
        {
            _context.Dentals.Remove(dental);
            _context.SaveChanges();
        }
    }
}
