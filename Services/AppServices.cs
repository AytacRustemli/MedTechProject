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
    public class AppServices
    {
        private readonly MedTechDbContext _context;

        public AppServices(MedTechDbContext context)
        {
            _context = context;
        }

        public List<App> GetAll()
        {
            var app = _context.Apps.ToList();
            return app;
        }

        public void CreateApp(App app)
        {
            _context.Apps.Add(app);
            _context.SaveChanges();
        }

        public App GetAppById(int id)
        {
            return _context.Apps.FirstOrDefault(x => x.ID == id);
        }

        public void EditApp(App app,string PhotoURL)
        {
            app.PhotoURL = PhotoURL;
            var updatedentity = _context.Entry(app);
            updatedentity.State = EntityState.Modified;
            _context.SaveChanges();
        }

        public App GetAppDetailById(int id)
        {
            return _context.Apps.FirstOrDefault(x=>x.ID == id);
        }

        public void DeleteApp(App app)
        {
            _context.Apps.Remove(app);
            _context.SaveChanges();
        }
    }
}
