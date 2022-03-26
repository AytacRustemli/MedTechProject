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
    public class ProtectServices 
    {
        private readonly MedTechDbContext _context;

        public ProtectServices(MedTechDbContext context)
        {
            _context = context;
        }

        public List<Protect> GetAll()
        {
            var protect = _context.Protects.ToList();
            return protect;
        }

        public void CreateProtect(Protect protect)
        {
            _context.Protects.Add(protect);
            _context.SaveChanges();
        }

        public Protect GetProtectById(int id)
        {
            return _context.Protects.FirstOrDefault(x => x.ID == id);
        }

        public void EditProtect(Protect protect, string PhotoURL)
        {
            protect.PhotoURL = PhotoURL;
            var updatedEntity = _context.Entry(protect);
            updatedEntity.State = EntityState.Modified;
            _context.SaveChanges();
        }

        public Protect GetProtectDetailById(int id)
        {
            return _context.Protects.FirstOrDefault(x => x.ID == id);
        }

        public void DeleteProtect(Protect protect)
        {
            _context.Protects.Remove(protect);
            _context.SaveChanges();
        }
    }
}
