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
    public class QualityServices
    {
        private readonly MedTechDbContext _context;

        public QualityServices(MedTechDbContext context)
        {
            _context = context;
        }

        public List<Quality> GetAll()
        {
            var quality = _context.Qualitys.ToList();
            return quality;
        }

        public void CreateQuality(Quality quality)
        {
            _context.Qualitys.Add(quality);
            _context.SaveChanges();
        }

        public List<Quality> GetQualityById(int id)
        {
            return _context.Qualitys.Where(x => x.ID == id).ToList();
        }

        public void EditQuality(Quality quality,string PhotoURL)
        {
            quality.PhotoURL = PhotoURL;
            var updatedEntity = _context.Entry(quality);
            updatedEntity.State = EntityState.Modified;
            _context.SaveChanges();
        }

        public List<Quality> GetQualityDetailById(int id)
        {
            return _context.Qualitys.Where(x => x.ID == id).ToList();
        }

        public void DeleteQuality(Quality quality)
        {
            _context.Qualitys.Remove(quality);
            _context.SaveChanges();
        }
    }
}
