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
    public class ProfessionalServices
    {
        private readonly MedTechDbContext _context;

        public ProfessionalServices(MedTechDbContext context)
        {
            _context = context;
        }

        public List<Professional> GetAll()
        {
            var professional = _context.Professionals.ToList();
            return professional;
        }

        public void CreateProfessional(Professional professional)
        {
            _context.Professionals.Add(professional);
            _context.SaveChanges();
        }

        public Professional GetProfessionalById(int id)
        {
            return _context.Professionals.FirstOrDefault(x => x.ID == id);
        }

        public void EditProfessional(Professional professional)
        {
            var updatedEntity = _context.Entry(professional);
            updatedEntity.State = EntityState.Modified;
            _context.SaveChanges();
        }

        public Professional GetProfessionalDetailById(int id)
        {
            return _context.Professionals.FirstOrDefault(x => x.ID == id);
        }

        public void DeleteProfessional(Professional professional)
        {
            _context.Professionals.Remove(professional);
            _context.SaveChanges();
        }
    }
}
