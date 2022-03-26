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
    public class CraftServices
    {
        private readonly MedTechDbContext _context;

        public CraftServices(MedTechDbContext context)
        {
            _context = context;
        }

        public List<Craft> GetAll()
        {
            var craft = _context.Crafts.ToList();
            return craft;
        }

        public void CreateCraft(Craft craft)
        {
            _context.Crafts.Add(craft);
            _context.SaveChanges();
        }

        public List<Craft> GetCraftById(int id)
        {
            return _context.Crafts.Where(x => x.ID == id).ToList();
        }

        public void EditCraft(Craft craft, string PhotoURL)
        {
            craft.PhotoURL = PhotoURL;
            var UpdatedEntity = _context.Entry(craft);
            UpdatedEntity.State = EntityState.Modified;
            _context.SaveChanges();
        }

        public List<Craft> GetCraftDetailById(int id)
        {
            return _context.Crafts.Where(x => x.ID == id).ToList();
        }

        public void DeleteCraft(Craft craft)
        {
            _context.Crafts.Remove(craft);
            _context.SaveChanges();
        }
    }
}
