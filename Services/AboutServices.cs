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
    public class AboutServices
    {
        private readonly MedTechDbContext _context;

        public AboutServices(MedTechDbContext context)
        {
            _context = context;
        }

        public List<About> GetAll()
        {
            var about = _context.Abouts.ToList();
            return about;
        }

        public void CreateAbout(About about)
        {
            _context.Abouts.Add(about);
            _context.SaveChanges();
        }

        public List<About> GetAboutById(int id)
        {
            return _context.Abouts.Where(x => x.ID == id).ToList();
        }

        public void EditAbout(About about, string PhotoURL)
        {
            about.PhotoURL = PhotoURL;
            var updatedEntity = _context.Entry(about);
            updatedEntity.State = EntityState.Modified;
            _context.SaveChanges();
        }

        public About GetAboutDetailById(int id)
        {
            return _context.Abouts.FirstOrDefault(x => x.ID == id);
        }

        public void DeleteAbout(About about)
        {
            _context.Abouts.Remove(about);
             _context.SaveChanges();
        }
    }
}
